using System.Windows.Forms;
using System.Drawing;

using MotherClasses;
using Characters;
using EtsTycoon;

namespace Structures
{
    public class Machine : Structure
    {

        public Machine()
        {
            StructureType = "Apprentice";

            H = 40;
            W = 90;

            this.Img = Images["buy_structure"];
            this.Price = 20;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/machines/machine2.png")},
                {"buy_structure", Bitmap.FromFile("sprites/button.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/machines/button2.png")},
            };

        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {

            PointF[] points = new PointF[]{
                new(0, 0),
                new(H, 0),
                new(H, W),
                new(0, W),
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

            g.DrawImage(Img, roomX, roomY, 200, 200);

            if (this.Apprentice != null)
                DrawText(g, this.Apprentice.Name.Split(" ")[0], new PointF(roomX + 100, roomY + 30));
        }
    }
}
