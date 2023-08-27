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
        public MainWindow()
        {
            InitializeComponent();

            casino = new CasinoLogic();
            random= new Random();
            Slider_Bet.Minimum = 20;
            Slider_Bet.Maximum = 100;
            Slider_Bet.ValueChanged += Slider_Bet_ValueChanged;
        }

        private void Slider_Bet_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlock_slider_value.Text = Math.Round(e.NewValue).ToString();
        }

        private void Button_Spin_Click(object sender, RoutedEventArgs e)
        {
            casino.CasinoSpin(Slider_Bet, TextBlock_Current_money);            
            int[]d = casino.CasinoTake(casino.slot_s, random, TextBlock_First, TextBlock_Second, TextBlock_Third,Slider_Bet);
            if (d[0] == d[1] & d[0] == d[2])
            {

            }
            casino.RefreshStat(casino.BankAccount, TextBlock_Current_money);
        }
    }
}
