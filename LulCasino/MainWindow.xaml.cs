using LulCasino.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LulCasino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CasinoLogic casino;
        Random random;
        BitmapImage image1;
        BitmapImage image2;
        BitmapImage image3;
        public MainWindow()
        {
            InitializeComponent();

            casino = new CasinoLogic();
            random= new Random();
            Slider_Bet.Minimum = 20;
            Slider_Bet.Maximum = 100;
            Slider_Bet.ValueChanged += Slider_Bet_ValueChanged;
            image1= new BitmapImage(new Uri(@"Images\First.jpg", UriKind.Relative));
            image1 = new BitmapImage(new Uri("Images/Second.jpg", UriKind.Relative));
            image1 = new BitmapImage(new Uri(@"Images\Third.jpg", UriKind.Relative));
            string filePath = Environment.CurrentDirectory;
        }

        private void Slider_Bet_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlock_slider_value.Text = Math.Round(e.NewValue).ToString();
        }

        private void Button_Spin_Click(object sender, RoutedEventArgs e)
        {
            casino.CasinoSpin(Slider_Bet, TextBlock_Current_money);            
            int[]d = casino.CasinoTake(casino.slot_s, random, Image1, Image2, Image3,Slider_Bet);
            if (d[0] == d[1] & d[0] == d[2])
            {
                
            }

            casino.RefreshStat(casino.BankAccount, TextBlock_Current_money);
        }

        private void Button_Add_Money_Click(object sender, RoutedEventArgs e)
        {
            Image myImage = new Image();
            myImage.Source = new BitmapImage(new Uri("Images/Second.jpg", UriKind.Relative));
            Image1.Source=myImage.Source;
        }
    }
}
