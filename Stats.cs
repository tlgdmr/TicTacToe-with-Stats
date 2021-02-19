using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TicTacToe
{
    public class Stats
    {
        public static string fileName = "Stats.txt";

        public static void InsertStats(string winner)
        {
            

            try
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{winner}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ResetStats()
        {
            File.Delete(fileName);
        }

        public static void ShowStats()
        {
            List<string> userList = new List<string>();

            using (StreamReader _reader = File.OpenText(fileName))
            {
                string line = String.Empty;

                while ((line = _reader.ReadLine()) != null)
                {
                    userList.Add(line); // line by line read
                }
            }

            Console.Clear();

            for (int i = 0; i < userList.Count; i++)
            {
                Console.WriteLine($"Game {i + 1} winner: {userList[i]}");
            }

            Console.WriteLine("");
            Console.WriteLine("Go to Main Menu! Press: M");
            string yesNo = Console.ReadLine().ToLower();

            if (yesNo == "m")
                Program.InitGame();

        }

        public static void ShowPlayerStats()
        {
            Console.Clear();

            Console.WriteLine("What is the player name?");

            string name = Console.ReadLine();

            if (!String.IsNullOrEmpty(name))
            {
                List<string> userList = new List<string>(); int playerWinCount = 0;

                using (StreamReader _reader = File.OpenText(fileName))
                {
                    string line = String.Empty;

                    while ((line = _reader.ReadLine()) != null)
                    {
                        if (name.ToLower() == line.ToLower())
                        {
                            playerWinCount++;
                        }

                        userList.Add(line); // line by line read
                    }
                }

                int gameCount = userList.Count;

                float result = ((float)playerWinCount / (float)gameCount) * 100;

                double winRatio = Math.Round(result, 2);

                Console.WriteLine("");
                Console.WriteLine($"Here {name}'s Statistics");
                Console.WriteLine("");
                Console.WriteLine($"Total game: {gameCount}");
                Console.WriteLine($"Total player win count: {playerWinCount}");
                Console.WriteLine($"Win ratio: %{winRatio}");

                Console.WriteLine("");
                Console.WriteLine("Go to Main Menu! Press: M");
                string yesNo = Console.ReadLine().ToLower();

                if (yesNo == "m")
                    Program.InitGame();
            }
            else
            {
                Console.WriteLine("Player name cannot be empty or null.");
            }
        }
    }
}
