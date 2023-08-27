using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulCasino.Slots
{
    internal class Slot_Item
    {
        string name;
        int id=6;
        int cost;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int Cost { get => cost; set => cost = value; }
    }
}
