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


        public Image Img { get; set; }
        public PointF[] Points { get; set; }
        public int Price { get; set; }
        public bool Buy { get; set; }
        public Image[] ApprenticeAnimation { get; set; }
        public Dictionary<string, Image> Images { get; set; }
        public Bitmap NameBar { get; set; } = new("./sprites/A.png");

        public virtual void Draw(Graphics g, float roomX, float roomY) { }

        public void BuyCheck()
        {
            if (this.Buy && this.Img != Images["structure"])
                this.Img = Images["structure"];
            
        }

        public virtual void BuyStructure() { }

        public void BuyCharacter(Graphics g, int index)
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


        public virtual bool ClickCheck(PointF point, Graphics g) { return false; }

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