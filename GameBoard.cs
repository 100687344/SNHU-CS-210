using System;
using System.Collections.Generic;
using System.IO;
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

namespace Monopoly
{
   public class GameBoard
    {
        public List<Property> _properties = new List<Property>();
        public List<ActionCard> _actionCards = new List<ActionCard>();
        public List<Location> _locations = new List<Location>();
        public List<Player> _players = new List<Player>();
        String[] props;
        String[] chests;
        String[] chance;
        String[] boardTiles;
        public string[] testValues = {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "010",
                                      "110", "210", "310", "410", "510", "610", "710", "810", "910", "1010",
                                      "109", "108", "107", "106", "105", "104", "103", "102", "101", "100",
                                      "90", "80", "70", "60", "50", "40", "30", "20", "10"};
        public GameBoard()
        {
            findLocations();
            findProperties();
            findChestCards();
            findChanceCards();
            fillPlayers();
           // addPlayer();
        }

        private void findLocations()
        {
            try
            {
                boardTiles = File.ReadAllLines("../../data/OriginalLocations.txt");
                fillLocations(boardTiles);
            }catch(Exception)
            {
                MessageBox.Show("OriginalLocations.txt not found.");
            }finally
            {
            }
        }
        /// <summary>
        /// Finds Text File For Properties
        /// </summary>
         private void findProperties()
         {
            try
            {
                props = File.ReadAllLines("../../data/OriginalProperties.txt");
                fillPropertiesList(props);
            }catch(Exception)
            {
                MessageBox.Show("OriginalProperties.txt not found. Contact support");
            }finally
            {
                //Additional Stuff Can Be Done Here
            }
        }
        /// <summary>
        /// Fills Properties From Text File
        /// </summary>
        /// <param name="board"></param>
        private void fillPropertiesList(String[] board)
        {
            String[] seperatedProps = new string[board.Length * 12];
            for (int i = 0; i < board.Length; i++)
            {
                //Base property. Values Will Be Changed In This Loop
                Property p = new Property("Name", "Color", 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, "Bank");

                String stuffToSplit = board[i];
                String[] newStuff = stuffToSplit.Split(',');

                    p.PropertyName = newStuff[0];
                    p.CardColor = newStuff[1];
                    p.BuyPrice = Convert.ToInt16(newStuff[2]);
                    p.BaseRent = Convert.ToInt16(newStuff[3]);
                    p.ColorSetRent = Convert.ToInt16(newStuff[4]);
                    p.House1Rent = Convert.ToInt16(newStuff[5]);
                    p.House2Rent = Convert.ToInt16(newStuff[6]);
                    p.House3Rent = Convert.ToInt16(newStuff[7]);
                    p.House4Rent = Convert.ToInt16(newStuff[8]);
                    p.HotelRent = Convert.ToInt16(newStuff[9]);
                    p.HotelCost = Convert.ToInt16(newStuff[10]);
                    p.HouseCost = Convert.ToInt16(newStuff[11]);
                    p.ListLocation = Convert.ToInt16(newStuff[12]);
                    p.Owner = newStuff[13];
                   

                _properties.Add(p);

               // MessageBox.Show("hello");
            }
        }

        private void fillLocations(String[] tiles)
        {
           // string stuffToSplit = tiles[i];
            for (int i = 0; i < tiles.Length; i++)
            {
                Location l = new Location("Name");
                l.Name = tiles[i];
                _locations.Add(l);
            }
        }
        /// <summary>
        /// Finds File For Chest Cards
        /// </summary>
        private void findChestCards()
        {
            try
            {
                chests = File.ReadAllLines("../../data/OriginalChestCards.txt");
                fillCommunityChestCards(chests);
            }catch(Exception)
            {
                MessageBox.Show("OriginalChestCards.txt not found. Contact support");
            }finally
            {
                //Additional Stuff Can Be Done Here
            }
        }
        /// <summary>
        /// Fills Chest Cards
        /// </summary>
        /// <param name="chests"></param>
        public void fillCommunityChestCards(String[] chests)
        {
            String[] seperatedChests = new string[chests.Length * 2];
            for (int i = 0; i < chests.Length; i++)
            {
                //Base Community Chest. Values Will Be Changed In This Loop
                ActionCard ct = new ActionCard("Value", 0);

                String stuffToSplit = chests[i];
                String[] newStuff = stuffToSplit.Split('/');

                ct.ActionCardText = newStuff[0];
                ct.ActionCardCase = Convert.ToInt16(newStuff[1]);

                _actionCards.Add(ct);
            }
        }
        /// <summary>
        /// Finds File For Chance Cards
        /// </summary>
        private void findChanceCards()
        {
            try
            {
                chance = File.ReadAllLines("../../data/OriginalChanceCards.txt");
                fillCommunityChestCards(chance);
            }catch(Exception)
            {
                MessageBox.Show("OriginalChanceCards.txt not found. Contact support");
            }finally
            {
                //Additional Stuff Can Be Done Here
            }
        }
        /// <summary>
        /// Fills Chance Cards
        /// </summary>
        /// <param name="chance"></param>
        private void fillChanceCards(String[] chance)
        {
            String[] seperatedChances = new string[chance.Length * 2];
            for (int i = 0; i < chance.Length; i++)
            {
                //Base Chance Card. Values Will Be Chanced In This Loop
                ActionCard cn = new ActionCard("Value", 0);

                String stuffToSplit = chance[i];
                String[] newStuff = stuffToSplit.Split('/');

                cn.ActionCardText = newStuff[0];
                cn.ActionCardCase = Convert.ToInt16(newStuff[1]);

                _actionCards.Add(cn);
            }
        }
        /// <summary>
        /// Adds Player To Gameboard
        /// </summary>
        private void fillPlayers()
        {
            PlayerCard p = new PlayerCard();
            p.Topmost = true;
            p.Show();
        }
        /// <summary>
        /// All Properties On Board
        /// </summary>
        public List<Property> properties
        {
            get { return _properties; }
        }
        /// <summary>
        /// All Chance And Chest Cards 
        /// </summary>
        public List<ActionCard> ActionCards
        {
            get { return _actionCards; }
        }
        /// <summary>
        /// All Players On Board
        /// </summary>
        public List<Player> players
        {
            get { return _players; }
        }

        public List<Location> locations
        {
            get { return _locations; }
        }
    }
}
