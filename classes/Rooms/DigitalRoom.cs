using System.Drawing;

using WorkStations;
using Structures;
using EtsTycoon;

namespace Rooms
{
    public class DigitalRoom : Room
    {
        public Image[] Images { get; set; } = {
            Bitmap.FromFile("./sprites/floor/DR_floor1.png"),
            Bitmap.FromFile("./sprites/floor/DR_floor2.png")
        };

        public DigitalRoom()
        {
            this.FloorImg = Images[1];

            float[] a = {
                         PositionX + 586, PositionX + 681, PositionX + 822, PositionX + 917,
                         PositionX + 486, PositionX + 581, PositionX + 722, PositionX + 817,
                         PositionX + 326, PositionX + 421, PositionX + 562, PositionX + 657,
                         PositionX + 226, PositionX + 321, PositionX + 462, PositionX + 557,
                         PositionX + 126, PositionX + 221, PositionX + 362, PositionX + 457,
                         PositionX + 350
                         };

            float[] b = {
                         PositionY -  72, PositionY -  24, PositionY +  51, PositionY +  99,
                         PositionY -  22, PositionY +  26, PositionY + 101, PositionY + 149,
                         PositionY +  58, PositionY + 106, PositionY + 181, PositionY + 229,
                         PositionY + 108, PositionY + 156, PositionY + 231, PositionY + 279,
                         PositionY + 158, PositionY + 206, PositionY + 281, PositionY + 329,
                         PositionY + 370
                         };

            this.PositionsX = a;
            this.PositionsY = b;

            for (int i = 0; i < a.Length - 1; i++)
                this.Structures.Add(new DRTable());

            this.Structures.Add(new InstructorsDRTable());

            Game.Rooms.Add(this);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(FloorImg,
                PositionX + Game.GeneralPosition.X, PositionY + Game.GeneralPosition.Y, 1120, 630
            );

            if (Game.OpenUpgradesStore == false)
            {
                for (int i = 0; i < this.Structures.Count; i++)
                    this.Structures[i].Draw(g, PositionX + PositionsX[i] + Game.GeneralPosition.X, PositionY + PositionsY[i] + Game.GeneralPosition.Y);
            }

        }
    }
}
