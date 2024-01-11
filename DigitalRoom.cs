using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

public class DigitalRoom : Room
{
    public override void Draw(Graphics g)
    {
        g.DrawImage(FloorImg,
            PositionX, PositionY, 900, 900
        );

        g.DrawImage(Bitmap.FromFile("./sprites/table.png"), PositionX + 510, PositionY + 145, 200, 200);
        g.DrawImage(Bitmap.FromFile("./sprites/table.png"), PositionX + 680, PositionY + 230, 200, 200);

        g.DrawImage(Bitmap.FromFile("./sprites/table.png"), PositionX + 410, PositionY + 195, 200, 200);
        g.DrawImage(Bitmap.FromFile("./sprites/table.png"), PositionX + 570, PositionY + 285, 200, 200);

        g.DrawImage(Bitmap.FromFile("./sprites/table.png"), PositionX + 300, PositionY + 250, 200, 200);
        g.DrawImage(Bitmap.FromFile("./sprites/table.png"), PositionX + 460, PositionY + 340, 200, 200);
    }

}
