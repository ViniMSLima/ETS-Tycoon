using System.Drawing;

using Structures;
using Extension;

namespace WorkStations
{
    public class HexagonalTable : Structure
    {
        public HexagonalTable()
        {
            StructureType = "Apprentice";

            H = 130;
            W = 130;

            this.Price = 20;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/machines/hexagonal_table.png")},
                {"buy_structure", Bitmap.FromFile("sprites/btn1.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/btn2.png")},
                {"apprentice1", Bitmap.FromFile("sprites/machines/hexagonal_table1.png")},
                {"apprentice2", Bitmap.FromFile("sprites/machines/hexagonal_table2.png")},
            };
            
            this.Img = Images["buy_structure"];
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            if(this.Buy)
            {
                H = 170;
                W = 170;
            }
            PointF[] points = new PointF[]{
                new(0, 0),
                new(H, 0),
                new(H, W),
                new(0, W),
                new(0, 0),
            }.ToIsometric(roomX + 150, roomY + 165);

            this.Points = points;

            if (this.Buy && this.Apprentice != null)
            {
                const int speed = 3;
                if (Index < speed)
                {
                    this.Img = Images["apprentice1"];
                    Index++;
                }
                else
                {
                    this.Img = Images["apprentice2"];
                    Index++;
                    if (Index > 2 * speed)
                        Index = 0;
                }
            }

            g.DrawImage(Img, roomX + 20, roomY - 20, 240, 240);

            if (this.Apprentice != null)
                DrawText(g, this.Apprentice.Name.Split(" ")[0], new PointF(roomX + 100, roomY + 30));
        }
    }
}
