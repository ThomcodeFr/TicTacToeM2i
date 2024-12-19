using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Display;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Fact]
        public void IsGameOver_ShouldReturnWinMessage_WhenAIPlayerWins() 
        {
            // Assign :  Créer une instance de la classe que je veux tester
            IDisplay display = new DebugDisplay();
            Board board = new Board(display);
            RandomPlayer randomPlayer = new RandomPlayer('O');

            // Act : Appeler la méthode que je veux tester
            board.PlayMoveOnBoard(new PlayerMove(1, 1), 'O');
            board.PlayMoveOnBoard(new PlayerMove(1, 2), 'O');
            board.PlayMoveOnBoard(new PlayerMove(1, 3), 'O');   

            var result = board.IsGameOver(randomPlayer);

            // Assert : Vérifier que le résultat est correct
            result.HasValue.Should().BeTrue();
        }

        [Fact]
        public void IsGameOver_ShouldReturnFailedMessage_WhenAIPlayerLoses()
        { 
            // Assign
            IDisplay display = new DebugDisplay();
            Board board = new Board(display);
            RandomPlayer randomPlayer = new RandomPlayer('X');

            // Act
            board.PlayMoveOnBoard(new PlayerMove(1, 1), 'O');
            board.PlayMoveOnBoard(new PlayerMove(1, 2), 'O');
            board.PlayMoveOnBoard(new PlayerMove(1, 3), 'O');

            var result = board.IsGameOver(randomPlayer);

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public void IsGameOver_ShouldReturnIt_A_Draw_WhenIsGameFull()
        {
            // Assign
            IDisplay display = new DebugDisplay();
            Board board = new Board(display);
            RandomPlayer randomPlayer = new RandomPlayer('X');

            // Act 
            board.PlayMoveOnBoard(new PlayerMove(1, 1), 'X'); // X O O
            board.PlayMoveOnBoard(new PlayerMove(1, 2), 'O'); // O X X
            board.PlayMoveOnBoard(new PlayerMove(1, 3), 'O'); // O X O
            board.PlayMoveOnBoard(new PlayerMove(2, 1), 'O');
            board.PlayMoveOnBoard(new PlayerMove(2, 2), 'X');
            board.PlayMoveOnBoard(new PlayerMove(2, 3), 'X'); 
            board.PlayMoveOnBoard(new PlayerMove(3, 1), 'O');
            board.PlayMoveOnBoard(new PlayerMove(3, 2), 'X');
            board.PlayMoveOnBoard(new PlayerMove(3, 3), '0');

            var result = board.IsGameOver(randomPlayer);

            // Assert
            result.HasValue.Should().BeTrue();
        }
    }
}