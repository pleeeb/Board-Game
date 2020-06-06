using System;
using System.Drawing;
using System.Linq;

namespace Board_Game
{
    class Program
    {
        static void Main(string[] args){
            Board game_board = new Board();
            Player p1 = new Player(game_board);
            Console.WriteLine("Enter the size of the board between 3 and 10");

            while (game_board.board_size < 3 || game_board.board_size > 10)
            {
                try
                {
                    game_board.board_size = Convert.ToInt32(Console.ReadLine());
                    if (game_board.board_size < 3 || game_board.board_size > 10) {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number between 3 and 10");
                }
            }

            game_board.SetBoard(game_board.board_size);
            game_board.GenPos();

            p1.X = (p1.AxisSelection(nameof(p1.X)));
            p1.Y = (p1.AxisSelection(nameof(p1.Y)));
            p1.Z = (p1.AxisSelection(nameof(p1.Z)));
            p1.CheckSolution();


            while (!p1.solved)
            {
                p1.SetAxis();
                p1.AdjustAxis();
                p1.CheckSolution();
            }

            Console.WriteLine("You Win!");
            Console.WriteLine($"You took {p1.moves} moves");
        }
    }
}
