using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

public class Room
{
    public int Level { get; set; }
    public List<Apprentice> RoomAprentices { get; set; }
    public Instructor RoomInstructor { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public Image floorImg { get; set; }
    public Image tableImg { get; set; }

    public void Draw(Graphics g)
    {
        g.DrawImage(floorImg,
            PositionX, PositionY, 900, 900
        );

        g.DrawImage(Bitmap.FromFile("./sprites/buy_table.png"), PositionX + 260, PositionY + 150, 350, 350);
        g.DrawImage(Bitmap.FromFile("./sprites/buy_table.png"), PositionX + 400, PositionY + 80, 350, 350);
    }

    public void DrawTable(Graphics g, int x, int y)
    {
        g.DrawImage(tableImg,
            x, y, 200, 200
        );
    }
}
