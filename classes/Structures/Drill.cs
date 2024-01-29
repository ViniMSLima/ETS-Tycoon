using System.Windows.Forms;
using System.Drawing;
using MotherClasses;
using Characters;
using EtsTycoon;

namespace Structures
{
    public class Drill : Structure
    {
        public int Index { get; set; }

        public Drill()
        {
            StructureType = "Apprentice";

            Index = 0;
            this.Buy = false;
            this.Price = 20;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/machines/drill.png")},
                {"buy_structure", Bitmap.FromFile("sprites/machines/buy_drill.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/machines/buy_drill_down.png")},
            };

            this.Img = Images["buy_structure"];
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            float h = 80, w = 90;

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
                    this.Img = this.Apprentice.Img[0];
                    Index++;
                }
                else
                {
                    this.Img = this.Apprentice.Img[1];
                    Index++;
                    if (Index > 2 * speed)
                        Index = 0;
                }
            }

            g.DrawImage(Img, roomX + 20, roomY - 20, 200, 200);

            if (this.Apprentice != null)
                DrawText(g, this.Apprentice.Name.Split(" ")[0], new PointF(roomX + 100, roomY + 30));
        }
    }
}
