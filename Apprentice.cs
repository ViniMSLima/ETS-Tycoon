using System.Drawing;

public class Apprentice
{

    public float X { get; set; }
    public float Y { get; set; }
    private Image img;
    public Apprentice()
    {
        X = 600;
        Y = 500;
        this.img = Bitmap.FromFile("down.png");
    }

    public void Draw(Graphics g)
    {
        g.DrawImage(img, 
            X - 70, Y - 70, 140, 140
        );
    }

    public void Move()
    {
       
    }
}