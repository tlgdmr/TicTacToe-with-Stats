using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Author
    {
        //About the authour section.
        public static void DisplayAuthorInfo()
        {
            Console.Clear();
            Console.WriteLine("************************************");
            Console.WriteLine("Hi I am Tolga. I have been learning C# and creating new games.Enjoy the game :)");
            Console.WriteLine("************************************");

            //Get back to the main menu section.
            Console.WriteLine("Enter 'M' get back to the Main Menu");

            if (Console.ReadLine().ToLower() == "m")
                Program.Main(null);

        }
    }
}
