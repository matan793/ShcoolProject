using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;

namespace App1.Classes
{
    public enum StateType
    {
        idleLeft, idleRight, runLeft, runRight, jumpLeft, jumpRight, dieLeft, dieRight, attackLeft, attackRight,
        glideLeft, glideRight, slideLeft, slideRight, throwLeft, throwRight, climbUp, jumpAttackLeft, jumpAttackRight, jumpThrowLeft, jumpThrowRight
    }
    internal class Spaceship1
    {
        private double placeX; //מיקום אופקי
        private double placeY;//מיקום אנכי
        private Image image;//מראה הדמות
        private Canvas arena;//זירת המשחק
        private StateType state;

        private double speedX;//מהירות אופקית
        private DispatcherTimer moveTimer;//הטיימר שאחראי על תנועת הדמות

        public Spaceship1(double placeX, double placeY, Canvas arena, int size)
        {
            this.placeX = placeX;
            this.placeY = placeY;
            this.arena = arena;
            this.image = new Image();
            this.state = StateType.idleRight;
            this.image.Width = size;
            this.image.Height = size;
            this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spaceship1/player.png"));
            //MatchGifToState();
            Canvas.SetLeft(this.image, this.placeX);
            Canvas.SetTop(this.image, this.placeY);
            this.arena.Children.Add(this.image);
            this.speedX = 0;

            this.moveTimer = new DispatcherTimer();
            this.moveTimer.Interval = TimeSpan.FromMilliseconds(1);
            this.moveTimer.Start();
            this.moveTimer.Tick += MoveTimer_Tick;
        }
        /// <summary>
        /// הפעולה תתבצע אלף פעמים בשנייה אחת
        /// </summary>

        private void MoveTimer_Tick(object sender, object e)
        {
            this.placeX += this.speedX;
            Canvas.SetLeft(this.image, this.placeX);
            if (this.placeX <= 0)
            {
                this.placeX += 2;
                Canvas.SetLeft(this.image, this.placeX);
                this.speedX = 0;
            }
            if (this.placeX + this.image.Width >= arena.ActualWidth)
            {
                this.placeX -= 2;
                Canvas.SetLeft(this.image, this.placeX);
                this.speedX = 0;
            }
        }

        /// <summary>
        /// הפעולה  מתאמת בין מצב הדמות לבין המראה שלה
        /// </summary>
        //private void MatchGifToState()
        //{
        //    switch (this.state)
        //    {
        //        case StateType.idleRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaIdleRight.gif")); break;
        //        case StateType.idleLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaIdleLeft.gif")); break;
        //        case StateType.runRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaRunRight.gif")); break;
        //        case StateType.runLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaRunLeft.gif")); break;
        //        case StateType.attackRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaAttackRight.gif")); break;
        //        case StateType.attackLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaAttackLeft.gif")); break;
        //        case StateType.jumpRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaJumpRight.gif")); break;
        //        case StateType.jumpLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaJumpLeft.gif")); break;
        //        case StateType.throwRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaThrowRight.gif")); break;
        //        case StateType.throwLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaThrowLeft.gif")); break;
        //        case StateType.dieRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaDieRight.gif")); break;
        //        case StateType.dieLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaDieLeft.gif")); break;
        //        case StateType.climbUp: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaClimb.gif")); break;
        //        case StateType.glideRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaGlideRight.gif")); break;
        //        case StateType.glideLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Ninja/NinjaGlideLeft.gif")); break;
        //    }
        //}
        public void GoRight()
        {
            if (state != StateType.runRight)
            {
                this.state = StateType.runRight;
                //MatchGifToState();
                this.speedX = 10;

            }
        }
        public void GoLeft()
        {
            if (state != StateType.runLeft)
            {
                this.state = StateType.runLeft;
                //MatchGifToState();
                this.speedX = -10;

            }
        }

        internal void Stop()
        {
            if (this.state == StateType.runLeft)
                this.state = StateType.idleLeft;
            else
                if (this.state == StateType.runRight)
                this.state = StateType.idleRight;
            //MatchGifToState();
            this.speedX = 0;

        }
    }
}
