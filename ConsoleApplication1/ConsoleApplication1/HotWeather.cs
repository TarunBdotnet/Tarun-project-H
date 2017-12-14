using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingUp2
{
   public class HotWeather:IPutOns
    {
        public String PutFootWear()
        {
            return "sandals";
        }
        public String PutHeadWear()
        {
            return "sunglasses";
        }
        public String PutSocks()
        {
            return "fail";
        }
        public String PutShirt()
        {
            return "shirt";
        }
        public String PutJacket()
        {
            return "fail";
        }
        public String PutPants()
        {
            return "shorts";
        }
        public String LeaveHouse()
        {
            return "leaving house";
        }
        public String TakeOffPajamas()
        {
            return "Removing PJs";
        }

    }
}
