using System.Windows.Forms;
using System.Drawing;
using EtsTycoon;
using Characters;

namespace Structures
{
    public class Machine : Structure
    {
        public int Index { get; set; }
        public Apprentice Apprentice { get; set; }

        public Machine()
        {
            Index = 0;
            this.Buy = false;
            this.Price = 20;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/machines/drill.png")},
                {"buy_structure", Bitmap.FromFile("sprites/machines/buy_machine.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/machines/buy_machine_down.png")},
            };

            this.Img = Images["buy_structure"];
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            float h = 40, w = 90;

            Pen pen = new(Color.Red, 5f);

            PointF[] points = new PointF[]{
                new(0, 0),
                new(h, 0),
                new(h, w),
                new(0, w),
                new(0, 0),
            }.ToIsometric(roomX + 120, roomY + 145);

            this.Points = points;

            if (this.Buy && this.Apprentice != null)
            {
                const int speed = 3;
                if (Index < speed)
                {
                    this.Img = this.Apprentice.img[0];
                    Index++;
                }
                else
                {
                    this.Img = this.Apprentice.img[1];
                    Index++;
                    if (Index > 2 * speed)
                        Index = 0;
                }
            }

            g.DrawImage(Img, roomX, roomY, 200, 200);

            if (this.Apprentice != null)
                DrawText(g, this.Apprentice.Name.Split(" ")[0], new PointF(roomX + 100, roomY + 30));
        }

        public override bool ClickCheck(PointF point, Graphics g)
        {
            int num_vertices = this.Points.Length;
            double x = point.X, y = point.Y;
            bool inside = false;

            PointF p1 = this.Points[0], p2;

            for (int i = 1; i <= num_vertices; i++)
            {
                p2 = this.Points[i % num_vertices];

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

            if (inside)
            {
                if (this.Buy)
                    Game.OpenApprenticeStore = this;

                else BuyStructure();
            }

            return inside;
        }

        public override void BuyStructure()
        {
            this.Img = Images["buy_structure_down"];
            if (Player.Money >= this.Price)
            {
                this.Buy = true;
                Player.Money -= this.Price;
            }
            else
            {
                MessageBox.Show("Not enough money!");
                this.Img = Images["buy_structure"];
            }
        }
        public override void BuyCharacter(Graphics g, int index)
        {
            if (Player.Money >= 300 && this.Apprentice == null)
            {
                this.Apprentice = Game.Apprentices[index];

                Player.CoinPerSecond += this.Apprentice.CoinPerSecond;
                Player.Money -= this.Apprentice.Salary;
                Game.OpenApprenticeStore = null;
                Store.StoreIndex = 0;
                Player.Apprentices.Add(this.Apprentice);
            }

            else
                MessageBox.Show("Not enough money!");
        }

    }
}
