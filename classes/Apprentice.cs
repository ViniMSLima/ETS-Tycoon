using System;
using System.Collections.Generic;
using System.Drawing;

public class Apprentice
{
    public string Name { get; set; }
    public string Age { get; set; }
    public Image img;
    public static List<Apprentice> Apprentices { get; set; } = new List<Apprentice>();
    public int CoinPerSecond { get; set; }
    public int Salary { get; set; }

    public Apprentice()
    {
        this.img = Bitmap.FromFile("./sprites/apprentice/stand/down.png");
        Apprentices.Add(this);
    }
}
