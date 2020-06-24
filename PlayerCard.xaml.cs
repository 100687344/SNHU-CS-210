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
    /// Interaction logic for PlayerCard.xaml
    /// </summary>
    public partial class PlayerCard : Window
    {
        int turnNumber = 0;
        int totalPlayers;

        public PlayerCard()
        {
            InitializeComponent();
        }

        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {

                //Creates shallow copy of main window
                MainWindow w = (MainWindow)Application.Current.MainWindow;
            string name = tbxPlayerName.Text;
            Player p = new Player(name, 0, turnNumber, 1500, 0, 0, false, false, 0, false);
            Engine.gameBoard.players.Add(p);
            MessageBox.Show("Player Added");
            turnNumber++;
                w.fillPlayerInfo();
            if(turnNumber == totalPlayers)
            {
                w.FillBoard();
                w.fillPlayerInfo();
                w.UpdatePlayerEvents("Click Roll To Begin");
                this.Close();
            }

        }

        private void BtnStartPlayerCreation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int valid = Convert.ToInt32(tbxTotalPlayers.Text);
                totalPlayers = Convert.ToInt16(tbxTotalPlayers.Text);
                //Add Check if input is valid number. Must be int between 1-8
                tbxTotalPlayers.IsEnabled = false;
                btnStartPlayerCreation.IsEnabled = false;
                tbxPlayerName.IsEnabled = true;
                btnAddPlayer.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please provide number only");
            }
        }
    }
}
