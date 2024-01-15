using System;
using System.Collections.Generic;
using System.Drawing;

public class Apprentice
{

    public float X { get; set; }
    public float Y { get; set; }
    public Image img;

    public static List<Apprentice> Apprentices { get; set; } = new List<Apprentice>();

    public Apprentice()
    {
        this.img = Bitmap.FromFile("./sprites/apprentice/stand/down.png");
        Apprentices.Add(this);
    }

    public void Draw(Graphics g)
    {
        g.DrawImage(img, 
            X, Y, 40, 50
        );
    }

    public void Move()
    {
       
    }
}