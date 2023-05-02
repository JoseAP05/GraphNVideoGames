using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Scroll
{
    public class PlayerSprite
    {
        int increment;
        RectangleF size, display;
        Bitmap imgDisplay, imgL, imgR, imgDR, imgDL;
        public int counter;

        public float posX
        {
            set { display.X = value; }
            get { return posX; }
        }

        public float posY
        {
            set { display.Y = value; }
            get { return posY; }
        }

        public Bitmap ImgDisplay
        {
            get { return imgDisplay; }
            set { imgDisplay = value; }
        }

        public PlayerSprite(Size original, Size display, Point starting, Bitmap right, Bitmap left, Bitmap downr, Bitmap downl)
        {
            counter = 0;
            this.increment = original.Width;
            this.display = new RectangleF(starting.X, starting.Y, display.Width, display.Height);
            this.size = new RectangleF(0, 0, original.Width, original.Height);
            this.imgR = right;
            this.imgL = left;
            this.imgDR = downr;
            this.imgDL = downl;
            this.imgDisplay = downr;
            this.imgDisplay = right;
        }

        public void Frame(int x)
        {
            size.X = (x * size.Width) % imgDisplay.Width;
        }

        public void MoveLeft()
        {
            imgDisplay = imgL;
            size.X = (increment + size.X) % imgDisplay.Width;
        }

        public void MoveDownR()
        {
            imgDisplay = imgDR;
            size.X = (increment + size.X) % imgDisplay.Width;
        }

        public void MoveDownL()
        {
            imgDisplay = imgDL;
            size.X = (increment + size.X) % imgDisplay.Width;
        }

        public void MoveRight()
        {
            imgDisplay = imgR;
            size.X = (increment + size.X) % imgDisplay.Width;
        }
        public void MoveSlow(int value)
        {
            if (counter % value == 0)
                size.X = (increment + size.X) % imgDisplay.Width;

            counter++;
        }

        public void Display(Graphics g)//
        {
            g.DrawImage(imgDisplay, display, size, GraphicsUnit.Pixel);
        }
    }
}
