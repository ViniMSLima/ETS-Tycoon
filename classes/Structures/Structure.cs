using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using Characters;
using EtsTycoon;

namespace Structures
{
    public class Structure
    {
        public float H { get; set; }
        public float W { get; set; }

        public string StructureType { get; set; }
        public int Amount { get; set; } = 1;

        public Apprentice Apprentice { get; set; }
        public Instructor Instructor { get; set; }

        public int Index { get; set; } = 0;
        public List<Apprentice> Duo { get; set; } = new();

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
                Sound.PlaySFX1(0);
            }
            else
            {
                MessageBox.Show("Not enough money!");
                this.Img = Images["buy_structure"];
            }
        }

        public void BuyCharacter(int index)
        {
            if (CharactersStore.Cart.Count > 0)
            {
                var Price = Game.Apprentices[CharactersStore.Cart[0]].Salary + Game.Apprentices[CharactersStore.Cart[1]].Salary;

                if (Player.Money < Price)
                {
                    MessageBox.Show("Not enough money!");
                    Game.OpenApprenticeStore = null;
                    CharactersStore.Cart = new() { };
                }
                else
                {
                    Player.Money -= Price;
                    Game.OpenApprenticeStore = null;

                    if (this.Duo.Count < 1)
                    {
                        this.Duo = new()
                        {
                            Game.Apprentices[CharactersStore.Cart[0]],
                            Game.Apprentices[CharactersStore.Cart[1]],
                        };

                        Player.CoinPerSecond += this.Duo[0].Gain;
                        Player.CoinPerSecond += this.Duo[1].Gain;

                        Player.Apprentices.Add(this.Duo[0]);
                        Player.Apprentices.Add(this.Duo[1]);

                        Game.Apprentices.Remove(this.Duo[0]);
                        Game.Apprentices.Remove(this.Duo[1]);
                        CharactersStore.StoreIndex = 0;

                        CharactersStore.Cart = new() { };
                    }
                    else
                        MessageBox.Show("Apprentices working here!!!");
                }
            }

            else if (StructureType == "Apprentice")
            {
                if (this.Apprentice == null)
                {
                    if(Player.Money >= Game.Apprentices[index].Salary)
                    {

                    this.Apprentice = Game.Apprentices[index];

                    Player.CoinPerSecond += this.Apprentice.Gain;
                    Player.Money -= this.Apprentice.Salary;
                    Game.OpenApprenticeStore = null;
                    CharactersStore.StoreIndex = 0;
                    Player.Apprentices.Add(this.Apprentice);
                    Game.Apprentices.Remove(Game.Apprentices[index]);
                    }
                    else
                        MessageBox.Show("Not enough money!");
                }
                else
                    MessageBox.Show("FULL!");
            }
            else
            {
                if (this.Instructor == null)
                {
                    if(Player.Money >= Game.Instructors[index].Salary )
                    {

                    this.Instructor = Game.Instructors[index];

                    Player.CoinPerSecond *= this.Instructor.Gain;
                    Player.Money -= this.Instructor.Salary;
                    Game.OpenInstructorStore = null;
                    CharactersStore.StoreIndex = 0;
                    Player.Instructors.Add(this.Instructor);
                    Game.Instructors.Remove(Game.Instructors[index]);

                    Sound.PlaySFX1(0);
                    }
                    else
                    MessageBox.Show("Not enough money!");
                }

                else
                    MessageBox.Show("FULL!");
            }
        }

        public bool ClickCheck(PointF point)
        {
            bool inside = Clicker.ContainsClick(point, this.Points);

            if (inside)
            {
                if (this.Duo.Count > 0)
                {
                    MessageBox.Show("Can't add apprentices to the structure");
                }
                else
                {
                    if (this.Buy)
                    {
                        Sound.PlaySFX2(3);

                        if (StructureType == "Apprentice")
                        {
                            Game.OpenApprenticeStore = this;
                            if (this.Amount != 1)
                                CharactersStore.Double = true;
                            else
                                CharactersStore.Double = false;
                        }
                        else
                        {
                            Game.OpenInstructorStore = this;
                            CharactersStore.Double = false;
                        }
                    }

                    else BuyStructure();
                }

            }
            return inside;
        }

        public void DrawText(Graphics g, string text, PointF point)
        {
            Color textColor = Color.Black;
            SolidBrush textBrush = new(textColor);
            Font font = new("Arial", 12, FontStyle.Bold);

            if (this.Duo.Count > 0)
            {
                SizeF textSize = g.MeasureString(this.Duo[0].Name.Split(" ")[0], font);

                g.DrawImage(NameBar, point.X - 25, point.Y - 82, textSize.Width + 43, textSize.Height + 170);
                g.DrawString(this.Duo[0].Name.Split(" ")[0], font, textBrush, point);

                textSize = g.MeasureString(this.Duo[1].Name.Split(" ")[0], font);
                g.DrawImage(NameBar, point.X - 25, point.Y - 60, textSize.Width + 43, textSize.Height + 170);
                PointF point2 = new(point.X, point.Y + 20);
                g.DrawString(this.Duo[1].Name.Split(" ")[0], font, textBrush, point2);
            }
            else
            {
                SizeF textSize = g.MeasureString(text, font);
                g.DrawImage(NameBar, point.X - 25, point.Y - 82, textSize.Width + 43, textSize.Height + 170);
                g.DrawString(text, font, textBrush, point);
            }
        }
    }
}
