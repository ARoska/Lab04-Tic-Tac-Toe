using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    public class Player
    {
        /// <summary>
        /// Player's chosen name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// P1 is X and P2 will be O
        /// </summary>
        public string Marker { get; set; }

        /// <summary>
        /// Flag to determine if it is the user's turn
        /// </summary>
        public bool IsTurn { get; set; }

        /// <summary>
        /// Prompts the user for their move and then retruns the co-ordinates of that choice.
        /// </summary>
        /// <param name="board">Current board state.</param>
        /// <returns>Co-ordinates of the user's move.</returns>
        public Position GetPosition(Board board)
        {
            Position desiredCoordinate = null;
            while (desiredCoordinate is null)
            {
                Console.WriteLine("Please select a location:");
                Int32.TryParse(Console.ReadLine(), out int position);
                desiredCoordinate = PositionForNumber(position);
            }
            return desiredCoordinate;

        }

        /// <summary>
        /// Determinse the co-ordinates of a requested move.
        /// </summary>
        /// <param name="position">Number representing the usre's desired move.</param>
        /// <returns>Actual co-ordinates of the board space the user requested.</returns>
        public static Position PositionForNumber(int position)
        {
            switch (position)
            {
                case 1: return new Position(0, 0); // Top Left
                case 2: return new Position(0, 1); // Top Middle
                case 3: return new Position(0, 2); // Top Right
                case 4: return new Position(1, 0); // Middle Left
                case 5: return new Position(1, 1); // Middle Middle
                case 6: return new Position(1, 2); // Middle Right
                case 7: return new Position(2, 0); // Bottom Left
                case 8: return new Position(2, 1); // Bottom Middle 
                case 9: return new Position(2, 2); // Bottom Right

                default: return null;
            }
        }

        /// <summary>
        /// Method used to initiate and follow through on a player's turn.
        /// </summary>
        /// <param name="board">Current board state.</param>
        public void TakeTurn(Board board)
        {
            bool isTurn = true;

            Console.WriteLine($"{Name}, you are {Marker} and it is your turn.");
            while (isTurn)
            {
                Position position = GetPosition(board);

                bool success = Int32.TryParse(board.GameBoard[position.Row, position.Column], out int _);

                if (success)
                {
                    board.GameBoard[position.Row, position.Column] = Marker;
                    isTurn = false;
                }
                else
                {
                    Console.WriteLine("This space is already occupied");
                }
            }
        }
    }
}
