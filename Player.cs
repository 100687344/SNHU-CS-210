using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        private String _Name;
        private int _Token;
        private int _TurnOrder;
        private int _AvailbleMoney;
        private List<Property> _OwnedProperties;
        private int _nProperties;
        private int _CurrentLocation;
        private bool _IsBankrupt;
        private bool _HasJailCard;
        private int _JailCard;
        private bool _IsInJail;

        public bool IsInJail
        {
            get { return _IsInJail; }
            set { _IsInJail = value; }
        }

        public int JailCard
        {
            get { return _JailCard; }
            set { _JailCard = value; }
        }

        public bool HasJailCard
        {
            get { return _HasJailCard; }
            set { _HasJailCard = value; }
        }

        public bool IsBankrupt
        {
            get { return _IsBankrupt; }
            set { _IsBankrupt = value; }
        }

        public int CurrentLocation
        {
            get { return _CurrentLocation; }
            set { _CurrentLocation = value; }
        }

        public List<Property> OwnedProperties
        {
            get { return _OwnedProperties; }
            set { _OwnedProperties = value; }
        }

        public int nProperties
        {
            get { return _nProperties; }
            set { _nProperties = value; }
        }

        public int AvailableMoney
        {
            get { return _AvailbleMoney; }
            set { _AvailbleMoney = value; }
        }

        public int TurnOrder
        {
            get { return _TurnOrder; }
            set { _TurnOrder = value; }
        }

        public int Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="name">Name of player</param>
        /// <param name="tkn">Token of player</param>
        /// <param name="turnOrder">Turn order for player</param>
        /// <param name="aMoney">Amount of money player has availble</param>
        /// <param name="pProperties">Properties Player Ownes</param>
        /// <param name="location">Location of player</param>
        /// <param name="bankrupt">Is the player bankrupt</param>
        /// <param name="jCard">Does the player have a jail free card</param>
        /// <param name="aJCards">Number of jail free cards a player has</param>
        public Player(String name, int tkn, int turnOrder, int aMoney, int pProperties, int location, bool bankrupt, bool jCard, int aJCards, bool inJail)
        {
            _Name = name;
            _Token = tkn;
            _TurnOrder = turnOrder;
            _AvailbleMoney = aMoney;
            _nProperties = pProperties;
            _CurrentLocation = location;
            bankrupt = false;
            jCard = false;
            _JailCard = aJCards;
            _OwnedProperties = null;
            inJail = false;
        }

        public Player(String name)
        {
            _Name = name;
        }
    }
}
