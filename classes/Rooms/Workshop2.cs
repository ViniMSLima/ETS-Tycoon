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
                         PositionX + 775, PositionX + 600, PositionX + 570, PositionX + 540, PositionX + 510, PositionX + 480, 
                         };

            float[] b = {   
                            PositionY + 1000, PositionY + 1045, PositionY + 1030, PositionY + 1015, PositionY + 1000, PositionY + 985, 
                         };

            this.PositionsX = a;
            this.PositionsY = b;

            // for (int i = 0; i < 6; i++)
            //     this.Structures.Add(new Drill());

            // for (int i = 6; i < 12; i++)
            //     this.Structures.Add(new WorkshopTable());

            this.Structures.Add(new Kuka());
            this.Structures.Add(new DRTable());
            this.Structures.Add(new DRTable());
            this.Structures.Add(new DRTable());
            this.Structures.Add(new DRTable());
            this.Structures.Add(new DRTable());
            // this.Structures.Add(new HexagonalTable());

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
