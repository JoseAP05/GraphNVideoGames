using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Scroll
{
    public class Nail
    {
        Sprite nailSprite;

        public float fNailPosX = 1.0f;
        public float fNailPosY = 1.0f;

        private float fNailVelX = 0.0f;
        private float fNailVelY = 0.0f;

        public Sprite NailSprite
        {
            get { return nailSprite; }
        }

        public float FNailVelX
        {
            get { return fNailVelX; }
            set { fNailVelX = value; }
        }

        public float FNailVelY
        {
            get { return fNailVelY; }
            set { fNailVelY = value; }
        }

        public Nail()
        {
            nailSprite = new Sprite(new Size(90, 70), new Size(35, 25), new Point(), Resource2.Nail, Resource2.Nail_L);
        }

        public void Right(float fElapsedTime)
        {
            FNailVelX += (bPlayerOnGround ? 25.0f : 15.0f) * fElapsedTime;
            if (bPlayerOnGround)
                nailSprite.MoveRight();


        }

        public void Left(float fElapsedTime)
        {
            FNailVelX += (bPlayerOnGround ? -25.0f : -15.0f) * fElapsedTime;
            if (bPlayerOnGround)
                nailSprite.MoveLeft();

        }

        public void Frame(int x)
        {
            nailSprite.Frame(x);
        }
        public void Stop()
        {
            nailSprite.Frame(0);
        }

        public bool bPlayerOnGround = false;

        public void Update(float fElapsedTime, Map map, float play_pos_X, float play_pos_Y, bool display, bool right)
        {
            float fNewPlayerPosX = play_pos_X + .75f; ;
            float fNewPlayerPosY = play_pos_Y;

            if (right == false)
                fNewPlayerPosX = play_pos_X - .75f;

            if (display == true)
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, '*', '.');
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'f', '.');
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'g', '.');
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'l', '.');
                nailSprite.Display(map.g);

        }

        private static void CheckPicks(Map map, float fNewPlayerPosX, float fNewPlayerPosY, char c, char c2)
        {
            // Check for pickups!
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f, c2);
        }
    }
}
