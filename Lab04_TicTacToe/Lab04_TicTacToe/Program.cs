using Lab04_TicTacToe.Classes;
using System;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PlayGame()
        {
            Console.Write("Welcome to Tic-Tac-Toe!\n" +
                "\n" +
                "Please enter Player 1's name: ");
            string playerOneInput = Console.ReadLine();

            Console.Write("\n" +
                "Please enter Player 2's name: ");
            string playerTwoInput = Console.ReadLine();

            Player playerOne = new Player
            {
                Name = playerOneInput,
                Marker = "X",
                IsTurn = true
            };

            Player playerTwo = new Player
            {
                Name = playerTwoInput,
                Marker = "O",
                IsTurn = false
            };



            // TODO: Setup your game here. Create an introduction. 
            // Create your players, and instantiate your Game class. 
            // output to the console the winner
        }
    }
}
