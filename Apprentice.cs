using System;
using System.Drawing;

public class Apprentice
{
    public int X { get; set; }
    public int Y { get; set; }
    public float Size { get; set; }
    public int CoinsPerSecond { get; set; }

    private Image img;
    public Apprentice()
    {
        this.img = Bitmap.FromFile("./sprites/apprentice/stand/down.png");
    }

    public void Draw(Graphics g)
    {
        X = 200;
        Y = 200;

        g.DrawImage(img, 
           200, 200,
            200,
            200
        );
    }
}