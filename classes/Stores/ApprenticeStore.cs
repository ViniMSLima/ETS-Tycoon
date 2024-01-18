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
            g.DrawImage(Images[0], 
                Game.Pb.Width * 0.1f, 
                Game.Pb.Height * 0.1f, 
                Game.Pb.Width * 0.8f, 
                Game.Pb.Height * 0.8f
            );
            g.DrawImage(Images[1], 
                Game.Pb.Width * 0.195f, 
                Game.Pb.Height * 0.25f, 
                Game.Pb.Width * 0.2f, 
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[1],
                Game.Pb.Width * 0.405f, 
                Game.Pb.Height * 0.25f, 
                Game.Pb.Width * 0.2f, 
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[1],
                Game.Pb.Width * 0.615f,
                Game.Pb.Height * 0.25f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[RightButton], 
                Game.Pb.Width * 0.135f,
                Game.Pb.Height * 0.4f,
                Game.Pb.Width * 0.05f,
                Game.Pb.Height * 0.2f
            );
            g.DrawImage(Images[LeftButton], 
                Game.Pb.Width * 0.82f,
                Game.Pb.Height * 0.4f,
                Game.Pb.Width * 0.05f,
                Game.Pb.Height * 0.2f
            );

            g.DrawImage(Game.Apprentices[StoreIndex].img[0], 
                Game.Pb.Width * 0.190f,
                Game.Pb.Height * 0.2f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.4f
            );

            g.DrawImage(Game.Apprentices[StoreIndex + 1].img[0], 
                Game.Pb.Width * 0.400f,
                Game.Pb.Height * 0.2f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.4f
            );

            g.DrawImage(Game.Apprentices[StoreIndex + 2].img[0], 
                Game.Pb.Width * 0.610f,
                Game.Pb.Height * 0.2f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.4f
            );

            DrawText(g, "Name: " + Game.Apprentices[StoreIndex].Name, new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.55f));
            DrawText(g, "Age: "  + Game.Apprentices[StoreIndex].Age,  new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.60f));
            DrawText(g, "Name: " + Game.Apprentices[StoreIndex + 1].Name, new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.55f));
            DrawText(g, "Age: "  + Game.Apprentices[StoreIndex + 1].Age,  new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.60f));
            DrawText(g, "Name: " + Game.Apprentices[StoreIndex  +2].Name, new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.55f));
            DrawText(g, "Age: "  + Game.Apprentices[StoreIndex + 2].Age,  new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.60f));

            RightButton = 2;
            LeftButton = 3;
        }

        private void DrawText(Graphics g, string text, PointF point)
        {
            Color textColor = Color.BlanchedAlmond;
            SolidBrush textBrush = new(textColor);

            Font font = new("Arial", 15, FontStyle.Bold);
            SizeF textSize = g.MeasureString(text, font);

            g.DrawString(text, font, textBrush, point);
        }

        
    }
}
