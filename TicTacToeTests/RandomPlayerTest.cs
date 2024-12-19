using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;

namespace TicTacToeTests
{
    public class RandomPlayerTest
    {
        [Fact]
        public void GetNextMove_Default_ReturnAValidPlayerMove()
        {
            // Assign
            RandomPlayer aiPlayer = new('O');

            // Act
            Result<PlayerMove> playerMove = aiPlayer.GetNextMove();

            // Assert
            playerMove.IsSuccess.Should().BeTrue();

            playerMove.Value.Row.Should().BeInRange(1, 3);

            playerMove.Value.Column.Should().BeInRange(1, 3);
        }
    }
}
