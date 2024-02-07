using System.Collections.Generic;
using System.Drawing;

using WorkStations;
using Structures;
using EtsTycoon;

namespace Rooms
{
    public class BossRoom : Room
    {
        public static int Index { get; set; } = 0;
        public static PointF[] Points { get; set; }
        public static int H { get; set; }
        public static int W { get; set; }

        public List<Image> Images { get; set; } = new()
        {
            Bitmap.FromFile("./sprites/floor/BossRoom1.png"),
            Bitmap.FromFile("./sprites/floor/BossRoom2.png")
        };

        public BossRoom()
        {
            H = 40;
            W = 90;

            float[] a = {
                         PositionX + 1160,
                         PositionX + 910, PositionX + 1000, PositionX + 1090,
                         PositionX + 728, PositionX + 878, PositionX +  968,
                         PositionX + 618, PositionX + 768, PositionX +  858
                         };

            float[] b = {
                         PositionY + 165,
                         PositionY +  110, PositionY + 155, PositionY + 200,
                         PositionY +  141, PositionY + 216, PositionY + 261,
                         PositionY + 196, PositionY + 271, PositionY + 316
                         };

            this.PositionsX = a;
            this.PositionsY = b;

            this.Structures.Add(new InstructorsBRTable());

            for (int i = 1; i < a.Length; i++)
                this.Structures.Add(new DoubleChairTable());

            Game.Rooms.Add(this);
        }

        public override void Draw(Graphics g)
        {
            if (Index == 1)
            {
                FloorImg = this.Images[0];
            }
            else
            {
                FloorImg = this.Images[1];
            }

            g.DrawImage(FloorImg,
                PositionX + Game.GeneralPosition.X, PositionY + Game.GeneralPosition.Y, 1400, 700
            );

            if (Game.OpenUpgradesStore == false)
            {
                for (int i = 0; i < this.Structures.Count; i++)
                    this.Structures[i].Draw(g, PositionX + PositionsX[i] + Game.GeneralPosition.X, PositionY + PositionsY[i] + Game.GeneralPosition.Y);
            } //Change here to draw structures after every room is drawn or maybe change rooms position or instructor name position
        }
    }
}
