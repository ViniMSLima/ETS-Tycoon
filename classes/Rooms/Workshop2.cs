using System.Drawing;

using MotherClasses;
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
                            PositionX + 775, 
                            PositionX + 300, PositionX + 390, PositionX + 490, PositionX + 585, PositionX + 680,
                        };

            float[] b = {   
                            PositionY + 1000, 
                            PositionY + 893, PositionY + 941, PositionY + 989, PositionY + 1037, PositionY + 1085, 
                        };

            this.PositionsX = a;
            this.PositionsY = b;

            // for (int i = 0; i < 6; i++)
            //     this.Structures.Add(new Drill());

            // for (int i = 6; i < 12; i++)
            //     this.Structures.Add(new WorkshopTable());

            this.Structures.Add(new Kuka());
            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());
            this.Structures.Add(new WorkshopTable2());

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
