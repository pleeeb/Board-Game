using System;
using System.Collections.Generic;
using System.Text;

namespace Board_Game
{
    class Player
    {
        private int x;
        private int y;
        private int z;
        private bool xChange = false;
        private bool yChange = false;
        private bool zChange = false;
        public bool solved = false;
        private int axis;
        private Board game;
        public int moves = 0;

        public Player(Board b) {
            game = b;
        }

        public void setX(int x) {
            this.x = x;
            setxChange();
        }

        public void setY(int y) {
            this.y = y;
            setyChange();
        }

        public void setZ(int z) {
            this.z = z;
            setzChange();
        }

        public void setxChange() {
            xChange = !xChange;
        }

        public void setyChange()
        {
            yChange = !yChange;
        }

        public void setzChange()
        {
            zChange = !zChange;
        }

        public bool getXChange() {
            return xChange;
        }

        public bool getYChange()
        {
            return yChange;
        }

        public bool getZChange() {
            return zChange;
        }

        //Choose the axis which the player will move
        public void setAxis()
        {
            var complete = false;
            Console.WriteLine("What Axis do you want to move?");
            Console.WriteLine("Please type X Y or Z");
            while (!complete)
            {
                string axe = Console.ReadLine();
                if (axe.ToUpper() == "X")
                {
                    axis = 1;
                    complete = true;
                }
                else if (axe.ToUpper() == "Y")
                {
                    axis = 2;
                    complete = true;
                }
                else if (axe.ToUpper() == "Z")
                {
                    axis = 3;
                    complete = true;
                }
                else {
                    Console.WriteLine("Please enter either X Y or Z");
                }
            }
        }

        //Moves the x,y or z position by 1 up or down depending on user choice
        //Checks if the move will go out of index range
        public void adjustAxis() {
            var complete = false;
            while (!complete) {
                Console.WriteLine("Do you want to move this axis up or down by 1?");
                Console.WriteLine("Please enter u or d");
                string up_down = Console.ReadLine();
                if (up_down.ToUpper() == "D")
                {
                    switch (axis)
                    {
                        case 1:
                            if (this.x > 0)
                            {
                                setX(this.x - 1);
                                complete = true;
                                moves += 1;
                                break;
                            }
                            else {
                                Console.WriteLine("That value cannot be lowered");
                                break;
                            }
                        case 2:
                            if (this.y > 0)
                            {
                                setY(this.y - 1);
                                complete = true;
                                moves += 1;
                                break;
                            }
                            else {
                                Console.WriteLine("That value cannot be lowered");
                                break;
                            }
                        case 3:
                            if (this.z > 0)
                            {
                                setZ(this.z - 1);
                                complete = true;
                                moves += 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That value cannot be lowered");
                                break;
                            }
                    }
                }
                else if (up_down.ToUpper() == "U") {
                    switch (axis)
                    {
                        case 1:
                            if (this.x < game.board_size-1)
                            {
                                setX(this.x + 1);
                                complete = true;
                                moves += 1;
                                break;
                            }
                            else {
                                Console.WriteLine("That value cannot be increased");
                                break;
                            }
                        case 2:
                            if (this.y < game.board_size-1)
                            {
                                setY(this.y + 1);
                                complete = true;
                                moves += 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That value cannot be increased");
                                break;
                            }
                        case 3:
                            if (this.z < game.board_size-1)
                            {
                                setZ(this.z + 1);
                                complete = true;
                                moves += 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That value cannot be increased");
                                break;
                            }
                    }
                }
            }
        }

        //Gets the inital X guess of the player
        public void xSelection() {
            Console.WriteLine("Please enter the X coordinate of your guess");
            while (!(this.getXChange()))
            {
                try
                {
                    var xChoice = Convert.ToInt32(Console.ReadLine());
                    if (xChoice > this.game.board_size - 1)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        this.setX(xChoice);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number between 0 and " + (this.game.board_size - 1));
                }
            }
            this.setxChange();
        }

        //Gets the inital Y guess of the player
        public void ySelection() {
            Console.WriteLine("Please enter the Y coordinate of your guess");
            while (!(this.getYChange()))
            {
                try
                {
                    var yChoice = Convert.ToInt32(Console.ReadLine());
                    if (yChoice > this.game.board_size - 1)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        this.setY(yChoice);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number between 0 and " + (this.game.board_size - 1));
                }
            }
            this.setyChange();
        }

        //Gets the initial Z guess of the player
        public void zSelection()
        {
            Console.WriteLine("Please enter the Z coordinate of your guess");
            while (!(this.getZChange()))
            {
                try
                {
                    var zChoice = Convert.ToInt32(Console.ReadLine());
                    if (zChoice > this.game.board_size - 1)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        this.setZ(zChoice);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number between 0 and " + (this.game.board_size - 1));
                }
            }
            this.setzChange();
        }

        //Checks x, y and z values to see if they are matching/too high/too low
        public void checkSolution() {
            if (this.x == game.getCol() && this.y == game.getRow() && this.z == game.getDep())
            {
                Console.WriteLine("You are spot on!");
                solved = true;
            }
            else
            {
                if (this.x < game.getCol())
                {
                    Console.Write("Your X is too low, ");
                }
                else if (this.x > game.getCol())
                {
                    Console.Write("Your X is too high, ");
                }
                else {
                    Console.Write("Your X is spot on, ");
                }
                if (this.y < game.getRow()) {
                    Console.Write("Your Y is too low, ");
                }
                else if (this.y > game.getRow())
                {
                    Console.Write("Your Y is too high, ");
                }
                else
                {
                    Console.Write("Your Y is spot on, ");
                }
                if (this.z < game.getDep())
                {
                    Console.Write("Your Z is too low, ");
                }
                else if (this.z > game.getDep())
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
