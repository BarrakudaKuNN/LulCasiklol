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
        int win=0;

        Image Image1_Bit = new Image();
        List<int> list;

        S1 s1;
        S1 s2;
        S1 s3;

        List<Slot_Item> slot_s;
        public int BankAccount { get => bankAccount; set => bankAccount = value; }
        public int Stack { get => stack; set => stack = value; }
        public int Win { get => win; set => win = value; }

        public CasinoLogic()
        {
            slot_s = new List<Slot_Item>()
            {
                new S1(){Id=11,Cost=10, pathPic1="Images/First.jpg"},
                new S1(){Id=22,Cost=20, pathPic1="Images/Second.jpg"},
                new S1(){Id=33,Cost=30, pathPic1="Images/Third.jpg"},
            };
            
        }
        
        public void CasinoTake(Random rnd,Image image, Image image2, Image image3, Slider slider)
        {
            //Объекты классов иконок 
            
            // тут мы рандомизируем обекты и приводим их к классу С1
            s1 = (S1)slot_s[rnd.Next(0,3)];
            s2 = (S1)slot_s[rnd.Next(0, 3)];
            s3 = (S1)slot_s[rnd.Next(0, 3)];

            //Записываем картики в соответсвии с рандомизатором

            image.Source = Image1_Bit.Source = new BitmapImage(new Uri(s1.pathPic1, UriKind.Relative));
            image2.Source = Image1_Bit.Source = new BitmapImage(new Uri(s2.pathPic1, UriKind.Relative));
            image3.Source = Image1_Bit.Source = new BitmapImage(new Uri(s3.pathPic1, UriKind.Relative));

            if (s1.Id == s2.Id & s1.Id == s3.Id)
            {
                win = (s1.Cost + (int)slider.Value) * 6;
                bankAccount += win;
            }

        }
        public void RefreshStat(TextBlock text,TextBlock text2)
        {
            text.Text = bankAccount.ToString();
            text2.Text = win.ToString();
        }
        public void CasinoSpin(Slider slider, TextBlock text)
        {
            bankAccount=bankAccount - (int)slider.Value;
            text.Text = bankAccount.ToString();
        }
    }
}
