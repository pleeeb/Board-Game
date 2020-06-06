using System;
using System.Collections.Generic;
using System.Text;

namespace Board_Game
{
    class Player
    {
        public bool solved = false;
        private int axis;
        private Board game;
        public int moves = 0;

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }


        public Player(Board b) {
            game = b;
        }

        //Choose the axis which the player will move
        public void SetAxis()
        {
            var complete = false;
            Console.WriteLine("What Axis do you want to move?");
            Console.WriteLine("Please type X Y or Z");
            while (!complete)
            {
                complete = true;
                string axe = Console.ReadLine();
                if (axe.ToUpper() == "X")
                {
                    axis = 1;
                }
                else if (axe.ToUpper() == "Y")
                {
                    axis = 2;
                }
                else if (axe.ToUpper() == "Z")
                {
                    axis = 3;
                }
                else {
                    Console.WriteLine("Please enter either X Y or Z");
                    complete = false;
                }
            }
        }

        //Moves the x,y or z position by 1 up or down depending on user choice
        //Checks if the move will go out of index range
        public void AdjustAxis() {
            var complete = false;
            while (!complete) {
                Console.WriteLine("Do you want to move this axis up or down by 1?");
                Console.WriteLine("Please enter u or d");
                string up_down = Console.ReadLine();
                complete = true;
                int value = 0;
                if (up_down.ToUpper() == "D")
                {
                    value = -1;
                }
                else if (up_down.ToUpper() == "U") {
                    value = 1;
                }

                switch (axis)
                {
                    case 1:
                        if (X+value > 0 && X+value < game.board_size)
                        {
                            X = X + value;
                            moves += 1;
                            break;
                        }
                        else {
                            Console.WriteLine("That value has reached the end of the range");
                            complete = false;
                            break;
                        }
                    case 2:
                        if (Y+value > 0 && Y+value < game.board_size)
                        {
                            Y = Y + value;
                            moves += 1;
                            break;
                        }
                        else {
                            Console.WriteLine("That value has reached the end of the range");
                            complete = false;
                            break;
                        }
                    case 3:
                        if (Z+value > 0 && Z+value < game.board_size)
                        {
                            Z = Z + value;
                            moves += 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That value has reached the end of the range");
                            complete = false;
                            break;
                        }
                }
            }
                
            }
        


        public int AxisSelection(string AxisName) {
            Console.WriteLine($"Please enter the {AxisName} coordinate of your guess");
            bool ChangeValue = false;
            while (!ChangeValue) {
                ChangeValue = true;
                {
                    try
                    {
                        int Choice = Convert.ToInt32(Console.ReadLine());
                        if (Choice > this.game.board_size - 1 || Choice < 0)
                        {
                            throw new FormatException();
                        }
                        else
                        {
                            return Choice;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number between 0 and " + (this.game.board_size - 1));
                        ChangeValue = false;
                    }
                }
            }
            return 0;
        }

        //Checks x, y and z values to see if they are matching/too high/too low
        public void CheckSolution() {
            if (X == game.col && Y == game.row && this.Z == game.dep)
            {
                Console.WriteLine("You are spot on!");
                solved = true;
            }
            else
            {
                if (X < game.col)
                {
                    Console.Write("Your X is too low, ");
                }
                else if (X > game.col)
                {
                    Console.Write("Your X is too high, ");
                }
                else {
                    Console.Write("Your X is spot on, ");
                }
                if (Y < game.row) {
                    Console.Write("Your Y is too low, ");
                }
                else if (Y > game.row)
                {
                    Console.Write("Your Y is too high, ");
                }
                else
                {
                    Console.Write("Your Y is spot on, ");
                }
                if (Z < game.dep)
                {
                    Console.Write("Your Z is too low, ");
                }
                else if (Z > game.dep)
                {
                    Console.Write("Your Z is too high, ");
                }
                else
                {
                    Console.Write("Your Z is spot on, ");
                }
                Console.WriteLine("\n");
            }
        }

    }
}
