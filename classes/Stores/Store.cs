using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Structures;

namespace EtsTycoon
{
    public class Store
    {
        public static int StoreIndex { get; set; } = 0;
        public static int RightButton { get; set; } = 2;
        public static int LeftButton { get; set; } = 3;
        public static PointF[] Btn1 { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.135f,  Game.Pb.Height * 0.4f),
                new(Game.Pb.Width * 0.135f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f),
            };
        public static PointF[] Btn2 { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.82f,  Game.Pb.Height * 0.4f),
                new(Game.Pb.Width * 0.82f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f),
            };

        public static PointF[] Btn3 =
            new PointF[]{
                new(Game.Pb.Width * 0.217f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.217f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.217f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.217f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
            };

        public static PointF[] Btn4 =
            new PointF[]{
                new(Game.Pb.Width * 0.427f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.427f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.427f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.427f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
            };

        public static PointF[] Btn5 =
            new PointF[]{
                new(Game.Pb.Width * 0.637f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.637f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.637f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.637f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
            };

        public static PointF[] Close =
            new PointF[]{
                new(Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.1f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.1f,  Game.Pb.Height * 0.2f),
            };

        public List<Image> Images { get; set; } = new()
        {
            Bitmap.FromFile("./sprites/backgrounds/storeBackground.png"),
            Bitmap.FromFile("./sprites/backgrounds/storeCard.png"),
            Bitmap.FromFile("./sprites/button/leftButton.png"),
            Bitmap.FromFile("./sprites/button/rightButton.png"),
            Bitmap.FromFile("./sprites/button/leftButtonClicked.png"),
            Bitmap.FromFile("./sprites/button/rightButtonClicked.png"),
            Bitmap.FromFile("./sprites/coin/Coin.gif"),
            Bitmap.FromFile("./sprites/button/close_button.png")
        };

        public Store()
        {

        }

        public virtual void Draw(Graphics g) { }

        public static bool ClickCheck(PointF point, PointF[] a, Structure b, Graphics g)
        {

            int num_vertices = a.Length;
            double x = point.X, y = point.Y;
            bool inside = false;

            PointF p1 = a[0], p2;

            for (int i = 1; i <= num_vertices; i++)
            {
                p2 = a[i % num_vertices];

                float miny = p1.Y;
                if (p2.Y < p1.Y) miny = p2.Y;

                float maxy = p1.Y;
                if (p2.Y > p1.Y) maxy = p2.Y;

                float maxx = p1.X;
                if (p2.X > p1.X) maxx = p2.X;

                if (y > miny && y <= maxy && x <= maxx)
                {
                    double x_intersection =
                    (y - p1.Y) * (p2.X - p1.X) /
                    (p2.Y - p1.Y) + p1.X;

                    if (p1.X == p2.X || x <= x_intersection)
                        inside = !inside;
                }

                p1 = p2;
            }

            if (inside && Game.OpenApprenticeStore != null)
            {
                if(point.Y < 300)
                {
                    Game.OpenApprenticeStore = null;
                }
                if(point.X > 1581)
                {
                    LeftButton = 5;
                    if (StoreIndex < 15)
                    {
                        StoreIndex++;
                    }
                }
                else if(point.X > 1224)
                {
                    b.BuyCharacter(g, StoreIndex + 2);
                }
                else if(point.X > 821)
                {
                    b.BuyCharacter(g, StoreIndex + 1);
                    
                }
                else if(point.X > 418)
                {
                    b.BuyCharacter(g, StoreIndex);

                }
                else if (point.X < 350)
                {
                    RightButton = 4;
                    if (StoreIndex > 0)
                    {
                        StoreIndex--;
                    }
                    
                }
            }
            else if (inside && Game.OpenInstructorStore != null)
            {
                if(point.Y < 300)
                {
                    Game.OpenInstructorStore = null;
                }
                if(point.X > 1581)
                {
                    LeftButton = 5;
                    if (StoreIndex < 6)
                    {
                        StoreIndex++;
                    }
                }
                else if(point.X > 1224)
                {
                    b.BuyCharacter(g, StoreIndex + 2);
                }
                else if(point.X > 821)
                    b.BuyCharacter(g, StoreIndex + 1);
                
                else if(point.X > 418)
                {
                    b.BuyCharacter(g, StoreIndex);

                }
                else if (point.X < 350)
                {
                    RightButton = 4;
                    if (StoreIndex > 0)
                    {
                        StoreIndex--;
                    }
                }
            }

            return inside;
        }

        public void DrawText(Graphics g, string text, PointF point, int Size)
        {
            Color textColor = Color.BlanchedAlmond;
            SolidBrush textBrush = new(textColor);

            Font font = new("Arial", Size, FontStyle.Bold);
            g.DrawString(text, font, textBrush, point);
        }
    }
}
