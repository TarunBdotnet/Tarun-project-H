using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingUp2
{
    public class ColdWeather : IPutOns
    {
        public String PutFootWear()
        {
            return "boots";
        }
        public String PutHeadWear()
        {
            return "hat";
        }
        public String PutSocks()
        {
            return "socks";
        }
        public String PutShirt()
        {
            return "shirt";
        }
        public String PutJacket()
        {
            return "jacket";
        }
        public String PutPants()
        {
            return "pants";
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
