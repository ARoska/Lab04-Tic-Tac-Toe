using Lab04_TicTacToe.Classes;
using System;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            while (play == true)
            {
                play = PlayGame();
                Console.Clear();
            }
            Console.WriteLine("Bye!  Thanks for playing!");
            System.Threading.Thread.Sleep(1500);
        }

        static bool PlayGame()
        {
            string playAgainInput = "";

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
                IsTurn = true,
            };

            Player playerTwo = new Player
            {
                Name = playerTwoInput,
                Marker = "O",
                IsTurn = false
            };

            Game game = new Game(playerOne, playerTwo);

            Player winner = game.Play();

            if (winner != null)
            {
                Console.WriteLine($"{winner.Name} wins!\n" +
                "\n" +
                "Enter \"yes\" to play again or \"no\" to exit.");
                playAgainInput = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("It's a draw...\n" +
                    "\n" +
                    "Enter \"yes\" to play again or \"no\" to exit.");
                playAgainInput = Console.ReadLine();

            }

            if (playAgainInput.ToLower() == "y" || playAgainInput.ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // TODO: Setup your game here. Create an introduction. 
        // Create your players, and instantiate your Game class. 
        // output to the console the winner
    }
}

