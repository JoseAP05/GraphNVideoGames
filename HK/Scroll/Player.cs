﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;

namespace Scroll
{
    public class Player
    {
        PlayerSprite mainSprite;

        public bool hit = false;
        
        public float fPlayerPosX = 1.0f;
        public float fPlayerPosY = 1.0f;

        private float fPlayerVelX = 0.0f;
        private float fPlayerVelY = 0.0f;


        public PlayerSprite MainSprite
        {
            get { return mainSprite; }
        }

        public float FPlayerVelX
        {
            get { return fPlayerVelX; }
            set { fPlayerVelX = value; }
        }        

        public float FPlayerVelY
        {
            get { return fPlayerVelY; }
            set { fPlayerVelY = value; }
        }

        public Player()
        {
            mainSprite = new PlayerSprite(new Size(35, 70), new Size(20, 25), new Point(), Resource1.HK_DASH_R, Resource1.HK_DASH_L, Resource1.HK_FALLIN, Resource1.HK_FALLIN_L);
        }

        public void Right(float fElapsedTime)
        {
            FPlayerVelX += (bPlayerOnGround ? 25.0f : 15.0f) * fElapsedTime;
            if(bPlayerOnGround)
                mainSprite.MoveRight();
            

        }

        public void Left(float fElapsedTime)
        {
            FPlayerVelX += (bPlayerOnGround ? -25.0f : -15.0f) * fElapsedTime;
            if(bPlayerOnGround)
                mainSprite.MoveLeft();
              
        }

        public void Frame(int x)
        {
            mainSprite.Frame(x);
        }
        public void Stop()
        {
            mainSprite.Frame(0);
        }

        public bool bPlayerOnGround = false;

        public void Update(float fElapsedTime, Map map)
        {
            //Gravity
            fPlayerVelY += 20.0f * fElapsedTime;//---------------

            // Drag
            if (bPlayerOnGround)
            {
                fPlayerVelX += -3.0f * fPlayerVelX * fElapsedTime;
                if (Math.Abs(fPlayerVelX) < 0.01f)
                    fPlayerVelX = 0.0f;
            }

            // Clamp velocities
            if (fPlayerVelX > 10.0f)
                fPlayerVelX = 10.0f;

            if (fPlayerVelX < -10.0f)
                fPlayerVelX = -10.0f;

            if (fPlayerVelY > 100.0f)
                fPlayerVelY = 100.0f;

            if (fPlayerVelY < -100.0f)
                fPlayerVelY = -100.0f;

            float fNewPlayerPosX = fPlayerPosX + fPlayerVelX * fElapsedTime;
            float fNewPlayerPosY = fPlayerPosY + fPlayerVelY * fElapsedTime;

            //CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'o', '.');
            //CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, '*', 'a');


            // COLLISION
            if (fPlayerVelX <= 0)//left
            {
                if ((map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.9f)) != '.'))
                {
                    if (fPlayerVelX != 0)
                        fNewPlayerPosX = (int)fNewPlayerPosX + 1;
                    fPlayerVelX = 0;
                }
            }
            else//right
            {
                if ((map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.9f)) != '.'))
                {
                    if (fPlayerVelX != 0)
                        fNewPlayerPosX = (int)fNewPlayerPosX;

                    fPlayerVelX = 0;
                }
            }

            //bPlayerOnGround = false;
            if (fPlayerVelY <= 0)// up
            {
                if ((map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 0.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY + 0.0f)) != '.'))
                {
                    fNewPlayerPosY = (int)fNewPlayerPosY + 1;
                    fPlayerVelY = 0;
                }
            }
            else
            {
                if ((map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 1.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY + 1f)) != '.'))
                {
                    fNewPlayerPosY = (int)fNewPlayerPosY;
                    fPlayerVelY = 0;
                    if (!bPlayerOnGround && MAIN.isRight == true)
                        mainSprite.MoveRight();

                    if (!bPlayerOnGround && MAIN.isRight == false)
                        mainSprite.MoveLeft();

                    bPlayerOnGround = true;
                }
            }


            fPlayerPosX = fNewPlayerPosX;
            fPlayerPosY = fNewPlayerPosY;

            CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'm');

            mainSprite.Display(map.g);
        }

        private static void CheckPicks(Map map, float fNewPlayerPosX, float fNewPlayerPosY,char c)
        {
            // Check for pickups!

            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.5f) == c)
                MAIN.mapNumb2 = true;



            if (map.GetTile(fNewPlayerPosX + 1.5f, fNewPlayerPosY + 0.0f) == c)
                MAIN.mapNumb2 = true;



            if (map.GetTile(fNewPlayerPosX - 0.0f, fNewPlayerPosY - 0.75f) == c)
                MAIN.mapNumb2 = true;



            if (map.GetTile(fNewPlayerPosX - 0.75f, fNewPlayerPosY - 0.0f) == c)
                MAIN.mapNumb2 = true;
        }

        private static void CheckPicks_2(Map map, float fNewPlayerPosX, float fNewPlayerPosY, char c)
        {
            // Check for pickups!


            if (map.GetTile(fNewPlayerPosX + 0.5f, fNewPlayerPosY + 0.5f) == c)
                MAIN.mapNumb3 = true;



            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.5f) == c)
                MAIN.mapNumb3 = true;



            if (map.GetTile(fNewPlayerPosX + 0.5f, fNewPlayerPosY + 0.0f) == c)
                MAIN.mapNumb3 = true;



            if (map.GetTile(fNewPlayerPosX - 0.0f, fNewPlayerPosY - 0.5f) == c)
                MAIN.mapNumb3 = true;



            if (map.GetTile(fNewPlayerPosX - 0.5f, fNewPlayerPosY - 0.0f) == c)
                MAIN.mapNumb3 = true;
        }

    }
}
