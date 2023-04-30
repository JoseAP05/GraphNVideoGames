using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Scroll
{
    public partial class MAIN : Form
    {
        Map map;
        Player player;
        Nail nail;
        
        float fElapsedTime;

        SoundPlayer sPlayer;
        Thread thread, thread2;
        bool isP1 = true;
        public static bool isRight = true;
        public static bool nailSwing = false;

        // Camera properties
        float fCameraPosX = 0.0f;
        float fCameraPosY = 0.0f;
        bool left, right;

        public MAIN()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            map                 = new Map(PCT_CANVAS.Size);
            player              = new Player();
            nail = new Nail();
            PCT_CANVAS.Image    = map.bmp;
            fElapsedTime        = 0.05f;
            left                = false;
            right               = false;
            sPlayer             = new SoundPlayer(Resource1.best);

            Play();
        }

        public void Play()
        {
            thread = new Thread(PlayThread);
            thread.Start();
        }

        private void PlayThread()
        {
            sPlayer.PlaySync();
        }

        private void MAIN_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:                    
                    left = true;
                    isRight = false;
                    //nDirModY = 1;
                    break;
                case Keys.Right:
                    right = true;
                    isRight = true;
                    //nDirModY = 0;
                    break;
                case Keys.Up:
                    player.FPlayerVelY = -6.0f;
                    player.bPlayerOnGround = false;
                    break;
                case Keys.Down:
                    player.FPlayerVelY = 6.0f;
                    break;
                case Keys.X:
                    nailSwing = true;
                    if (isRight == false)
                        nail.NailSprite.MoveLeft();
                    else
                        nail.NailSprite.MoveRight();
                    break;
            }

            UpdateEnv();
        }

        private void MAIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Space:
                    if (player.FPlayerVelY == 0 && isRight == false)// sin brincar o cayendo
                    {
                        player.FPlayerVelY = -15;
                        player.MainSprite.MoveDownL(); ;
                        player.bPlayerOnGround = false;
                    }
                    if (player.FPlayerVelY == 0 && isRight == true)// sin brincar o cayendo
                    {
                        player.FPlayerVelY = -15;
                        player.MainSprite.MoveDownR(); ;
                        player.bPlayerOnGround = false;
                    }
                    break;

            }
        }

        private void MAIN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                return;

            if (e.KeyCode == Keys.X)
                nailSwing = false;

            left = false;
            right = false;

            player.Stop();
            nail.Stop();
        }

        private void PNL_MAIN_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            UpdateEnv();
        }

        private void UpdateEnv()
        {
            if (left)
                player.Left(fElapsedTime);
            if (right)
                player.Right(fElapsedTime);
            
            fCameraPosX = player.fPlayerPosX;
            fCameraPosY = player.fPlayerPosY;

            map.Draw(new PointF(fCameraPosX,fCameraPosY),player.fPlayerPosX.ToString() , player, nail, isRight);
            player.Update(fElapsedTime, map);
            if(nailSwing == true)
                nail.Update(fElapsedTime, map, player.fPlayerPosX, player.fPlayerPosY, nailSwing, isRight);
            PCT_CANVAS.Invalidate();
        }
    }
}
