using System.Drawing;

using Structures;
using Extension;

namespace WorkStations
{
    public class NRInstructorsTable : Structure
    {
        public NRInstructorsTable()
        {
            StructureType = "Instructor";

            H = 40;
            W = 90;

            this.Price = 50;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/table/NR_instructors_table.png")},
                {"buy_structure", Bitmap.FromFile("sprites/btn_instructor_table1.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/btn_instructor_table2.png")},
                {"animation1", Bitmap.FromFile("./sprites/table/NR_instructors_table1.png")},
                {"animation2", Bitmap.FromFile("./sprites/table/NR_instructors_table2.png")},
            };
            
            this.Img = Images["buy_structure"];
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            if(this.Buy)
            {
                H = 90;
                W = 110;
            }
            PointF[] points = new PointF[]{
                new(0, 0),
                new(H, 0),
                new(H, W),
                new(0, W),
                new(0, 0),
            }.ToIsometric(roomX + 120, roomY + 145);

            this.Points = points;

            if (this.Buy && this.Instructor != null)
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

            g.DrawImage(Img, roomX, roomY, 200, 200);

            if (this.Instructor != null)
                DrawText(g, this.Instructor.Name.Split(" ")[0], new PointF(roomX + 100, roomY + 30));

        }
    }
}
