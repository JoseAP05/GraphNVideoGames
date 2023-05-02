using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Threading;

namespace Scroll
{
    public class Map
    {
        int divs = 3;
        public int nTileWidth = 20;
        public int nTileHeight = 20;
        int nLevelWidth, nLevelHeight;
        private string sLevel;
        public Bitmap bmp;
        public Graphics g;
        Sprite coin;
        Sprite Back;
        SoundPlayer soundPlayer;
        public static int score;
        public static int lives = 5;
        bool isP1 = true;
        Thread thread, threadStop;

        public int l1_x1, l1_x2, l2_x1, l2_x2;
        Bitmap layer1, layer2;
        public int motion1 = 2, motion2 = 4;
        public int width = Resource1.City_of_tears.Width;


        public Map(Size size)
        {            
            
            soundPlayer = new SoundPlayer(Resource1.enemy_damage);            
            score = 0;
            layer1 = Resource1.City_of_tears;
            l1_x1 = l2_x2 = 0;
            l1_x2 = l2_x2 = width;

            sLevel = "";
            sLevel += "........#########################################.....................................................................................................................#########################################################################################.";
            sLevel += "........#.............................................................................................................................................................B.......................................................................................#.";
            sLevel += "........#.....................................................................................................................................................................................................................................................#.";
            sLevel += "...............................##################.............................................................................................................................................................................................................#.";
            sLevel += "................................................#.............................................................................................................................................................................................................#.";
            sLevel += "...............f................................#################BBBBBB###B####BB####BBBB#######B###B######BBBBBBBBBBBB########################BBBBBBBBBB###BBBBBB#####......##################################################################################.";
            sLevel += "........###############...........*...................................................................................................................................#.......................................................................................#.";
            sLevel += "#########.....................############...........*.......................................l............................*.......................................f...#.......................................................................................#.";
            sLevel += "..#......................................######################............*..............######..................###############..........................##############################################################################################.....#.";
            sLevel += "..#......######........####..............................................#######..........#...........................................................*.......................................................................................................#.";
            sLevel += "..#.*.............*......................*............................................#####....................................................###########............................*.......................................................................B.";
            sLevel += "..#######.....#######...............#########............############..................................f...........................f............................................################...............*.......f..................l..........l........#.";
            sLevel += "........#.................f......................................................................#########..................###########................................................................##B###BB######BB#####B#####B########BB##########BBB#####.";
            sLevel += "........#..l..........#########......................................*......f.............#............................................................................................................#........................................................";
            sLevel += "........########...............................................####################.......#................*.....................................................*....................f.............####........................................................";
            sLevel += "........#.................................................................................#..##################################################BB##B####BBBBB###BBB###########BBBB############B#B###B###........................................................";
            sLevel += "........#..............l.........f....................................................#####..................................................B..................................................................................................................";
            sLevel += "############################################################..........................#####...........l.............l........................B..................................................................................................................";
            sLevel += "................................................................#BBBBBBBBBBB##BBBBBBBBBB###BBB###B##################BBBBBB##BBB###B###########..................................................................................................................";
            sLevel += "s............................................................####...............................................................................................................................................................................................";
            sLevel += "#########.................................................#######...............................................................................................................................................................................................";
            sLevel += "........############BBBBBBBBBBBBBBBBBBBB#BBB##B##################...............................................................................................................................................................................................";
            
      
            
            nLevelWidth = 256;
            nLevelHeight = 22;

            bmp = new Bitmap(size.Width / divs, size.Height / divs);
            

            g = Graphics.FromImage(bmp);
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
        }

        public void Draw(PointF cameraPos, string message, Player player, Nail nail, bool right)
        {
            g.DrawImage(layer1, l1_x1, 0, width, bmp.Height);
            g.DrawImage(layer1, l1_x2, 0, width, bmp.Height);

            // Draw Level based on the visible tiles on our picturebox (canvas)
            int nVisibleTilesX = bmp.Width / nTileWidth;
            int nVisibleTilesY = bmp.Height / nTileHeight;

            // Calculate Top-Leftmost visible tile
            float fOffsetX = cameraPos.X - (float)nVisibleTilesX / 2.0f;
            float fOffsetY = cameraPos.Y - (float)nVisibleTilesY / 2.0f;

            // Clamp camera to game boundaries
            if (fOffsetX < 0) fOffsetX = 0;
            if (fOffsetY < 0) fOffsetY = 0;
            if (fOffsetX > nLevelWidth - nVisibleTilesX) fOffsetX = nLevelWidth - nVisibleTilesX;
            if (fOffsetY > nLevelHeight - nVisibleTilesY) fOffsetY = nLevelHeight - nVisibleTilesY;

            float fTileOffsetX = (fOffsetX - (int)fOffsetX) * nTileWidth;
            float fTileOffsetY = (fOffsetY - (int)fOffsetY) * nTileHeight;

            //Size sizeSky = new Size(256, 22);
            //Size vizSky = new Size(1164, 645);
            //Back = new Sprite(sizeSky, vizSky, new Point((int)cameraPos.X, (int)cameraPos.Y), Resource2.HK_Back, Resource2.HK_Back);
            //Back.Display(g);
            GC.Collect();
            //Draw visible tile map//*--------------------DRAW------------------------------
            char c;
            float stepX, stepY;
            for (int x = -1; x < nVisibleTilesX + 2; x++)
            {
                for (int y = -1; y < nVisibleTilesY + 2; y++)
                {
                    c = GetTile(x + (int)fOffsetX, y + (int)fOffsetY);
                    stepX = x * nTileWidth - fTileOffsetX;
                    stepY = y * nTileHeight - fTileOffsetY;
                    //g.FillRectangle(Brushes.MediumPurple, stepX, stepY, nTileWidth, nTileHeight);
                    //g.Clear(Color.Transparent);
                    
                    switch (c)
                    {
                        case '.':
                            g.FillRectangle(Brushes.Transparent, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                        case 'l':
                            g.DrawImage(Resource1.shade, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                        case '#':
                            g.DrawImage(Resource1.plat, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                        case 'B':
                            g.DrawImage(Resource1.Tile_HK, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                        case '*':
                            g.DrawImage(Resource1.aspid, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                        case 'f':
                            g.DrawImage(Resource1.Husk, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                        case 'g':
                            g.DrawImage(Resource1.pillar, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                        default:
                            g.DrawImage(Resource1.Tile_HK, stepX, stepY, nTileWidth, nTileHeight);//heavy
                            break;
                    }
                    //g.DrawRectangle(Pens.Gray, stepX, stepY, nTileWidth, nTileHeight);
                }
            }

            g.DrawString("GEO: " + score, new Font("Consolas", 10, FontStyle.Italic), Brushes.White, 5, 5);
            g.DrawString("X to swing your nail", new Font("Consolas", 10, FontStyle.Italic), Brushes.White, 220, 5);

            player.MainSprite.posX = (player.fPlayerPosX - fOffsetX) * nTileWidth;
            player.MainSprite.posY = (player.fPlayerPosY - fOffsetY) * nTileHeight;

            nail.NailSprite.posX = ((player.fPlayerPosX - fOffsetX) * nTileWidth) + 15.0f;
            nail.NailSprite.posY = ((player.fPlayerPosY - fOffsetY) * nTileHeight);

            if (right == false)
                nail.NailSprite.posX = ((player.fPlayerPosX - fOffsetX) * nTileWidth) - 30.0f;

        }

        public void SetTile(float x, float y, char c)//changes the tile
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
            {
                int index = (int)y * nLevelWidth + (int)x;
                sLevel = sLevel.Remove(index, 1).Insert(index, c.ToString());
                Play();
                score += 100; 
              
            }
        }

        public char GetTile(float x, float y)
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
                return sLevel[(int)y * nLevelWidth + (int)x];
            else
                return ' ';
        }

        public void Play()
        {
            if (isP1)
            {
                thread = new Thread(PlayThread);
                thread.Start();
            }
            threadStop = new Thread(PlayStop);
            threadStop.Start();
        }
        private void PlayThread()
        {
            isP1 = false;
            soundPlayer.PlaySync();
            isP1 = true;            
        }

        private void PlayStop()
        {
            soundPlayer.Stop();
        }

    }
}
