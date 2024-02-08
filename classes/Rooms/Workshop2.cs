using System.Drawing;

using WorkStations;
using Structures;
using EtsTycoon;

namespace Rooms
{
    public class Workshop2 : Room
    {
        public Image Glass { get; set; } = Bitmap.FromFile("./sprites/floor/workshop2glass.png");
        public Workshop2()
        {
            this.FloorImg = Bitmap.FromFile("./sprites/floor/workshop.png");

            float[] a = {
                            PositionX + 425, PositionX + 615, PositionX + 805,
                            PositionX + 395, PositionX + 495, PositionX + 595,
                            PositionX + 1200
                        };

            float[] b = {   
                            PositionY + 725, PositionX + 820, PositionX + 950,
                            PositionY + 989, PositionY + 1037, PositionY + 1085,
                            PositionY + 750
                        };

            this.PositionsX = a;
            this.PositionsY = b;

            this.Structures.Add(new Machine2());
            this.Structures.Add(new Machine2());
            
            this.Structures.Add(new Kuka());

            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());

            this.Structures.Add(new YellowMachine());

            Game.Rooms.Add(this);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(FloorImg,
                PositionX + Game.GeneralPosition.X, PositionY + Game.GeneralPosition.Y, 1600, 1600 
            );

            if(Game.OpenUpgradesStore == false)
            {
                for (int i = 0; i < this.Structures.Count; i++)
                    this.Structures[i].Draw(g, PositionX + PositionsX[i] + Game.GeneralPosition.X, PositionY + PositionsY[i] + Game.GeneralPosition.Y);
            }

            g.DrawImage(Glass,
                PositionX + Game.GeneralPosition.X, PositionY + Game.GeneralPosition.Y, 1600, 1600 
            );

        }

    }
}
