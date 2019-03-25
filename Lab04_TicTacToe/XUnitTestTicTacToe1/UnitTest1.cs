using System;
using Xunit;
using Lab04_TicTacToe.Classes;

namespace XUnitTestTicTacToe1
{
    public class UnitTest1
    {
        Player playerOne = new Player { Name = "p1", Marker = "X", IsTurn = false };
        Player playerTwo = new Player { Name = "p2", Marker = "O", IsTurn = true };
        Board board = new Board();

        [Fact]
        public void PlayerOneShouldHaveName()
        {
            string expectedName = "p1";

            Game game = new Game(playerOne, playerTwo);

            Assert.Equal(expectedName, playerOne.Name);
        }

        [Fact]
        public void PlayerTwoShouldHaveMarker()
        {
            string expectedMarker = "O";

            Game game = new Game(playerOne, playerTwo);

            Assert.Equal(expectedMarker, playerTwo.Marker);
        }

        [Fact]
        public void PlayerOneShouldWinHorizantalLine()
        {
            Game game = new Game(playerOne, playerTwo);
            game.Board = board;

            string[,] testBoard = new string[,]
            {
                {"X", "X", "X"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

            board.GameBoard = testBoard;

            bool win = game.CheckForWinner(board);

            Assert.True(win);
        }

        [Fact]

        public void PlayerOneShouldWinVirticleLine()
        {
            Game game = new Game(playerOne, playerTwo);
            game.Board = board;

            string[,] testBoard = new string[,]
            {
                {"1", "2", "X"},
                {"4", "5", "X"},
                {"7", "8", "X"}
            };

            board.GameBoard = testBoard;

            bool win = game.CheckForWinner(board);

            Assert.True(win);
        }

        [Fact]
        public void PlayerOneShouldWinDiaginalLine()
        {
            Game game = new Game(playerOne, playerTwo);
            game.Board = board;

            string[,] testBoard = new string[,]
            {
                {"1", "2", "X"},
                {"4", "X", "6"},
                {"X", "8", "9"}
            };

            board.GameBoard = testBoard;

            bool win = game.CheckForWinner(board);

            Assert.True(win);
        }

        [Fact]
        public void TieGame()
        {
            Game game = new Game(playerOne, playerTwo);
            game.Board = board;

            string[,] testBoard = new string[,]
            {
                {"X", "O", "X"},
                {"O", "O", "X"},
                {"X", "X", "O"}
            };

            board.GameBoard = testBoard;

            bool win = game.CheckForWinner(board);

            Assert.False(win);
        }

        [Fact]
        public void TurnShouldSwitchFromPlayerTwoToPlayerOne()
        {
            Game game = new Game(playerOne, playerTwo);

            Player nextPlayer = game.NextPlayer();

            Assert.True(nextPlayer.IsTurn);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(2, 0, 1)]
        [InlineData(3, 0, 2)]
        [InlineData(4, 1, 0)]
        [InlineData(5, 1, 1)]
        [InlineData(6, 1, 2)]
        [InlineData(7, 2, 0)]
        [InlineData(8, 2, 1)]
        [InlineData(9, 2, 2)]
        public void UserSelectShouldReturnCorrectCoords(int userPick, int posOne, int posTwo)
        {
            Position expected = new Position(posOne, posTwo);
            int[] expectedArr = { expected.Row, expected.Column };

            Position results = Player.PositionForNumber(userPick);
            int[] resultsArr = { results.Row, results.Column };

            Assert.Equal(expectedArr, resultsArr);
        }
    }
}

