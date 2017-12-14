using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DressingUp2
{
    public class DressUp : IDressUp
    {
        private IPutOns weather;
        private List<String> processedCommands;
        private String failure;
        private ProcessInputString process;
        private String input;

        public DressUp(String input)
        {
            processedCommands = new List<string>();
            failure = "fail";
            this.input = input;
            process = new ProcessInputString(input);
        }

        public string DressingOrder()
        {
            string[] s = process.ProcessInput();
            s[0] = s[0].ToUpper();
            //Initialize Object with type of weather
            if (s[0].Equals("HOT"))
            {
                weather = new HotWeather();
            }
            else if (s[0].Equals("COLD"))
            {
                weather = new ColdWeather();
            }
            else
            {
                throw new Exception("Invalid input, please enter valid weather value");
            }

            //Start
            StringBuilder dressingOrder = new StringBuilder();
            //process string and store the dress up order in stringbuilder 
            try
            {
                for (int i = 1; i < s.Length; i++)
                {
                    String command = s[i];
                    if (IsValid(command))
                    {
                        switch (s[i])
                        {
                            case "1":
                                dressingOrder.Append(", ").Append(weather.PutFootWear());
                                break;
                            case "2":
                                dressingOrder.Append(", ").Append(weather.PutHeadWear());
                                break;
                            case "3":
                                dressingOrder.Append(", ").Append(weather.PutSocks());
                                break;
                            case "4":
                                dressingOrder.Append(", ").Append(weather.PutShirt());
                                break;
                            case "5":
                                dressingOrder.Append(", ").Append(weather.PutJacket());
                                break;
                            case "6":
                                dressingOrder.Append(", ").Append(weather.PutPants());
                                break;
                            case "7":
                                dressingOrder.Append(", ").Append(weather.LeaveHouse());
                                break;
                            case "8":
                                dressingOrder.Append(", ").Append(weather.TakeOffPajamas());
                                break;
                            default:
                                throw new Exception("Invalid weather specified in the first arguement");
                        }
                    }
                    processedCommands.Add(command);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals(failure))
                {
                    return dressingOrder.Append(", ").Append(ex.Message).ToString().Substring(2);
                    //Remove leading ", " before returning the value
                }
                throw new Exception(ex.Message);
            }


            return dressingOrder.ToString()!=string.Empty?(dressingOrder.ToString()).Substring(2):failure;
        }

        private bool IsValid(String command)
        {

            if (processedCommands.Count() == 0)
            {
                if (!command.Equals("8"))
                {
                    throw new Exception(failure);
                }
            }
            //Only 1 piece of each type of clothing may be put on
        if (processedCommands.Contains(command))
        {
        	throw new Exception(failure);
        }

        //You cannot put on socks when it is hot
        //You cannot put on a jacket when it is hot
        if ((command == "3") || (command == "5"))     //If command is for putting on socks or jacket and dresser is of type HotDresser (it is hot)
        {
            if (weather is HotWeather)
            {
            	throw new Exception(failure);
            }
        }

        //Socks must be put on before shoes
        //Pants must be put on before shoes
        //In other words, if the command is for shoes/footwear, make sure that socks and pants are already put on
        else if (command == "1")
        {
            //if the weather is hot check only for pants
        	if (weather is HotWeather)
            {
                if (!processedCommands.Contains("6"))
                {
                	throw new Exception(failure);
                }
            }                
            //else, check for both socks and pants
            else
            {
                if (!processedCommands.Contains("3") || !processedCommands.Contains("6"))
                {
                	throw new Exception(failure);
                }
            }
        }
            //The shirt must be put on before the headwear or jacket
        //In other words, if the command is for either the headwear or the jacket, make sure that the shirt is already put on
        else if ((command.Equals("2")) || (command.Equals("5")))
        {
            if (!processedCommands.Contains("4"))
            {
            	throw new Exception(failure);
            }
        }

        //You cannot leave the house until all items of clothing are on (except socks and a jacket when it’s hot)
        //If the command is for leaving the house, make sure that all the other commands have been processed
        else if (command.Equals("7"))
        {
            //Check if jacket and socks are put on only if the weather is hot
        	if (!(weather is HotWeather))        //weather is not hot
            {
                if (!processedCommands.Contains("3") || !processedCommands.Contains("5"))       
                	//jacket or shoes/footwear not put on
                {
                	throw new Exception(failure);
                }
            }

            //Check for other types of clothing irrespective of the weather type
            if (!processedCommands.Contains("1") || !processedCommands.Contains("2") || !processedCommands.Contains("4") || !processedCommands.Contains("6") || !processedCommands.Contains("8"))
            {
            	throw new Exception(failure);
            }
        }

        //If all the conditions are satisfied, return true
        return true;
        }
    }
}
