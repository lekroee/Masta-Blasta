//   - Blaster Master Class -
// Purpose:      Player's bullets
// Rev:          1.0
// Last updated: 22/03/10

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlasterMaster
{
    public class PlayerMyBullet : clsPlayerBullet
    {

        // Obj refs and instances
        private System.Drawing.Bitmap bullet;
        private ImageAttributes ImagingAtt = new ImageAttributes();

        public PlayerMyBullet(int x, int y) : base(x, y)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Class constructor  
            //------------------------------------------------------------------------------------------------------------------

            // Load resource image(s) & remove background and thu a sprite is born 
            bullet = BlasterMaster.Properties.Resources.playerBullet;
            bullet.MakeTransparent(Color.White);
        }

        public override void moveBullets(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Twirl the Bullets  
            //------------------------------------------------------------------------------------------------------------------

            // Scroll bullets
            //base.setY(base.getY() - 15);                    
            double x = 0;
            double y = 0;
            double deg = 360 / 12;
            double radius = 25;
            
            // Fetch x & y
            x = GetCos(x * deg + 90) * radius;
            y = GetSin(y * deg + 90) * radius;
            
            // Apply coords
            base.setX(base.getX() + -Convert.ToInt32(x));
            base.setY(base.getY() + -Convert.ToInt32(y));
            
            // Sync collision rect
            base.setRectX(base.getX() + 2);
            base.setRectY(base.getY());
            base.setRectW(base.getW() - 5);
            base.setRectH(base.getH());
            
            // call to render
            this.Draw(Destination);
        }
        
        private double GetSin(double degAngle)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method (return sin)   
            //------------------------------------------------------------------------------------------------------------------

            return Math.Sin(Math.PI * degAngle / 180);
        }

        private double GetCos(double degAngle)
        {
            //------------------------------------------------------------------------------------------------------------------
            //  Purpose: Method (return cosin)   
            //------------------------------------------------------------------------------------------------------------------

            return Math.Cos(Math.PI * degAngle / 180);
        }
        private void Draw(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to render the player's sprite  
            //------------------------------------------------------------------------------------------------------------------

            // Draw sprite
            Destination.DrawImage(bullet, new Rectangle(base.getX(), base.getY(), base.getW(), base.getH()), 0, 0, base.getW(), base.getH(), GraphicsUnit.Pixel, ImagingAtt);
        }
    }
}
