using System;
using System.Drawing;

namespace EtsTycoon
{
    public class ApprenticeStore : Store
    {
        public ApprenticeStore()
        {

        }

        public override void Draw(Graphics g) 
        {
            g.DrawImage(Bitmap.FromFile("./sprites/backgrounds/store_background.png"), Game.Pb.Width * 0.1f, Game.Pb.Height * 0.1f, Game.Pb.Width * 0.8f, Game.Pb.Height * 0.8f);
        }
    }
}