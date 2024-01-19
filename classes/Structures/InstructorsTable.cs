using System.Windows.Forms;
using System.Drawing;
using EtsTycoon;
using Characters;

namespace Structures
{
    
    public class InstructorsTable : Structure
    {
        public int Index { get; set; }
        public Instructor Instructor { get; set; }

        public InstructorsTable()
        {
            Index = 0;
            this.Buy = false;
            this.Img = Bitmap.FromFile("sprites/table/buy_table.png");
            this.Price = 50;

            this.Images = new()
            {
                {"table", Bitmap.FromFile("sprites/table/table.png")},
                {"buy_table", Bitmap.FromFile("sprites/table/buy_table.png")},
                {"buy_table_down", Bitmap.FromFile("sprites/table/buy_table_down.png")},
                {"table_apprentice1", Bitmap.FromFile("./sprites/apprentice/table/tavares/tavares1.png")},
                {"table_apprentice2", Bitmap.FromFile("./sprites/apprentice/table/tavares/tavares2.png")},
            };
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

            if (this.Buy && this.Instructor != null)
            {
                const int speed = 3;
                if (Index < speed)
                {
                    this.Img = this.Instructor.img[0];
                    Index++;
                }
                else
                {
                    this.Img = this.Instructor.img[1];
                    Index++;
                    if (Index > 2 * speed)
                        Index = 0;
                }
            }

            g.DrawImage(Img, roomX, roomY, 200, 200);

            if (this.Instructor != null)
                DrawText(g, this.Instructor.Name.Split(" ")[0], new PointF(roomX + 100, roomY + 30));

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
                    Game.OpenInstructorStore = this;

                else BuyStructure();
            }

            return inside;
        }

        public override void BuyStructure()
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

        public override void BuyCheck()
        {
            if (this.Buy)
                this.Img = Images["table"];
        }

        public override void BuyCharacter(Graphics g, int index) {
            if (Player.Money >= 300 && this.Instructor == null)
            {
                this.Instructor = Game.Instructors[index];

                Player.CoinPerSecond *= this.Instructor.Boost; //CHECK OVERPOWER HERE
                Player.Money -= this.Instructor.Salary;
                Game.OpenInstructorStore = null;
                Store.StoreIndex = 0;
            }

            else
            {
                MessageBox.Show("Not enough money!");
            }
         }
    }
}
