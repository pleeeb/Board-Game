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

            game_board.setBoard(game_board.board_size);
            game_board.genPos();
            game_board.printBoard();

            p1.xSelection();
            p1.ySelection();
            p1.zSelection();
            p1.checkSolution();


            while (!p1.solved)
            {
                p1.setAxis();
                p1.adjustAxis();
                p1.checkSolution();
            }

            Console.WriteLine("You Win!");
            Console.WriteLine($"You took {p1.moves} moves");
        }
    }
}
