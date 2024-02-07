using System.Drawing;

using WorkStations;
using Structures;
using EtsTycoon;

namespace Rooms
{
    public class Workshop1 : Room
    {
        public Workshop1()
        {
            this.FloorImg = Bitmap.FromFile("./sprites/floor/workshop.png");

            float[] a = {
                         PositionX + 800, PositionX + 900, PositionX + 1000, PositionX + 1100, PositionX + 1200, PositionX + 1300,
                         PositionX + 400, PositionX + 500, PositionX + 600, PositionX + 700, PositionX + 800, PositionX + 900,
                         PositionX + 1000, PositionX + 800,
                         PositionX + 200, PositionX + 300, PositionX + 400, PositionX + 500, PositionX + 600, PositionX + 700,
                         };

            float[] b = {   
                            PositionY + 500, PositionY + 550, PositionY + 600, PositionY + 650, PositionY + 700, PositionY + 750,
                            PositionY + 700, PositionY + 750, PositionY + 800, PositionY + 850, PositionY + 900, PositionY + 950,
                            PositionY + 800, PositionY + 700,
                            PositionY + 800, PositionY + 850, PositionY + 900, PositionY + 950, PositionY + 1000, PositionY + 1050,
                         };

            this.PositionsX = a;
            this.PositionsY = b;

            for (int i = 0; i < 6; i++)
                this.Structures.Add(new Drill());

            for (int i = 0; i < 6; i++)
                this.Structures.Add(new GridingMachine());

            this.Structures.Add(new HexagonalTable());
            this.Structures.Add(new HexagonalTable());

            for (int i = 0; i < 3; i++)
                this.Structures.Add(new WorkshopTable());

            this.Structures.Add(new WorkshopInstructorsTable());
            this.Structures.Add(new WorkshopTable());
            this.Structures.Add(new WorkshopTable());

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
        }

    }
}
