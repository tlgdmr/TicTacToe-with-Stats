using System;

namespace TicTacToe
{
    class Program
    {
        private static string _player1Name;
        private static string _player2Name;

        public static void Main(string[] args)
        {
            InitGame();
        }

        /// <summary>
        /// Menu Bar section, when the project start.
        /// </summary>
        public static void InitGame()
        {
            Console.Clear();

            Console.WriteLine("1 = Start the Game");
            Console.WriteLine("2 = About The Author");
            Console.WriteLine("3 = Show Stats");
            Console.WriteLine("4 = Show Stats for Single Player");
            Console.WriteLine("5 = Exit");

            string choose = Console.ReadLine();

            if (choose == "1")
            {
                bool checkPlayerNames = AskPlayerNames();

                if (checkPlayerNames)
                {
                    GameEngine.StartGame(_player1Name, _player2Name);
                }

                return;
            }
            else if (choose == "2")
            {
                Author.DisplayAuthorInfo();
                return;
            }
            else if (choose == "3")
            {
                Stats.ShowStats();
                return;
            }
            else if (choose == "4")
            {
                Stats.ShowPlayerStats();
                return;
            }
            else if (choose == "5")
            {
                QuitGame.Exit();
                return;
            }
        }

        public static bool AskPlayerNames()
        {
            bool isContinue = true;

            Console.Clear();

            Console.WriteLine("What is the Player 1 name?");

            string player1Name = Console.ReadLine();

            if (String.IsNullOrEmpty(player1Name))
            {
                isContinue = false;

                Console.WriteLine("Player 1 name cannot be empty!");
            }
            else
            {
                _player1Name = player1Name;
            }

            Console.WriteLine("What is the Player 2 name?");

            string player2Name = Console.ReadLine();

            if (String.IsNullOrEmpty(player2Name))
            {
                isContinue = false;

                Console.WriteLine("Player 2 name cannot be empty!");
            }
            else
            {
                _player2Name = player2Name;
            }

            return isContinue;
        }
    }
}
