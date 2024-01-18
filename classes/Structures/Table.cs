using System.Windows.Forms;
using System.Drawing;
using EtsTycoon;
using Characters;

namespace Structures
{
    public class Table : Structure
    {
        public int Index { get; set; }
        Bitmap NameBar { get; set; }= new("./sprites/A.png");

        public Table()
        {
            Index = 0;
            this.Buy = false;
            this.Img = Bitmap.FromFile("sprites/table/buy_table.png");
            this.Price = 20;

            Image[] a = 
            {
                Bitmap.FromFile("./sprites/apprentice/table/tavares/tavares1.png"),
                Bitmap.FromFile("./sprites/apprentice/table/tavares/tavares2.png"),
            };

            this.Images = new()
            {
                {"table", Bitmap.FromFile("sprites/table/table.png")},
                {"buy_table", Bitmap.FromFile("sprites/table/buy_table.png")},
                {"buy_table_down", Bitmap.FromFile("sprites/table/buy_table_down.png")},
                {"table_apprentice1", Bitmap.FromFile("./sprites/apprentice/table/tavares/tavares1.png")},
                {"table_apprentice2", Bitmap.FromFile("./sprites/apprentice/table/tavares/tavares2.png")},
            };

            this.ApprenticeAnimation = a;
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            float h = 40, w = 90;

            Pen pen = new(Color.Red, 5f);

            PointF[] test = new PointF[]{
                new(0, 0),
                new(h, 0),
                new(h, w),
                new(0, w),
                new(0, 0),
            }.ToIsometric(roomX + 120, roomY + 145);

            this.Points = test;

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
                DrawText(g, this.Apprentice.Name, new PointF(roomX + 100, roomY + 30));

        }

        public bool ClickCheck(PointF point, Graphics g)
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

        public void BuyStructure()
        {
            this.Img = Images["buy_table_down"];
            if (Player.Money >= this.Price)
            {
                this.Buy = true;
                Player.Money -= this.Price;
            }
            else
            {
                MessageBox.Show("Not enough money!");
                this.Img = Images["buy_table"];
            }
        }

        public void BuyCheck()
        {
            if (this.Buy)
                this.Img = Images["table"];
        }

        public void BuyApprentice(Graphics g, int index)
        {
            if (Player.Money >= 300 && this.Apprentice == null)
            {
                this.Apprentice = Game.Apprentices[index];

                Player.CoinPerSecond += this.Apprentice.CoinPerSecond;
                Player.Money -= this.Apprentice.Salary;
                Game.OpenApprenticeStore = null;
            }

            else
            {
                MessageBox.Show("Not enough money!");
            }
        }

        private void DrawText(Graphics g, string text, PointF point)
        {
            Color textColor = Color.Black;
            SolidBrush textBrush = new(textColor);

            Font font = new("Arial", 12, FontStyle.Bold);
            SizeF textSize = g.MeasureString(text, font);

            g.DrawImage(NameBar, point.X - 22, point.Y - 82, textSize.Width + 40, textSize.Height + 170);
            g.DrawString(text, font, textBrush, point);
        }
    }
}