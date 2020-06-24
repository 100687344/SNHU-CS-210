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
using System.Windows.Shapes;

namespace Monopoly
{
    /// <summary>
    /// Interaction logic for Jail.xaml
    /// </summary>
    public partial class Jail : Window
    {
        public Jail()
        {
            InitializeComponent();
        }

        private void BtnJailPay_Click(object sender, RoutedEventArgs e)
        {
            Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= 50;
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            w.UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid $50 To Get Out Of Jail");
            w.fillPlayerInfo();
            Engine.gameBoard.players[Engine.currentTurn].IsInJail = false;
            this.Close();
        }

        private void BtnUseJailCard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Application.Current.MainWindow;

            if (Engine.gameBoard.players[Engine.currentTurn].HasJailCard)
            {
                Engine.gameBoard.players[Engine.currentTurn].JailCard--;
                w.UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Used A GOJF Card");
                w.fillPlayerInfo();
                Engine.gameBoard.players[Engine.currentTurn].IsInJail = false;
                this.Close();
            }
            else
            {
                w.UpdatePlayerEvents("You Dont Have A GOJF Card. Pay $50, Or End Your Turn");
                this.Close();
            }
        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
