using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DressingUp2
{
    public class ProcessInputString
    {
        private string input;
        private List<String> list;

        public ProcessInputString(String input)
        {
            this.input = input;
            list = new List<string>();
        }

        /*
         * Reformat the array after splitting
         */
        public string[] ProcessInput()
        {
            try
            {
                input = input.Trim();
                var s = input.Split(',');
                for (int i = 0; i < s.Length; i++)
                {
                    if (i == 0)
                    {
                        var k = s[0].Split(' ');
                        for (int j = 0; j < s[0].Split(' ').Length; j++)
                        {
                            if (k[j].Trim() != string.Empty)
                            {
                                list.Add(k[j]);
                            }

                        }
                    }
                    else if (s[i].Trim() != string.Empty)
                    {
                        list.Add(s[i]);
                    }
                }
                return list.ToArray();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
