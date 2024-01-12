using System.Drawing;

public class Apprentice
{

    public float X { get; set; }
    public float Y { get; set; }
    private Image img;
    public Apprentice()
    {
       
        this.img = Bitmap.FromFile("./sprites/apprentice/stand/down.png");
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