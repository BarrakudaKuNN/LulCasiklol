using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulCasino.Slots
{
    internal class S1 : Slot_Item
    {
        public string pathPic1 = "Images/Second.jpg";
        int id = 1;
        int cost = 10;

       
        public int Id { get => id; set => id = value; }
        public int Cost { get => cost; set => cost = value; }
    }
}
