using System;
using System.Drawing;

namespace EtsTycoon
{
    public class InstructorStore : Store
    {
        public InstructorStore()
        {

        }

        public override void Draw(Graphics g) 
        {
            g.DrawImage(Bitmap.FromFile("./sprites/backgrounds/store_background.png"), 200, 100, 1500, 900);
        }
    }
}