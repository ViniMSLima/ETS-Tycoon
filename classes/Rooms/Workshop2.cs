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
                            PositionX + 325, PositionX + 515,
                            PositionX + 705,
                            PositionX + 095,PositionX + 245,
                            PositionX + 395, PositionX + 495, PositionX + 595,
                            PositionX + 750, PositionX + 900, PositionX + 1050,
                            PositionX + 1200,
                            PositionX + 600, PositionX + 750, PositionX + 900,
                        };

            float[] b = {   
                            PositionY + 675, PositionX + 770, 
                            PositionX + 900,
                            PositionY + 801, PositionY + 876,
                            PositionY + 989, PositionY + 1037, PositionY + 1085,
                            PositionY + 450, PositionY + 525, PositionY + 600,
                            PositionY + 675,
                            PositionY + 600, PositionY + 675, PositionY + 750,
                        };

            this.PositionsX = a;
            this.PositionsY = b;

            this.Structures.Add(new Machine2());
            this.Structures.Add(new Machine2());
            
            this.Structures.Add(new Kuka());

            
            this.Structures.Add(new Machine3());
            this.Structures.Add(new Machine3());

            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());

            this.Structures.Add(new Machine2());
            this.Structures.Add(new Machine2());
            this.Structures.Add(new Machine2());


            this.Structures.Add(new YellowMachine());

            
            this.Structures.Add(new Machine4());
            this.Structures.Add(new Machine4());
            this.Structures.Add(new Machine4());

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
