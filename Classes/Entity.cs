using System;
using System.Collections.Generic;
using System.Text;

namespace Labrinth
{
    internal class Entity
    {

        private int xPos;
        private int yPos;
        public char entityIcon;

        //This value determines if the entity is "active" (Like if a player can move or ect)
        private bool isActive = true;

        public MapClass MapManager;

        private void updateMap()
        {
            if (MapManager != null)
            {
                MapManager.drawMap();
            }
        }

        public int GetX()
        {
            return this.xPos;
        }

        public int GetY()
        {
            return this.yPos;
        }

        public void SetPosition(int x, int y)
        {
            this.xPos = x;
            this.yPos = y;
            updateMap();
        }

        public void SetX(int x)
        {
            this.xPos = x;
            updateMap();
        }

        public void SetY(int y)
        {
            this.yPos = y;
            updateMap();
        }

        public void SetMM(MapClass mm)
        {
            this.MapManager = mm;
        }

        public bool GetIsActive()
        {
            return isActive;
        }

        public void SetActive(bool isActive)
        {
            this.isActive = isActive;
        }

        //This checks if there is a wall near the player.
        public bool checkNearbyTile(int xOffset, int yOffset)
        {
            bool isBlocked = true;

            isBlocked = MapManager.checkSpot(xPos+xOffset, yPos+yOffset);

            //Console.WriteLine("Is blocked: " + isBlocked);

            return isBlocked;
        }

        public Entity()
        {
            this.xPos = 0;
            this.yPos = 0;
            this.entityIcon = '#';
            this.MapManager = null;
        }

        public Entity(int x, int y, char icon, MapClass mm)
        {
            this.xPos = x;
            this.yPos = y;
            this.entityIcon = icon;
            this.MapManager = mm;
        }
    }
}
