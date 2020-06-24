using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
   static class Engine
    {
        private static GameBoard _gameBoard;
        public static int currentTurn = 0;
        public static int turns;

        public static GameBoard gameBoard
        {
            get { return _gameBoard; }
            set { _gameBoard = value; }
        }

        public static void StartGame()
        {
            _gameBoard = new GameBoard();
        }

        public static void Pay()
        {
            
        }
        /// <summary>
        /// Increases Turn Order By 1. Will Cycle Through Players
        /// </summary>
        public static void UpdateTurnOrder()
        {
           // Engine.
            currentTurn++;
            if (currentTurn >= turns)
                currentTurn = 0;
        }

    }
}
