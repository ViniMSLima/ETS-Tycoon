using System.Drawing;

using MotherClasses;
using Extension;

namespace Structures
{
    public class InstructorsBRTable : Structure
    {
        public InstructorsBRTable()
        {
            StructureType = "Instructor";

            H = 40;
            W = 90;

            this.Price = 50;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/table/instructor_BR_table.png")},
                {"buy_structure", Bitmap.FromFile("sprites/instructors/buy_instructor.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/instructors/buy_instructor_down.png")}
            };
            
            this.Img = Images["buy_structure"];
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

            if (this.Buy && this.Instructor != null)
            {
                const int speed = 3;
                if (Index < speed)
                {
                    this.Img = this.Instructor.Img[0];
                    Index++;
                }
                else
                {
                    this.Img = this.Instructor.Img[1];
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
