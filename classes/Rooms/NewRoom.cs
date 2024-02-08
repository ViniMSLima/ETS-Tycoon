using System.Drawing;

using WorkStations;
using Structures;
using EtsTycoon;

namespace Rooms
{
    public class NewRoom : Room
    {
        public Image[] Images { get; set; } = {
            Bitmap.FromFile("./sprites/floor/NewRoom_floor2.png")
        };

        public NewRoom()
        {
            this.FloorImg = Images[0];

            float[] a = {
                            PositionX + 619, PositionX + 714, PositionX + 855, PositionX + 950,
                            PositionX + 519, PositionX + 614, PositionX + 755, PositionX + 850,
                            PositionX + 419, PositionX + 514, PositionX + 655, PositionX + 750,
                            PositionX + 319, PositionX + 414, PositionX + 555, PositionX + 650,
                            PositionX + 219, PositionX + 314, PositionX + 455, PositionX + 550,
                            PositionX + 1050
                         };

            float[] b = {
                            PositionY +  358, PositionY + 406, PositionY +  481, PositionY +  529,
                            PositionY + 408, PositionY +  456, PositionY + 531, PositionY + 579,
                            PositionY + 458, PositionY + 506, PositionY + 581, PositionY + 629,
                            PositionY + 508, PositionY + 556, PositionY + 631, PositionY + 679,
                            PositionY + 558, PositionY + 606, PositionY + 681, PositionY + 729,
                            PositionY + 429
                         };

            this.PositionsX = a;
            this.PositionsY = b;

            for (int i = 0; i < a.Length - 1; i++)
                this.Structures.Add(new NewRoomTable());

            this.Structures.Add(new NRInstructorsTable());

            Game.Rooms.Add(this);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(FloorImg,
                PositionX + Game.GeneralPosition.X, PositionY + Game.GeneralPosition.Y, 1400, 1400
            );

            if (Game.OpenUpgradesStore == false)
            {
                for (int i = 0; i < this.Structures.Count; i++)
                    this.Structures[i].Draw(g, PositionX + PositionsX[i] + Game.GeneralPosition.X, PositionY + PositionsY[i] + Game.GeneralPosition.Y);
            }

        }
    }
}
