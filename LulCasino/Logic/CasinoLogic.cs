using LulCasino.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LulCasino
{
    internal class CasinoLogic
    {
        int bankAccount = 1000;
        int stack;
        int win;

        Image Image1_Bit = new Image();
        Image Image2_Bit = new Image();
        Image Image3_Bit = new Image();

        string pathPic1 = "Images/Second.jpg";
        string pathPic2 = "Images/Second.jpg";
        string pathPic3 = "Images/Second.jpg";

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
            CasinoPicRefresh(Image1_Bit, Image2_Bit, Image3_Bit);


        }
        public int[] CasinoTake(List<Slot_Item> slots, Random rnd,Image image, Image image2, Image image3, Slider slider)
        {
            
            S1 s1;
            S1 s2;
            S1 s3;
            s1 = (S1)slots[rnd.Next(0,3)];
            s2 = (S1)slots[rnd.Next(0, 3)];
            s3 = (S1)slots[rnd.Next(0, 3)];

            int[] ret= { s1.Id, s2.Id, s3.Id };

            image.Source = Image1_Bit.Source;
            image2.Source = Image2_Bit.Source;
            image3.Source = Image3_Bit.Source;

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

        public void CasinoPicRefresh(Image one,Image tw,Image tr)
        {
            one.Source = new BitmapImage(new Uri(pathPic1, UriKind.Relative));
            tw.Source = new BitmapImage(new Uri(pathPic2, UriKind.Relative));
            tr.Source = new BitmapImage(new Uri(pathPic3, UriKind.Relative));
        }
    }
}
