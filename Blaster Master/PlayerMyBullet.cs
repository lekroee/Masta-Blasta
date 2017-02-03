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
        int m_deg = 15;
        int m_radius = 35;

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
            // Purpose: Scroll the bullets 
            //------------------------------------------------------------------------------------------------------------------

            // Scroll bullets
            //base.setY(base.getY() - 15);
            int X = 0;
            int Y = 0;
            m_deg += 15;

            X = GetCos(m_deg) * m_radius;
            Y = GetSin(m_deg) * m_radius;

            // Apply coords
            base.setX(base.getX() + X);
            base.setY(base.getY() + Y - 5);
            
            // Sync collision rect
            base.setRectX(base.getX() + 2);
            base.setRectY(base.getY());
            base.setRectW(base.getW() - 5);
            base.setRectH(base.getH());
            
            // call to render
            this.Draw(Destination);
        }
        
        private int GetSin(int degAngle)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method (return sin)   
            //------------------------------------------------------------------------------------------------------------------

            
            return (int)Math.Sin(Math.PI * degAngle / 180);
        }

        private int GetCos(int degAngle)
        {
            //------------------------------------------------------------------------------------------------------------------
            //  Purpose: Method (return cosin)   
            //------------------------------------------------------------------------------------------------------------------

            
            return (int)Math.Cos(Math.PI * degAngle / 180);
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
