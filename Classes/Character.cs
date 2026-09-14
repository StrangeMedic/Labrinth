using System;
using System.Collections.Generic;
using System.Text;

namespace Labrinth
{
    //This is the entity that the player can control with WASD.
    internal class Character : Entity
    {
        private void movementThread()
        {
            while (true)
            {
                ConsoleKey keyinput;
                bool inputDelay = true;

                do
                {
                    keyinput = Console.ReadKey(false).Key;
                } while (keyinput != ConsoleKey.W && keyinput != ConsoleKey.S && keyinput != ConsoleKey.A && keyinput != ConsoleKey.D && inputDelay);
                //Console.WriteLine("Got input.");

                if (keyinput == ConsoleKey.W)
                {
                    bool isBlocked = this.checkNearbyTile(0, -1);
                    if (!isBlocked)
                    {
                        this.SetY(this.GetY() - 1);
                    }
                }
                else if (keyinput == ConsoleKey.A)
                {
                    bool isBlocked = this.checkNearbyTile(-1, 0);
                    if (!isBlocked)
                    {
                        this.SetX(this.GetX() - 1);
                    }
                }
                else if (keyinput == ConsoleKey.D)
                {
                    bool isBlocked = this.checkNearbyTile(1, 0);
                    if (!isBlocked)
                    {
                        this.SetX(this.GetX() + 1);
                    }
                }
                else if (keyinput == ConsoleKey.S)
                {
                    bool isBlocked = this.checkNearbyTile(0, 1);
                    if (!isBlocked)
                    {
                        this.SetY(this.GetY() + 1);
                    }
                }
            }
        }

        public Character()
        {
            this.SetPosition(3, 3);
            this.entityIcon = '☺';

            //Start up a thread for tracking player inputs.
            Thread t = new Thread(movementThread);
            t.Start();
        }
    }
}
