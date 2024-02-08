using System.Drawing;

using Structures;
using Extension;

namespace WorkStations
{
    public class Kuka : Structure
    {
        public bool Reverse { get; set; } = false; 
        public Kuka()
        {
            StructureType = "Apprentice";

            H = 140;
            W = 140;

            this.Price = 20;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/machines/kuka/kuka1.png")},
                {"buy_structure", Bitmap.FromFile("sprites/btn1.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/btn2.png")},
                {"animation1", Bitmap.FromFile("sprites/machines/kuka/kuka1.png")},
                {"animation2", Bitmap.FromFile("sprites/machines/kuka/kuka2.png")},
                {"animation3", Bitmap.FromFile("sprites/machines/kuka/kuka3.png")},
                {"animation4", Bitmap.FromFile("sprites/machines/kuka/kuka4.png")},
            };
            
            this.Img = Images["buy_structure"];
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            if(this.Buy)
            {
                H = 200;
                W = 200;
            }
            PointF[] points = new PointF[]{
                new(0, 0),
                new(H, 0),
                new(H, W),
                new(0, W),
                new(0, 0),
            }.ToIsometric(roomX + 170, roomY + 200);

            this.Points = points;

            if (this.Buy && this.Apprentice != null)
            {
                const int speed = 5;
                if (Index < speed)
                {
                    this.Img = this.Images["animation1"];
                    if(Reverse)
                        Index--;
                    else
                        Index++;

                    if(Index == 0)
                        Reverse = false;
                }
                else if(Index < speed * 2)
                {
                    this.Img = this.Images["animation2"];
                    if(Reverse)
                        Index--;
                    else
                        Index++;
                    
                }
                else if(Index < speed * 3)
                {
                    this.Img = this.Images["animation3"];
                    if(Reverse)
                        Index--;
                    else
                        Index++;
                }
                else 
                {
                    this.Img = this.Images["animation4"];

                    if(Reverse)
                        Index--;
                    else
                        Index++;

                    if(Index == speed * 4)
                        Reverse = true;
                }
            }

            g.DrawImage(Img, roomX + 20, roomY - 20, 300, 300);

            if (this.Apprentice != null)
                DrawText(g, this.Apprentice.Name.Split(" ")[0], new PointF(roomX + 85, roomY + 100));
        }
    }
}
