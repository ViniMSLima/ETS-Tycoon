using System.Windows.Forms;
using System.Drawing;
using MotherClasses;
using System.Linq;
using Structures;
using EtsTycoon;

namespace Rooms
{
    public class BossRoom : Room
    {
        public BossRoom()
        {
            this.FloorImg = Bitmap.FromFile("./sprites/floor/bossroom.png");

            float[] a = {
                         PositionX + 1120, 
                         PositionX + 870, PositionX + 960, PositionX + 1050,
                         PositionX + 700, PositionX + 850, PositionX +  940,
                         PositionX + 590, PositionX + 740, PositionX +  830
                         };

            float[] b = {
                         PositionY + 115, 
                         PositionY +  60, PositionY + 105, PositionY + 150,
                         PositionY +  85, PositionY + 160, PositionY + 205,
                         PositionY + 140, PositionY + 215, PositionY + 260
                         };

            this.PositionsX = a;
            this.PositionsY = b;

            this.Structures.Add(new InstructorsBRTable());

            for (int i = 1; i < a.Length; i++)
                this.Structures.Add(new DoubleChairTable());

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(FloorImg,
                PositionX + Game.GeneralPosition.X, PositionY + Game.GeneralPosition.Y, 1400, 630
            );

            for (int i = 0; i < this.Structures.Count; i++)
                this.Structures[i].Draw(g, PositionX + PositionsX[i] + Game.GeneralPosition.X, PositionY + PositionsY[i] + Game.GeneralPosition.Y);
        }

    }
}
