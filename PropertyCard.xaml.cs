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
    /// Interaction logic for PropertyCard.xaml
    /// </summary>
    public partial class PropertyCard : Window
    {
        public PropertyCard()
        {
            InitializeComponent();
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            //  //players money - property base rent
            //  Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].BuyPrice;

            // // Engine.gameBoard.players[Engine.currentTurn].OwnedProperties.Add(Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation]);
            //// Property p = new Property() Engine.gameBoard

            //  Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner = Engine.gameBoard.players[Engine.currentTurn].Name;
            //  // Engine.gameBoard.players[Engine.currentTurn].OwnedProperties.Add(Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation]);
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            w.BtnBuy_Click(sender, e);
            this.Close();
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            //Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].BaseRent;
            //player who owns property should get the money
            //player who owns property at the current players location
            //Engine.gameBoard.players +=
            //Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].BaseRent;
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            w.BtnPay_Click(sender, e);
            this.Close();
            //Engine.gameBoard.players[Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation]].AvailableMoney +=
            //the property that was landed on

        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
