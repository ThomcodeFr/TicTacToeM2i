using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace TicTacToe;

public class RandomPlayer : Player
{
    public override char Icon { get; }

    public RandomPlayer(char icon)
    {
        this.Icon = icon;
    }

    public override async Task<Result<PlayerMove>> GetNextMove()
    {
        Console.Write($"{this.Icon} is thinking");

        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            await Task.Delay(1000);
        }
        Console.WriteLine(); 

        await Task.Delay(3000);
        return PlayerMove.Random; 
    }

}