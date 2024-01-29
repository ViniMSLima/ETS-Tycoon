using System.Windows.Forms;
using System.Drawing;

using MotherClasses;
using Characters;
using EtsTycoon;

namespace Structures
{
    
    public class InstructorsDRTable : Structure
    {
        public int Index { get; set; }

        public InstructorsDRTable()
        {
            StructureType = "Instructor";

            Index = 0;
            this.Buy = false;
            this.Img = Bitmap.FromFile("sprites/instructors/buy_instructor.png");
            this.Price = 50;

            this.Images = new()
            {
                {"structure", Bitmap.FromFile("sprites/instructors/instructorsTable.png")},
                {"buy_structure", Bitmap.FromFile("sprites/instructors/buy_instructor.png")},
                {"buy_structure_down", Bitmap.FromFile("sprites/instructors/buy_instructor_down.png")},
                {"instructor1", Bitmap.FromFile("./sprites/instructors/instructor1.png")},
                {"instructor2", Bitmap.FromFile("./sprites/instructors/instructor2.png")},
            };
        }

        public override void Draw(Graphics g, float roomX, float roomY)
        {
            float h = 40, w = 90;

            PointF[] points = new PointF[]{
                new(0, 0),
                new(h, 0),
                new(h, w),
                new(0, w),
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
