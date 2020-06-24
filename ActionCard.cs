using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class ActionCard
    {
        private String _ActionCardText;
        private int _ActionCardCase;

        /// <summary>
        /// The case number given to each card
        /// </summary>
        public int ActionCardCase
        {
            get { return _ActionCardCase; }
            set { _ActionCardCase = value; }
        }
        /// <summary>
        /// The text givne to each community chest card
        /// </summary>
        public String ActionCardText
        {
            get { return _ActionCardText; }
            set { _ActionCardText = value; }
        }

        public ActionCard(String text, int chestCase)
        {
            _ActionCardText = ActionCardText;
            _ActionCardCase = ActionCardCase;
        }
    }
}
