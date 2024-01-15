using System.Drawing;

public class Store 
{
    public Store()
    {

    }

    public void Draw(Graphics g)
    {
        g.DrawImage(Bitmap.FromFile("./sprites/backgrounds/store_background.png"), 200, 100, 1500, 900);
    }
}