using System;
using System.Collections.Generic;
using System.Text;

namespace Labrinth
{
    internal class MasterClass
    {


        public static void Main(string[] args)
        {
            //This class handles drawing the map
            MapClass MapManager = new MapClass();

            List<int> enemies;

            bool gameOver = false;

            List < List<int> > newMap = new List<List<int>>();

            for (int i = 0; i < 10; i++)
            {
                List<int> newX = new List<int>();
                for (int k = 0; k < 30; k++)
                {
                    newX.Add(1);
                }
                newMap.Add(newX);
            }

            //Get the file for the map and load it.
            MapManager.setMap(@"C:\\Users\\jkc56\\source\\repos\\Labrinth\\Labrinth\\Levels\\Level1.txt");

            //Create the player entity.
            //Since Character inherits from entity we can store it as a entity class.
            Entity player = new Character();
            player.SetMM(MapManager);

            //Add the player entity to the Map Manager's list of entities.
            MapManager.addEntity(player);

            //Draw the map.
            MapManager.drawMap();

            //Set player's position.
            player.SetPosition(1, 1);
            
        }
    }
}
