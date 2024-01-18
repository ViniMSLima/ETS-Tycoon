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
            g.DrawImage(Images[0], 
                Game.Pb.Width * 0.1f, 
                Game.Pb.Height * 0.1f, 
                Game.Pb.Width * 0.8f, 
                Game.Pb.Height * 0.8f
            );
            g.DrawImage(Images[1], 
                Game.Pb.Width * 0.18f, 
                Game.Pb.Height * 0.25f, 
                Game.Pb.Width * 0.2f, 
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[1],
                Game.Pb.Width * 0.4f, 
                Game.Pb.Height * 0.25f, 
                Game.Pb.Width * 0.2f, 
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[1],
                Game.Pb.Width * 0.62f, 
                Game.Pb.Height * 0.25f, 
                Game.Pb.Width * 0.2f, 
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[2], 
                Game.Pb.Width * 0.14f, 
                Game.Pb.Height * 0.4f, 
                Game.Pb.Width * 0.03f, 
                Game.Pb.Height * 0.2f
            );
            g.DrawImage(Images[3], 
                Game.Pb.Width * 0.83f, 
                Game.Pb.Height * 0.4f, 
                Game.Pb.Width * 0.03f, 
                Game.Pb.Height * 0.2f
            );
        }
    }
}