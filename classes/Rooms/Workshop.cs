using System.Windows.Forms;
using System.Drawing;
using MotherClasses;
using Structures;
using EtsTycoon;

namespace Rooms
{
    public class Workshop : Room
    {
        public PointF[] Polygon { get; set; }

        public Workshop()
        {
            this.FloorImg = Bitmap.FromFile("./sprites/floor/workshop.png");

            float[] a = {
                         PositionX + 1300, PositionX + 1200, PositionX + 1100,
                         PositionX + 1000, PositionX + 800,
                         PositionX + 350
                         };

            float[] b = {
                         
                         PositionY + 750, PositionY + 700, PositionY + 650,
                         PositionY + 800, PositionY + 700,
                         PositionY + 350
                         };

            this.PositionsX = a;
            this.PositionsY = b;

            for (int i = 0; i < a.Length -3; i++)
                this.Structures.Add(new Drill());

            this.Structures.Add(new HexagonalTable());
            this.Structures.Add(new HexagonalTable());

            // this.Structures.Add(new InstructorsTable());
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(FloorImg,
                PositionX + Game.GeneralPosition.X, PositionY + Game.GeneralPosition.Y, 1600, 1600 
            );

            for (int i = 0; i < this.Structures.Count; i++)
                this.Structures[i].Draw(g, PositionX + PositionsX[i] + Game.GeneralPosition.X, PositionY + PositionsY[i] + Game.GeneralPosition.Y);
        }

        public override void ClickCheck(PointF point)
        {
            int num_vertices = this.Polygon.Length;
            double x = point.X, y = point.Y;
            bool inside = false;

            PointF p1 = this.Polygon[0], p2;

            for (int i = 1; i <= num_vertices; i++)
            {
                p2 = this.Polygon[i % num_vertices];

                float miny = p1.Y;
                if (p2.Y < p1.Y) miny = p2.Y;

                float maxy = p1.Y;
                if (p2.Y > p1.Y) maxy = p2.Y;

                float maxx = p1.X;
                if (p2.X > p1.X) maxx = p2.X;

                if (y > miny && y <= maxy && x <= maxx)
                {
                    double x_intersection
                        = (y - p1.Y) * (p2.X - p1.X) /
                          (p2.Y - p1.Y) + p1.X;

                    if (p1.X == p2.X || x <= x_intersection)
                        inside = !inside;
                }

                p1 = p2;
            }

            // Return the value of the inside flag
            MessageBox.Show(inside.ToString());
        }

        public override void BuyCheckAll()
        {

            for(int i = 0; i < Structures.Count; i++)
            {
                Structures[i].BuyCheck();
            }
        }

        public override bool ClickCheckAll(System.Drawing.Point point, Graphics g)
        {
            bool a, b = false;

            for(int i = 0; i < Structures.Count; i++)
            {
                a = Structures[i].ClickCheck(point, g);
                if(a)
                    b = true;
            }

            return b;
        }
    }
}
