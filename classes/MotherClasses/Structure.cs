using System.Collections.Generic;
using System.Drawing;
using System.Formats.Tar;
using System.Windows.Forms;
using Characters;
using EtsTycoon;

namespace MotherClasses
{
    public class Structure
    {
        public float H { get; set; }
        public float W { get; set; }

        public string StructureType { get; set; }

        public Apprentice Apprentice { get; set; }
        public Instructor Instructor { get; set; }

        public int Index { get; set; } = 0;


        public Image Img { get; set; }
        public PointF[] Points { get; set; }
        public int Price { get; set; }
        public bool Buy { get; set; } = false;
        public Image[] ApprenticeAnimation { get; set; }
        public Dictionary<string, Image> Images { get; set; }
        public Bitmap NameBar { get; set; } = new("./sprites/A.png");

        public virtual void Draw(Graphics g, float roomX, float roomY) { }

        public void BuyCheck()
        {
            if (this.Buy && this.Img != Images["structure"])
                this.Img = Images["structure"];  
        }

        public void BuyStructure() 
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

        public void BuyCharacter(int index)
        {
            if (StructureType == "Apprentice")
            {

                if (Player.Money >= Game.Apprentices[index].Salary && this.Apprentice == null)
                {
                    this.Apprentice = Game.Apprentices[index];

                    Player.CoinPerSecond += this.Apprentice.Gain;
                    Player.Money -= this.Apprentice.Salary;
                    Game.OpenApprenticeStore = null;
                    CharactersStore.StoreIndex = 0;
                    Player.Apprentices.Add(this.Apprentice);
                }

                else
                    MessageBox.Show("Not enough money!");
            }
            else
            {
                if (Player.Money >= Game.Instructors[index].Salary && this.Instructor == null)
                {
                    this.Instructor = Game.Instructors[index];

                    Player.CoinPerSecond *= this.Instructor.Gain;
                    Player.Money -= this.Instructor.Salary;
                    Game.OpenInstructorStore = null;
                    CharactersStore.StoreIndex = 0;
                    Player.Instructors.Add(this.Instructor);
                    Sound.PlaySFX1(0);
                }

                else
                    MessageBox.Show("Not enough money!");
            }
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
                {
                    Sound.PlaySFX2(3);

                    if(StructureType == "Apprentice")
                        Game.OpenApprenticeStore = this;
                    else 
                        Game.OpenInstructorStore = this;
                }   

                else BuyStructure();
            }

            return inside;
        }  

        public void DrawText(Graphics g, string text, PointF point)
        {
            Color textColor = Color.Black;
            SolidBrush textBrush = new(textColor);

            Font font = new("Arial", 12, FontStyle.Bold);
            SizeF textSize = g.MeasureString(text, font);

            g.DrawImage(NameBar, point.X - 25, point.Y - 82, textSize.Width + 43, textSize.Height + 170);
            g.DrawString(text, font, textBrush, point);
        }

    }

}