
   

using System;

using System.Windows;

using System.Windows.Controls;

using System.Windows.Media;



namespace Monopoly

{
    /// <summary>
    /// Interaction Of Main Window
    /// </summary>
    public partial class MainWindow

    {

        //Class Level Variables

        Random RNG = new Random();



        int dieOne;

        int dieTwo;

        bool thrownDice = false;

        string[] pLocations = new string[2];

        bool IsGameOver = false;



        public MainWindow()

        {

            InitializeComponent();

            Engine.StartGame();

            fillPlayerInfo();


            pLocations[0] = "btn00";

            pLocations[1] = "btn00";

        }

        /// <summary>
        /// Provides List Of Players And Information About Each Player
        /// </summary>
        public void fillPlayerInfo()

        {

            lbxPlayerInformation.Items.Clear();

            Engine.turns = Engine.gameBoard.players.Count;

            lbxPlayerInformation.Items.Add("Name  | Money  | GOJF Card | Owned Properties");

            for (int i = 0; i < Engine.gameBoard.players.Count; i++)

            {

                lbxPlayerInformation.Items.Add(Engine.gameBoard.players[i].Name.PadRight(10, '_') + Engine.gameBoard.players[i].AvailableMoney.ToString().PadRight(9, '_') + Engine.gameBoard.players[i].JailCard.ToString().PadRight(16, '_') + Engine.gameBoard.players[i].nProperties);

            }

        }

        /// <summary>
        /// Rolls Dice And Displays Image Of Dice Values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRoleDice_Click(object sender, RoutedEventArgs e)

        {

            if (!IsGameOver)
            {

                if (!Engine.gameBoard.players[Engine.currentTurn].IsInJail)

                {

                    ResetDice();

                    dieOne = RNG.Next(1, 7);

                    dieTwo = RNG.Next(1, 7);



                    if (dieOne == 1)

                        lblDie2One.Visibility = Visibility.Visible;

                    else if (dieOne == 2)

                        lblDie2Two.Visibility = Visibility.Visible;

                    else if (dieOne == 3)

                        lblDie2Three.Visibility = Visibility.Visible;

                    else if (dieOne == 4)

                        lblDie2Four.Visibility = Visibility.Visible;

                    else if (dieOne == 5)

                        lblDie2Five.Visibility = Visibility.Visible;

                    else

                        lblDie2Six.Visibility = Visibility.Visible;



                    if (dieTwo == 1)

                        lblDie1One.Visibility = Visibility.Visible;

                    else if (dieTwo == 2)

                        lblDie1Two.Visibility = Visibility.Visible;

                    else if (dieTwo == 3)

                        lblDie1Three.Visibility = Visibility.Visible;

                    else if (dieTwo == 4)

                        lblDie1Four.Visibility = Visibility.Visible;

                    else if (dieTwo == 5)

                        lblDie1Five.Visibility = Visibility.Visible;

                    else

                        lblDie1Six.Visibility = Visibility.Visible;

                    MovePlayer(dieOne + dieTwo);

                    UpdatePlayerEvents((Engine.gameBoard.players[Engine.currentTurn].Name + " Rolled A " + (dieOne + dieTwo).ToString()));

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To " + Engine.gameBoard.locations[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Name);

                }

                else

                {

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " is in Jail. Pay $50 or use a 'Get Out Of Jail Free' card.");

                }



                //SENDS VALUE OF TOTAL DIE AMOUNT

                if (!thrownDice)

                {


                    thrownDice = false;

                }

                else

                {

                    UtilityActionCardPay(RNG.Next(1, 7), RNG.Next(1, 7));

                }

                fillPlayerInfo();

                btnRoleDice.IsEnabled = false;

            }

        }

        /// <summary>
        /// Displays A Window Of How To Play The Game !!NEEDS WORK!! 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHelp_Click(object sender, RoutedEventArgs e)

        {



        }

        /// <summary>
        /// Fills A Grid With Buttons That Players Interact With
        /// </summary>
        public void FillBoard()

        {

            int tagValue = 0;

            for (int i = 0; i < grdBoard.RowDefinitions.Count; i++)

            {

                for (int k = 0; k < grdBoard.ColumnDefinitions.Count; k++)

                {

                    if ((i == 0 || i == 10) || (k == 0 || k == 10))// column 0 & 9 left and right || top or bottom

                    {

                        Button btn = new Button();



                        btn.Name = "btn" + i.ToString() + k.ToString();

                        btn.Content = Engine.gameBoard.properties[tagValue].PropertyName;

                        string tester = Engine.gameBoard.properties[tagValue].CardColor;

                        if (tester.Contains("#"))

                            btn.Click += btnPropery_Click;

                        else if (tester.Contains("Chance"))

                            btn.Click += btnChanceCard_Click;

                        else if (tester.Contains("Chest"))

                            btn.Click += btnCommunityChest_Click;

                        else if (tester.Contains("Company"))

                            btn.Click += btnUtility_Click;

                        else if (tester.Contains("RailRoad"))

                            btn.Click += btnRailRoad_Click;

                        else if (tester.Contains("Income"))

                            btn.Click += btnIncomeTax_Click;

                        else if (tester.Contains("Luxury"))

                            btn.Click += btnLuxurayTax_Click;

                        else if (tester.Contains("Jail"))

                            btn.Click += btnJail_Click;

                        btn.Tag = tagValue;

                        Grid.SetRow(btn, i);

                        Grid.SetColumn(btn, k);

                        grdBoard.Children.Add(btn);

                        tagValue++;

                    }

                }

            }

            UpdateGameBoard(0);

        }

        /// <summary>
        /// Increases The Turn Order By One And Cycles Through Player Turns
        /// </summary>
        public void UpdateTurnOrder()

        {

            btnRoleDice.IsEnabled = true;

            Engine.currentTurn++;// currentTurn++;

            if (Engine.currentTurn >= Engine.turns)

            {

                Engine.currentTurn = 0;

            }

        }

        /// <summary>
        /// Fills Block With Text Based On Game Events
        /// </summary>
        /// <param name="text">Text That Will Be Displayed</param>
        public void UpdatePlayerEvents(string text)

        {

            rtbPlayerEvents.AppendText(text + "\r\n");

            rtbPlayerEvents.ScrollToEnd();

        }

        /// <summary>
        /// Resets Images Of Dice Values. || This Function Is Not Needed, But Keeps Things Looking Nice ||
        /// </summary>
        private void ResetDice()

        {

            lblDie1One.Visibility = Visibility.Hidden;

            lblDie1Two.Visibility = Visibility.Hidden;

            lblDie1Three.Visibility = Visibility.Hidden;

            lblDie1Four.Visibility = Visibility.Hidden;

            lblDie1Five.Visibility = Visibility.Hidden;

            lblDie1Six.Visibility = Visibility.Hidden;



            lblDie2One.Visibility = Visibility.Hidden;

            lblDie2Two.Visibility = Visibility.Hidden;

            lblDie2Three.Visibility = Visibility.Hidden;

            lblDie2Four.Visibility = Visibility.Hidden;

            lblDie2Five.Visibility = Visibility.Hidden;

            lblDie2Six.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// Displays A Property Window With Values Of Selected Property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPropery_Click(object sender, EventArgs e)

        {

            Button btn = (Button)sender;

            int index = Convert.ToInt16(btn.Tag);

            PropertyCard ptc = new PropertyCard();

            ptc.rctWaterWorks.Visibility = Visibility.Hidden;

            ptc.lblUtilityOwner.Visibility = Visibility.Hidden;

            ptc.lblWaterWorks.Visibility = Visibility.Hidden;

            ptc.tbWaterInfo.Visibility = Visibility.Hidden;

            ptc.rctElectric.Visibility = Visibility.Hidden;

            ptc.lblElectric.Visibility = Visibility.Hidden;

            ptc.lblPropertyName.Content = Engine.gameBoard.properties[index].PropertyName;

            ptc.rctPropertyCardColor.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(Engine.gameBoard.properties[index].CardColor));

            ptc.lblPropertyRent.Content = Engine.gameBoard.properties[index].BaseRent;

            ptc.lblColorSetRent.Content = Engine.gameBoard.properties[index].ColorSetRent;

            ptc.lblOneHouseRent.Content = Engine.gameBoard.properties[index].House1Rent;

            ptc.lblTwoHouseRent.Content = Engine.gameBoard.properties[index].House2Rent;

            ptc.lblThreeHouseRent.Content = Engine.gameBoard.properties[index].House3Rent;

            ptc.lblFourHouseRent.Content = Engine.gameBoard.properties[index].House4Rent;

            ptc.lblHotelRent.Content = Engine.gameBoard.properties[index].HotelRent;

            ptc.lblHouseCost.Content = Engine.gameBoard.properties[index].HouseCost;

            ptc.lblHotelCost.Content = Engine.gameBoard.properties[index].HotelCost;

            ptc.lblPropertyCost.Content = Engine.gameBoard.properties[index].BuyPrice;

            ptc.lblOwner.Content += Engine.gameBoard.properties[index].Owner;

            ptc.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //if (Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner.Contains("Bank"))
            //{
            //    ptc.btnPay.IsEnabled = false;
            //    ptc.btnBuy.IsEnabled = true;
            //}
            //else
            //{
            //    ptc.btnBuy.IsEnabled = false;
            //    ptc.btnPay.IsEnabled = true;
            //}



            //Shows the card

            ptc.ShowDialog();

        }

        /// <summary>
        /// Display Community Chest Card With Random Value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommunityChest_Click(object sender, EventArgs e)

        {

            int ccn = RNG.Next(0, 17);

            Button btn = (Button)sender;

            CommunityChestCard chest = new CommunityChestCard();

            chest.tbChestInfo.Text = Engine.gameBoard.ActionCards[ccn].ActionCardText;

            chest.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            chest.ShowDialog();

            DoAction(Engine.gameBoard.ActionCards[ccn].ActionCardCase);

            CheckGameStatus();

        }

        /// <summary>
        /// Income Tax Event Handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncomeTax_Click(object sender, EventArgs e)

        {

            Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= 200;

            UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid $200 For Income Tax");

            fillPlayerInfo();

            CheckGameStatus();

        }

        private void btnLuxurayTax_Click(object sender, EventArgs e)

        {

            Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= 75;

            UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid $75 For Luxuray Tax");

            fillPlayerInfo();

            CheckGameStatus();

        }

        /// <summary>
        /// Even Handle For RailRoad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRailRoad_Click(object sender, EventArgs e)

        {

            Button btn = (Button)sender;

            int index = Convert.ToInt16(btn.Tag);

            RailRoadCard railCard = new RailRoadCard();

            railCard.lblRailName.Content = Engine.gameBoard.properties[index].PropertyName;

            railCard.lblCost.Content = Engine.gameBoard.properties[index].BuyPrice;

            railCard.lblOwner.Content = "Owner: " + Engine.gameBoard.properties[index].Owner;

            railCard.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            railCard.ShowDialog();

        }

        /// <summary>
        /// Displays Chance Card With Random Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChanceCard_Click(object sender, EventArgs e)

        {

            int ccn = RNG.Next(18, 32);

            ChanceCard chance = new ChanceCard();

            chance.tbChanceInfo.Text = Engine.gameBoard.ActionCards[ccn].ActionCardText;

            chance.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            chance.ShowDialog();

            DoAction(Engine.gameBoard.ActionCards[ccn].ActionCardCase);

        }

        /// <summary>
        /// Event Handle For Jail Tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJail_Click(object sender, EventArgs e)

        {
            Jail j = new Jail();

            j.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            j.ShowDialog();

        }

        /// <summary>
        /// Even Handle For Utility.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUtility_Click(object sender, EventArgs e)

        {
            if(Engine.gameBoard.locations[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Name.Contains("Water"))
            {

                Button btn = (Button)sender;

                int index = Convert.ToInt16(btn.Tag);

                PropertyCard water = new PropertyCard();

                water.lblUtilityOwner.Content = "Owner: " + Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner;

                water.lblPropertyName.Visibility = Visibility.Hidden;

                water.lblTitleDeed.Visibility = Visibility.Hidden;

                water.rctPropertyCardColor.Visibility = Visibility.Hidden;

                water.lblPropertyRent.Visibility = Visibility.Hidden;

                water.lblColorSetRent.Visibility = Visibility.Hidden;

                water.lblOneHouseRent.Visibility = Visibility.Hidden; ;

                water.lblTwoHouseRent.Visibility = Visibility.Hidden;

                water.lblThreeHouseRent.Visibility = Visibility.Hidden;

                water.lblFourHouseRent.Visibility = Visibility.Hidden;

                water.lblHotelRent.Visibility = Visibility.Hidden;

                water.lblHouseCost.Visibility = Visibility.Hidden;

                water.lblHotelCost.Visibility = Visibility.Hidden;

                water.lblPropertyCost.Content = Engine.gameBoard.properties[index].BuyPrice;

                water.lblOwner.Visibility = Visibility.Hidden;

                water.rctWaterWorks.Visibility = Visibility.Visible;

                water.rctElectric.Visibility = Visibility.Hidden;

                water.lblElectric.Visibility = Visibility.Hidden;

                water.btnPay.Click += UtilityPay_Click;

                water.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                //if (Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner.Contains("Bank"))
                //    water.btnPay.IsEnabled = false;
                //else
                //    water.btnBuy.IsEnabled = false;

                water.ShowDialog();

            }
            else
            {
                //display electric
                Button btn = (Button)sender;

                int index = Convert.ToInt16(btn.Tag);

                PropertyCard electric = new PropertyCard();

                electric.lblPropertyName.Visibility = Visibility.Hidden;

                electric.lblUtilityOwner.Content = "Owner: " + Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner;

                electric.lblTitleDeed.Visibility = Visibility.Hidden;

                electric.rctPropertyCardColor.Visibility = Visibility.Hidden;

                electric.lblWaterWorks.Visibility = Visibility.Hidden;

                electric.lblPropertyRent.Visibility = Visibility.Hidden;

                electric.lblColorSetRent.Visibility = Visibility.Hidden;

                electric.lblOneHouseRent.Visibility = Visibility.Hidden; ;

                electric.lblTwoHouseRent.Visibility = Visibility.Hidden;

                electric.lblThreeHouseRent.Visibility = Visibility.Hidden;

                electric.lblFourHouseRent.Visibility = Visibility.Hidden;

                electric.lblHotelRent.Visibility = Visibility.Hidden;

                electric.lblHouseCost.Visibility = Visibility.Hidden;

                electric.lblHotelCost.Visibility = Visibility.Hidden;

                electric.lblPropertyCost.Content = Engine.gameBoard.properties[index].BuyPrice;

                electric.lblOwner.Visibility = Visibility.Hidden;

                electric.rctWaterWorks.Visibility = Visibility.Hidden;

                electric.rctElectric.Visibility = Visibility.Visible;

                electric.btnPay.Click += UtilityPay_Click;

                electric.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                //if (Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner.Contains("Bank"))
                //    electric.btnPay.IsEnabled = false;
                //else
                //    electric.btnBuy.IsEnabled = false;

                electric.ShowDialog();
            }

        }

        /// <summary>
        /// Moves Player Based On Dice Values
        /// </summary>
        /// <param name="value">The Value Of Dice</param>
        private void MovePlayer(int value)

        {

            //ADDS THE VALUE OF BOTH DICE TO THE PLAYERS CURRENT LOCATION

             Engine.gameBoard.players[Engine.currentTurn].CurrentLocation += value;



            //ADDS 1 TO VALUE. THIS IS USED FOR TESTING ONLY

            //Engine.gameBoard.players[Engine.currentTurn].CurrentLocation++;



            //RESETS THE PLAYERS LOCATION IF THEY ADVANCE ALL THE WAY AREOUND THE BOARD

            if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation >= 40)

            {

                Engine.gameBoard.players[Engine.currentTurn].CurrentLocation -= 40;

                UpdatePlayerEvents("You Passed Go!\r\n" + Engine.gameBoard.players[Engine.currentTurn].Name + " Collect $200");

                Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

            }

            else if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation == 10)

            {

                UpdatePlayerEvents("Welcome To Jail!");

            }

            else if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation == 20)

            {

                UpdatePlayerEvents("Enjoy Your Free Parking");

            }

            else if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation == 30)

            {

                UpdatePlayerEvents("Go To Jail!\r\nDo Not Pass Go! Do Not Collect $200");

                Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 10;

                Engine.gameBoard.players[Engine.currentTurn].IsInJail = true;

            }

            //SENDS THE PLAYERS LOCATION. VALUE WILL BE BETWEEN 0-39

            UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);


        }

        /// <summary>
        /// Displays Updated Map After Player Rolls
        /// </summary>
        /// <param name="spot">The Spot The Player Will Be Displayed</param>
        private void UpdateGameBoard(int spot)

        {

            int tagValues = 0;

            if(Engine.currentTurn == 0)

            pLocations[0] = setPlayerValue(spot);

            if (Engine.currentTurn == 1)

            pLocations[1] = setPlayerValue(spot);

            foreach (Button b in grdBoard.Children)

            {

                if (b.Name == pLocations[0] || b.Name == pLocations[1])

                {
                    if(b.Name == pLocations[0])
                    {

                    b.Content = Engine.gameBoard.players[0].Name;

                    b.Background = new SolidColorBrush(Colors.Red);

                    if(Engine.gameBoard.players[0].TurnOrder == Engine.currentTurn)

                        b.IsEnabled = true;


                    }

                    else
                    {

                        b.Content = Engine.gameBoard.players[1].Name;

                        b.Background = new SolidColorBrush(Colors.Blue);

                        if (Engine.gameBoard.players[1].TurnOrder == Engine.currentTurn)

                            b.IsEnabled = true;

                    }

                }

                else

                {

                    b.Content = Engine.gameBoard.properties[tagValues].PropertyName;

                    b.IsEnabled = false;

                }

                tagValues++;

            }

        }

        /// <summary>
        /// Sets The Value Of Player
        /// </summary>
        /// <param name="spot">Value Needed To Get Index Of Array</param>
        /// <returns>Value Of testValues Index</returns>
        private String setPlayerValue(int spot)
        {
            string location;
            if (Engine.currentTurn == 0)
            {
                location = "btn" + Engine.gameBoard.testValues[spot];
                return location;
            }
            else if (Engine.currentTurn == 1)
            {
                location = "btn" + Engine.gameBoard.testValues[spot];
                return location;
            }
            else
                MessageBox.Show("Error In Turn");
            return "Error";

        }

        /// <summary>
        /// Pays The Owner Of Current Property Rent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnPay_Click(object sender, RoutedEventArgs e)

        {

                int desired = getPropertyIndex(Engine.gameBoard.locations.IndexOf(Engine.gameBoard.locations[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation]));

            if (Engine.gameBoard.properties[desired].Owner.Contains("Bank"))

            {

                UpdatePlayerEvents("This Property Is Owned By The Bank");

            }

            else

            {


            //takes money from player who is paying

            Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= Engine.gameBoard.properties[desired].BaseRent;


            //Finds the owner of the property

            int receiver = GetPlayer(Engine.gameBoard.properties[desired].Owner);



            //needs to be changed to a method to get amount if houses or hotels, or color set

            int amount = Engine.gameBoard.properties[desired].BaseRent;



            string textToSend = Engine.gameBoard.players[Engine.currentTurn].Name + " Paid $" +

                Engine.gameBoard.properties[desired].BaseRent.ToString() +

                " to " + Engine.gameBoard.players[receiver].Name + " For Rent.";



            Engine.gameBoard.players[receiver].AvailableMoney += amount;



            UpdatePlayerEvents(textToSend);

            }

            fillPlayerInfo();

        }

        /// <summary>
        /// Buys Current Property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnBuy_Click(object sender, RoutedEventArgs e)

        {

            if(Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner.Contains("Bank"))
            {


            int desired = getPropertyIndex(Engine.gameBoard.locations.IndexOf(Engine.gameBoard.locations[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation]));

            Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= Engine.gameBoard.properties[desired].BuyPrice;

            Engine.gameBoard.properties[desired].Owner = Engine.gameBoard.players[Engine.currentTurn].Name;

                Engine.gameBoard.players[Engine.currentTurn].nProperties++;

            string textToSend = Engine.gameBoard.players[Engine.currentTurn].Name + " Bought " +

                    Engine.gameBoard.locations[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Name + "!";

            UpdatePlayerEvents(textToSend);

            }

            else
            {
                UpdatePlayerEvents("This Property Is Already Owned");
            }


            fillPlayerInfo();

            CheckGameStatus();

        }

        /// <summary>
        /// A Horrible Method That Gets The Index A Property Based On The Player's Location
        /// 
        /// this is done poorly. it should be reworked, but for now it works...
        /// </summary>
        /// <param name="cLocation">Players Current Location</param>
        /// <returns>Property Based On Player Location</returns>
        private int getPropertyIndex(int cLocation)
        {

            //case = location 0-go 
            //return = spot in property list 0 - go

            switch(cLocation)
            {
                case 0: 
                    return 0;
                case 1:
                    return 1;
                case 2: 
                    return 2; 
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 5; 
                case 6: 
                    return 6; 
                case 7:
                    return 7; 
                case 8:
                    return 8;
                case 9:
                    return 9;
                case 10:
                    return 10;
                case 11:
                    return 12;
                case 12:
                    return 14;
                case 13:
                    return 16;
                case 14:
                    return 18;
                case 15:
                    return 20;
                case 16:
                    return 22;
                case 17:
                    return 24;
                case 18:
                    return 26;
                case 19:
                    return 28;
                case 20:
                    return 39;
                case 21:
                    return 38;
                case 22:
                    return 37;
                case 23:
                    return 36;
                case 24:
                    return 35;
                case 25:
                    return 34;
                case 26:
                    return 33;
                case 27:
                    return 32;
                case 28:
                    return 31;
                case 29:
                    return 30;
                case 30:
                    return 29;
                case 31:
                    return 27;
                case 32:
                    return 25;
                case 33:
                    return 23;
                case 34:
                    return 21;
                case 35:
                    return 19;
                case 36:
                    return 17;
                case 37:
                    return 15;
                case 38:
                    return 13;
                case 39:
                    return 11;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Finds Owner Of Current Property
        /// </summary>
        /// <param name="pOwner"></param>
        /// <returns>Property Owner</returns>
        private int GetPlayer(string pOwner)

        {

            foreach (Player player in Engine.gameBoard.players)

            {

                if (player.Name == pOwner)

                {

                    return player.TurnOrder;

                }

            }

            return 0;

        }

        /// <summary>
        /// Logic For Chance And Chest Cards !!NEEDS WORK!! Moves Player To Incorrect Location
        /// </summary>
        /// <param name="ACN">The Case Number Assigned To Each Card</param>
        public void DoAction(int ACN)

        {

            string text;

            switch (ACN)

            {

                //CHANCE CARDS

                case 1: //Advance to go

                    Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 0;

                    text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Go";

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    UpdatePlayerEvents(text);

                    break;

                case 2: //advance to illinois

                    if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation < 23)

                    {

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 24;

                    }

                    else

                    {

                        Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 24;

                    }

                    text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Illinois Ave";

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    UpdatePlayerEvents(text);

                    break;

                case 3: //advacne to st. charles place

                    if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation < 10)

                    {

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 11;

                    }

                    else

                    {

                        Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 11;

                    }

                    text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To St. Charles Place";

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    UpdatePlayerEvents(text);

                    break;

                case 4: //nearest utility

                    if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation < 11) //past go, but not past electric co

                    {

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 12;

                        UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                        thrownDice = true;

                        //payment

                        text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Electric Co";

                        UpdatePlayerEvents(text);

                        UtilityActionCardPay(RNG.Next(1, 7), RNG.Next(1, 7));

                    }

                    else if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation > 11 || Engine.gameBoard.players[Engine.currentTurn].CurrentLocation < 27)//past electric co, but before water works

                    {

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 28;

                        UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                        thrownDice = true;

                        text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Water Works";

                        UpdatePlayerEvents(text);

                        //payment

                        UtilityActionCardPay(RNG.Next(1, 7), RNG.Next(1, 7));

                    }

                    else if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation > 27)//after water works and passes go

                    {

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 12;

                        Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

                        text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Electric Co";

                        UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                        UpdatePlayerEvents(text);

                        //payment

                        UtilityActionCardPay(RNG.Next(1, 7), RNG.Next(1, 7));

                    }

                    break;

                case 5: //nearest railroad

                    if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation > 34)// before go

                    {

                        Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 5;

                        //payment

                        text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Reading Railroad";

                        UpdatePlayerEvents(text);

                    }

                    else if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation > 4 && Engine.gameBoard.players[Engine.currentTurn].CurrentLocation < 9)//after first railroad, before second

                    {

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 15;

                        //payment

                        text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Pennsylvania Railroad";

                        UpdatePlayerEvents(text);

                    }

                    else if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation > 19 && Engine.gameBoard.players[Engine.currentTurn].CurrentLocation < 29)//after second railroad

                    {

                        Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 25;

                        //payement

                        text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To B&O Railroad";

                        UpdatePlayerEvents(text);

                    }

                    //SHORT LINE WILL NEVER BE HIT. THERE IS NOT CHANCE CARD AFTER B&O AND BEFORE SHORT LINE

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    break;

                case 6://paid $50

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 50;

                    text = Engine.gameBoard.players[Engine.currentTurn].Name + " Got $50";

                    UpdatePlayerEvents(text);

                    break;

                case 7: //Gives a GOJF card

                    Engine.gameBoard.players[Engine.currentTurn].JailCard++;

                    Engine.gameBoard.players[Engine.currentTurn].HasJailCard = true;

                    text = Engine.gameBoard.players[Engine.currentTurn].Name + " Is Now Able To Commit A Crime";

                    UpdatePlayerEvents(text);

                    break;

                case 8: //back three spaces

                    Engine.gameBoard.players[Engine.currentTurn].CurrentLocation -= 3;

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    text = Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To " + Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].PropertyName;

                    UpdatePlayerEvents(text);

                    break;

                case 9: //go to jail

                    Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 10;

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    Engine.gameBoard.players[Engine.currentTurn].IsInJail = true;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Was Sent To Jail!");

                    break;

                case 10: // property repair

                    //need to do logic or possibly remove this card. itll be a bitch :)

                    MessageBox.Show("Our Dev hasn't worked the logic\r\nfor this card.\r\nLucky you!");

                    break;

                case 11: //poor tax

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= 15;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid A Poor Tax Of $15");

                    break;

                case 12: //go to reading railroad

                    if (Engine.gameBoard.players[Engine.currentTurn].CurrentLocation > 4)

                    {

                        Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

                    }

                    Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 5;

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To The Reading Railroad");

                    break;

                case 13: //go to boardwalk

                    Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 39;

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To Boardwalk");

                    break;

                case 14: //pay each player $50

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= (Engine.gameBoard.players.Count * 50);

                    int i = 0;

                    foreach (Player p in Engine.gameBoard.players)

                    {

                        p.AvailableMoney += 50;

                    }

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid Each Player $50");

                    break;

                case 15: //get $150

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 150;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $150");

                    break;



                //CHEST CARDS!!



                case 16: //move to go

                    Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 0;

                    //might need to remove if money increase by 400

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Moved To GO");

                    break;

                case 17: //get $200

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 200;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $200");

                    break;

                case 18: // fee -$50

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= 50;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid A Fee Of $50");

                    break;

                case 19: //get $50

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 50;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $50");

                    break;

                case 20: //Get GOJF card

                    Engine.gameBoard.players[Engine.currentTurn].JailCard++;

                    Engine.gameBoard.players[Engine.currentTurn].HasJailCard = true;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Is Now Free To Commit A Crime");

                    break;

                case 21: //go to jail

                    Engine.gameBoard.players[Engine.currentTurn].CurrentLocation = 10;

                    UpdateGameBoard(Engine.gameBoard.players[Engine.currentTurn].CurrentLocation);

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Was Sent To Jail");

                    Engine.gameBoard.players[Engine.currentTurn].IsInJail = true;

                    break;

                case 22: //get $50 from each player

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += (Engine.gameBoard.players.Count * 50);

                    for (i = 0; i < Engine.gameBoard.players.Count; i++)

                    {

                        Engine.gameBoard.players[i].AvailableMoney -= 50;

                    }

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid Each Player $50");

                    break;

                case 23: //get $100
                    
                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 100;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $100");

                    break;

                case 24: //collect $20

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 20;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $20");

                    break;

                case 25: //get $10 from each player

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += (Engine.gameBoard.players.Count * 10);

                    for (i = 0; i < Engine.gameBoard.players.Count; i++)

                    {

                        Engine.gameBoard.players[i].AvailableMoney -= 10;

                    }

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + "Took $10 From Everyone");

                    break;

                case 26: //get $100

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 100;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $100");

                    break;

                case 27://pay $50

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= 50;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Lost $50");

                    break;

                case 28: //pay $50

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= 50;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid $50");

                    break;

                case 29: //get $25

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 25;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $25");

                    break;

                case 30: //House repair

                    //need to do logic or possibly remove this card. itll be a bitch :)

                    MessageBox.Show("Our Dev hasn't worked the logic for this card.\r\nLucky you!");

                    break;

                case 31: //get $15

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 15;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $15");

                    break;

                case 32: //get $100

                    Engine.gameBoard.players[Engine.currentTurn].AvailableMoney += 100;

                    UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Got $100");

                    break;

                default: //default

                    MessageBox.Show("Nothing Happened");

                    break;

            }

            fillPlayerInfo();

            CheckGameStatus();


        }

        /// <summary>
        /// Logic For Utilities
        /// </summary>
        /// <param name="v1">Value Of First Die</param>
        /// <param name="v2">Value Of Second Die</param>
        private void UtilityActionCardPay(int v1, int v2)

        {

            if (Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner != " Bank")

            {

                //get owner of prperty and pay  --> ((v1 + v2) * 10)

                int receiver = GetPlayer(Engine.gameBoard.properties[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation].Owner);

                string text = "The Dice Were Thrown!\r\nThe value was " + (v1 + v2).ToString() + "!\r\n" + Engine.gameBoard.players[Engine.currentTurn].Name +

                    " Paid " + Engine.gameBoard.players[receiver] + " " + ((v1 + v2) * 10).ToString() + "!";

                UpdatePlayerEvents(text);

                Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= ((v1 + v2) * 10);

                Engine.gameBoard.players[receiver].AvailableMoney += ((v1 + v2) * 10);

                thrownDice = false;

                CheckGameStatus();

            }

            else

            {

                UpdatePlayerEvents("You Are Free To Buy This Utility");

                thrownDice = false;

            }

        }

        /// <summary>
        /// Ends Current Players Turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            UpdateTurnOrder();

            CheckGameStatus();

        }

        private void UtilityPay_Click(object sender, RoutedEventArgs e)
        {

            int desired = getPropertyIndex(Engine.gameBoard.locations.IndexOf(Engine.gameBoard.locations[Engine.gameBoard.players[Engine.currentTurn].CurrentLocation]));

            int receiver = GetPlayer(Engine.gameBoard.properties[desired].Owner);

            int amount = 4 * (dieOne + dieTwo);

            Engine.gameBoard.players[receiver].AvailableMoney += amount;

            Engine.gameBoard.players[Engine.currentTurn].AvailableMoney -= amount;

            UpdatePlayerEvents(Engine.gameBoard.players[Engine.currentTurn].Name + " Paid $" +

                Engine.gameBoard.properties[desired].BaseRent.ToString() +

                " to " + Engine.gameBoard.players[receiver].Name + " For Rent.");

            CheckGameStatus();

        }

        private void CheckGameStatus()

        {

            foreach (Player player in Engine.gameBoard.players)

            {

                if(player.AvailableMoney < 0)

                {

                    IsGameOver = true;

                    UpdatePlayerEvents(player.Name + " Has Run Out Of Money! They Have Lost!");

                }

            }

        }


    }

}


