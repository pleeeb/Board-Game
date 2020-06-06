using System;
using System.Collections.Generic;
using System.Text;

namespace Board_Game
{
    class Board
    {
        private int[][][] board;
        public int board_size = 0;
        public int row { get; set; }
        public int col { get; set; }
        public int dep { get; set; }

        //Generates the board as a 3D array
        public void SetBoard(int size) {
            board = new int[size][][];

            for (int i = 0; i < size; i++)
            {
                board[i] = new int[size][];
                for (int j = 0; j < size; j++)
                {
                    board[i][j] = new int[size];
                    for (int k = 0; k < size; k++) {
                        board[i][j][k] = 0;
                    }
                }
            }
        }

        //Generates the random position on the board
        public void GenPos() {
            var rand = new Random();
            row = rand.Next(0, this.board_size);
            col = rand.Next(0, this.board_size);
            dep = rand.Next(0, this.board_size);
            board[row][col][dep] = 1;
            
        }


        //Only used for debugging and checking the program works
        public void PrintBoard() {
            foreach (int[][] i in board) {
                foreach(int[] j in i) {
                    foreach (int k in j)
                    {
                        Console.Write(k);
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}
