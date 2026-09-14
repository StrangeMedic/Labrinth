using System;
using System.Collections.Generic;
using System.Text;

namespace Labrinth
{
    internal class MapClass
    {
        private List<List<int>> currentMap;
        private List<Entity> mapEntities = new List<Entity>(); 
        
        //This function is for drawing the map in the game.
        //It will also draw the positions of the player, objects, and enemies.
        public void drawMap()
        {
            //Clear the previous drawed map.
            Console.Clear();
            for (int y = 0; y < currentMap.Count; y++)
            {
                List<int> xArray = currentMap[y];
                for (int x = 0; x < xArray.Count; x++)
                {
                    //Console.WriteLine("This is " + xArray[x]);
                    bool entityInSpot = false;

                    //Check if a entity exists at that spot.
                    for (int n = 0; n < mapEntities.Count; n++)
                    {
                        Entity currentEntity = mapEntities[n];

                        if (currentEntity.GetX() == x && currentEntity.GetY() == y)
                        {
                            //The entity is in that spot and should be drawn!
                            Console.Write(currentEntity.entityIcon);
                            entityInSpot = true;
                        }
                    }

                    //Draw these instead if there isn't a entity in that spot.
                    if (!entityInSpot)
                    {
                        if (xArray[x] == 1)
                        {
                            Console.Write("█");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public void setMap(string levelName)
        {
            List<List<int>> map = new List<List<int>>();

            try
            {
                using (StreamReader sr = File.OpenText(levelName))
                {
                    var lineCount = File.ReadAllLines(levelName).Length;
                    for (int y = 0; y < lineCount; y++)
                    {
                        List<int> Row = new List<int>();
                        string numberLine = sr.ReadLine();
                        for (int x = 0; x < numberLine.Length; x++)
                        {
                            
                            //Console.WriteLine("Got char " + numberLine[x]);
                            Row.Add(int.Parse(numberLine[x].ToString()));
                        }
                        map.Add(Row);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read level file.");
                Console.WriteLine(e);
            }

            currentMap = map;
        }

        public void addEntity(Entity newEntity)
        {
            mapEntities.Add(newEntity);
        }

        public bool checkSpot(int x, int y)
        {
            bool isBlocked = true;

            try
            {
                //Grab the value in the exact spot of [y][x]
                int spotValue = currentMap[y][x];

                //If it's 0 then that means it's a empty spot and can be walked onto.
                if (spotValue == 0)
                {
                    isBlocked = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to check spot, out of bounds maybe?");
                Console.WriteLine(e);
            }

            return isBlocked;
        }

        public Entity GetFirstEntity(string entityName)
        {
            Entity foundEntity = null;

            //TODO: add code that fetches an entity from a name.

            return foundEntity;
        }
    }
}
