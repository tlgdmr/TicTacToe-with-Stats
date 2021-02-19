using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameEngine
    {
        //Track the game round to determine if the game is over.
        private static int gameRound = 0;

        public static string _player1Name;
        public static string _player2Name;

        //Check the all options to determine which player win.
        private static int CheckWin(char[] arr)
        {
            if (arr[0] == arr[1] && arr[1] == arr[2])
            {
                return 1;
            }
            else if (arr[3] == arr[4] && arr[4] == arr[5])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            else if (arr[0] == arr[3] && arr[3] == arr[6])
            {
                return 1;
            }
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[0] == arr[4] && arr[4] == arr[8])
            {
                return 1;
            }
            else if (arr[2] == arr[4] && arr[4] == arr[6])
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Starts Game Engine
        /// </summary>
        public static void StartGame(string player1Name, string player2Name)
        {
            _player1Name = player1Name; _player2Name = player2Name;

            //Created a variable to store status of the game.
            bool gameStatus = false; gameRound = 0;

            //Created a variable to store current player
            int currentPlayer = 0;

            //Created a char array to draw the default board.
            char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do
            {
                //Clear the console for every round
                Console.Clear();

                //Set the current player
                currentPlayer = GetNextPlayer(currentPlayer);

                //Shows the status of the game
                HeadsUpDisplay(currentPlayer);

                //Created a function that takes the char array to draw the updated board.
                DrawGameboard(gameMarkers);

                //Created a function that takes the current player and gameMarkers to do logic of the game.
                PlayEngine(gameMarkers, currentPlayer);

                //Check the game status.
                gameStatus = isGameOver();

                int status = CheckWin(gameMarkers);

                //Status 1 means If the player win.
                //Show the player who win.
                if (status == 1)
                {
                    Console.Clear();

                    HeadsUpDisplay(currentPlayer);
                    DrawGameboard(gameMarkers);

                    string currentPlayerName = currentPlayer == 1 ? _player1Name : _player2Name;

                    Console.WriteLine("Game Over!");
                    Console.WriteLine($"Current player {currentPlayerName} won this game!");

                    Stats.InsertStats(currentPlayerName);

                    //Get back to the main menu when the player win.
                    Console.WriteLine("Get back to the main menu, press M");

                    string choose = Console.ReadLine().ToLower();

                    if (choose == "m")
                    {
                        Program.InitGame();
                        return;
                    }

                    return;
                }

            } while (!gameStatus);

            Console.Clear();

            HeadsUpDisplay(currentPlayer);
            DrawGameboard(gameMarkers);

            //If the game is over.
            if (gameStatus)
            {
                Console.Clear();
                HeadsUpDisplay(currentPlayer);
                DrawGameboard(gameMarkers);

                Console.WriteLine("Game Over!");
                Console.WriteLine("The game ended in a draw!");

                //Get back to the main menu when the game is draw.
                Console.WriteLine("Get back to the main menu, press M");

                string choose = Console.ReadLine().ToLower();

                if (choose == "m")
                {
                    Program.InitGame();
                    return;
                }

            }
        }

        /// <summary>
        /// It checks if the game is over.
        /// </summary>
        /// <returns> true or false  </returns>
        private static bool isGameOver()
        {
            return gameRound == 9 ? true : false;
        }

        /// <summary>
        /// The logic of the game
        /// </summary>
        /// <param name="gameMarkers"></param>
        /// <param name="currentPlayer"></param>
        private static void PlayEngine(char[] gameMarkers, int currentPlayer)
        {
            bool notValidMove = true;
            do
            {
                if (int.TryParse(Console.ReadLine(), out int result) && (result > 0 && result < 10))
                {
                    char currentMarker = gameMarkers[result - 1];
                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Illegal move! Try again.");
                    }
                    else
                    {
                        gameMarkers[result - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;

                        gameRound++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select another placement.");
                }
            }
            while (notValidMove);

        }

        private static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }
            return 'X';
        }

        /// <summary>
        /// Getting the next player
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <returns>the current player</returns>
        private static int GetNextPlayer(int currentPlayer)
        {
            if (currentPlayer.Equals(1))
            {
                return 2;
            }

            return 1;
        }

        private static void DrawGameboard(char[] gameMarkers)
        {
            // Draw The Game Board 
            // Game Board Consists of 3 Rows and 3 Columns are numbered 1 through 9

            Console.WriteLine("///////////////////");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine($"// | {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} | //");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine($"// | {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} | //");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine($"// | {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} | //");
            Console.WriteLine("// +---+---+---+ //");
            Console.WriteLine("///////////////////");
            Console.WriteLine();

        }

        private static void HeadsUpDisplay(int currentPlayer)
        {
            // Provide Instruction
            // A Greeting 
            Console.WriteLine("Welcome to the Tic-Tac-Toe Game!");


            // Display Player Sign, Player 1 is X and Player 2 is O
            Console.WriteLine($"{_player1Name}: X");
            Console.WriteLine($"{_player2Name}: O");
            Console.WriteLine();

            string currentPlayerName = currentPlayer == 1 ? _player1Name : _player2Name;

            //  Who's turn is it ?
            // Instruct the User to Enter a Number Between 1 and 9
            Console.WriteLine($"Player {currentPlayerName} to move, select 1 through 9 from the game board");
            Console.WriteLine();
        }
    }
}
