using System.Drawing;

using Structures;
using Extension;

namespace WorkStations
{
    public class Machine2 : Structure
    {
        public Machine2()
        {
            StructureType = "Apprentice";

            H = 125;
            W = 125;

            this.Price = 20;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/machines/machine2.png")},
                {"buy_structure", Bitmap.FromFile("sprites/btn1.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/btn2.png")},
                {"animation1", Bitmap.FromFile("sprites/machines/machine2.png")},
                {"animation2", Bitmap.FromFile("sprites/machines/machine2_2.png")},
            };
            
            this.Img = Images["buy_structure"];
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            if(this.Buy)
            {
                H = 175;
                W = 175;
            }
            PointF[] points = new PointF[]{
                new(0, 0),
                new(H, 0),
                new(H, W),
                new(0, W),
                new(0, 0),
            }.ToIsometric(roomX + 150, roomY + 200);

            this.Points = points;

            if (this.Buy && this.Apprentice != null)
            {
                const int speed = 3;
                if (Index < speed)
                {
                    this.Img = this.Images["animation1"];
                    Index++;
                }
                else
                {
                    this.Img = this.Images["animation2"];
                    Index++;
                    if (Index > 2 * speed)
                        Index = 0;
                }
            }

            g.DrawImage(Img, roomX, roomY, 280, 280);
            
            if (this.Apprentice != null)
                DrawText(g, this.Apprentice.Name.Split(" ")[0], new PointF(roomX + 100, roomY + 30));

            

        } 
    }
}
