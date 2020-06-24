using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly
{
   public class Property
    {
        private String _PropertyName;
        private String _CardColor;
        private int _BuyPrice;
        private int _BaseRent;
        private int _ColorSetRent;
        private int _House1Rent;
        private int _House2Rent;
        private int _House3Rent;
        private int _House4Rent;
        private int _HotelRent;
        private int _HouseCost;
        private int _HotelCost;
        private int _ListLocation;
        private String _Owner;

        public String Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        public int ListLocation
        {
            get { return _ListLocation; }
            set { _ListLocation = value; }
        }


        /// <summary>
        /// The name of the property
        /// </summary>
        public String PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; }
        }
        /// <summary>
        /// The background of the property card
        /// Example format: #FFFCFCFC
        /// </summary>
        public String CardColor
        {
            get { return _CardColor; }
            set { _CardColor = value; }
        }
        /// <summary>
        /// The buy price
        /// </summary>
        public int BuyPrice
        {
            get { return _BuyPrice; }
            set { _BuyPrice = value; }
        }
        /// <summary>
        /// The base rent
        /// </summary>
        public int BaseRent
        {
            get { return _BaseRent; }
            set { _BaseRent = value; }
        }
        /// <summary>
        /// The price of rent after all properties of one color are owned
        /// </summary>
        public int ColorSetRent
        {
            get { return _ColorSetRent; }
            set { _ColorSetRent = value; }
        }
        /// <summary>
        /// Rent with one house
        /// </summary>
        public int House1Rent
        {
            get { return _House1Rent; }
            set { _House1Rent = value; }
        }
        /// <summary>
        /// Rent with two houses
        /// </summary>
        public int House2Rent
        {
            get { return _House2Rent; }
            set { _House2Rent = value; }
        }
        /// <summary>
        /// Rent with three houses
        /// </summary>
        public int House3Rent
        {
            get { return _House3Rent; }
            set { _House3Rent = value; }
        }
        /// <summary>
        /// Rent with four houses
        /// </summary>
        public int House4Rent
        {
            get { return _House4Rent; }
            set { _House4Rent = value; }
        }
        /// <summary>
        /// Rent with a hotel
        /// </summary>
        public int HotelRent
        {
            get { return _HotelRent; }
            set { _HotelRent = value; }
        }
        /// <summary>
        /// The cost to the player to buy a house
        /// </summary>
        public int HouseCost
        {
            get { return _HouseCost; }
            set { _HouseCost = value; }
        }
        /// <summary>
        /// The cost to the player to buy a hotel
        /// Note: four houses must be owned before buying a hotel
        /// </summary>
        public int HotelCost
        {
            get { return _HotelCost; }
            set { _HotelCost = value; }
        }
        /// <summary>
        /// Overloaded constructor for properties
        /// </summary>
        /// <param name="Name">Name Of Property</param>
        /// <param name="CardColor">Color Of Property</param>
        /// <param name="BuyPrice">Base Price of </param>
        /// <param name="BaseRent"></param>
        /// <param name="ColorSetRent"></param>
        /// <param name="House1Rent"></param>
        /// <param name="House2Rent"></param>
        /// <param name="House3Rent"></param>
        /// <param name="House4Rent"></param>
        /// <param name="HotelRent"></param>
        /// <param name="HouseCost"></param>
        /// <param name="HotelCost"></param>
        public Property(String Name, String CardColor, int BuyPrice, int BaseRent, int ColorSetRent, 
            int House1Rent, int House2Rent, int House3Rent, int House4Rent, int HotelRent, int HouseCost, int HotelCost, int ListLocation, String Owner)
        {
            _PropertyName = Name;
            _CardColor = CardColor;
            _BuyPrice = BuyPrice;
            _BaseRent = BaseRent;
            _ColorSetRent = ColorSetRent;
            _House1Rent = House1Rent;
            _House2Rent = House2Rent;
            _House3Rent = House3Rent;
            _House4Rent = House4Rent;
            _HotelRent = HotelRent;
            _HouseCost = HouseCost;
            _HotelCost = HotelRent;
            _ListLocation = ListLocation;
            _Owner = Owner;
        }

        public Property(String Name, int ListLocation)
        {
            _PropertyName = Name;
            _ListLocation = ListLocation;
        }

        public Property(String Name)
        {
            _PropertyName = Name;
        }
    }
}
