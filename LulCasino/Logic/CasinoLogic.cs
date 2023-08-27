using LulCasino.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LulCasino
{
    internal class CasinoLogic
    {
        int bankAccount = 1000;
        int stack;
        int win;
        
        public List<Slot_Item> slot_s;
        public S1 win_Slot;

        public int BankAccount { get => bankAccount; set => bankAccount = value; }
        public int Stack { get => stack; set => stack = value; }
        public int Win { get => win; set => win = value; }

        public CasinoLogic()
        {
            slot_s = new List<Slot_Item>()
            {
                new S1(){Id=11,Name="Firs",Cost=10},
                new S1(){Id=22,Name="Sec",Cost=20},
                new S1(){Id=33,Name="Trd",Cost=30},
            };
            win_Slot = new S1() { Name = "TestSlot" };
        }
        public int[] CasinoTake(List<Slot_Item> slots, Random rnd,TextBlock text1, TextBlock text2, TextBlock text3,Slider slider)
        {
            
            S1 s1;
            S1 s2;
            S1 s3;
            s1 = (S1)slots[rnd.Next(0,3)];
            s2 = (S1)slots[rnd.Next(0, 3)];
            s3 = (S1)slots[rnd.Next(0, 3)];

            int[] ret= { s1.Id, s2.Id, s3.Id };

            text1.Text = s1.Id.ToString();
            text2.Text = s2.Id.ToString();
            text3.Text = s3.Id.ToString();
            if (s1.Id == s2.Id & s1.Id == s3.Id)
            {
                bankAccount += (s1.Cost + s1.Cost + s1.Cost)*(int)slider.Value;
            }
            return ret;

        }
        public void RefreshStat(int Bank,TextBlock text)
        {
            text.Text = Bank.ToString();
        }
        public void CasinoSpin(Slider slider, TextBlock text)
        {
            bankAccount=bankAccount - (int)slider.Value;
            text.Text = bankAccount.ToString();
        }
    }
}
