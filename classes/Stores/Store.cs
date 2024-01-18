using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EtsTycoon
{
    public class Store
    {
        public static PointF[] Btn1 { get; set; } = 
            new PointF[]{
                new(Game.Pb.Width * 0.135f, Game.Pb.Height * 0.4f),
                new(Game.Pb.Width * 0.135f, Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f, Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f, Game.Pb.Height * 0.4f),
            };
        public static PointF[] Btn2 { get; set; } =
            new PointF[]{
                    new(Game.Pb.Width * 0.82f, Game.Pb.Height * 0.4f),
                    new(Game.Pb.Width * 0.82f, Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                    new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f, Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                    new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f, Game.Pb.Height * 0.4f),
            };

        public List<Image> Images { get; set; } = new()
        {
            Bitmap.FromFile("./sprites/backgrounds/storeBackground.png"),
            Bitmap.FromFile("./sprites/backgrounds/storeCard.png"),
            Bitmap.FromFile("./sprites/button/leftButton.png"),
            Bitmap.FromFile("./sprites/button/rightButton.png"),
            Bitmap.FromFile("./sprites/button/leftButtonClicked.png"),
            Bitmap.FromFile("./sprites/button/rightButtonClicked.png"),
        };

        public Store()
        {

        }

        public virtual void Draw(Graphics g) { }

        public static bool ClickCheck(PointF point, PointF[] a)
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

            if(inside)
                MessageBox.Show(a[0].ToString());
            return inside;
        }
    }
}