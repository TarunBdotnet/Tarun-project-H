using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingUp2
{
    class Program
    {
        static void Main(string[] args)
        {
             String line;
            
            try
            {
                while (true)
                {
                    line = Console.ReadLine();
                    if (!string.IsNullOrEmpty(line.Trim()))
                    {
                        IDressUp dressup = new DressUp(line);
                        String s = dressup.DressingOrder();
                        Console.WriteLine(s);
                        Console.WriteLine();
                    }

                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            


            //Scanner sc  = new Scanner(System.in);
            //String input  =  sc.nextLine();
            //IDressUp  dressup = new DressUp(input);
            //String s = dressup.DressingOrder();
            //System.out.println(s);
        }
    }
}
