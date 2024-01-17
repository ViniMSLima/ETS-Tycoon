using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using Structures;
using MotherClasses;

namespace Rooms
{
    public class DigitalRoom : Room
    {
        public PointF[] Polygon { get; set; }

        public DigitalRoom()
        {
            this.FloorImg = Bitmap.FromFile("./sprites/floor/aaa.png");

            float[] a = {PositionX + 126, PositionX + 221, PositionX + 362, PositionX + 457,
                         PositionX + 226, PositionX + 321, PositionX + 462, PositionX + 557,
                         PositionX + 326, PositionX + 421, PositionX + 562, PositionX + 657,
                         PositionX + 486, PositionX + 581, PositionX + 722, PositionX + 817,
                         PositionX + 586, PositionX + 681, PositionX + 822, PositionX + 917};

            float[] b = {PositionY + 158, PositionY + 206, PositionY + 281, PositionY + 329,
                         PositionY + 108, PositionY + 156, PositionY + 231, PositionY + 279,
                         PositionY +  58, PositionY + 106, PositionY + 181, PositionY + 229,
                         PositionY -  22, PositionY +  26, PositionY + 101, PositionY + 149,
                         PositionY -  72, PositionY -  24, PositionY +  51, PositionY +  99};

            this.PositionsX = a;
            this.PositionsY = b;

            for (int i = 0; i < a.Length; i++)
            {
                this.Structures.Add(new Table());
            }
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(FloorImg,
                PositionX, PositionY, 800+80*4, 450+45*4
            );

            for (int i = 0; i < this.Structures.Count; i++)
                this.Structures[i].Draw(g, PositionX + PositionsX[i], PositionY + PositionsY[i]);

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
            foreach (Table Tb in Structures.Cast<Table>())
                Tb.BuyCheck();
        }

        public override void ClickCheckAll(System.Drawing.Point point, Graphics g)
        {
            foreach (Table Tb in Structures.Cast<Table>())
                Tb.ClickCheck(point, g);
        }
    }
}
