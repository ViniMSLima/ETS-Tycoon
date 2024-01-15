using System;
using System.Drawing;
using System.Windows.Forms;

public class DigitalRoom : Room
{
    public PointF[] Polygon { get; set; }

    public DigitalRoom()
    {
        this.FloorImg = Bitmap.FromFile("./sprites/floor/floor.png");

        float[] a = {PositionX + 510, PositionX + 680, PositionX + 410,
                              PositionX + 570, PositionX + 300, PositionX + 460};

        float[] b = {PositionY + 145, PositionY + 230, PositionY + 195,
                              PositionY + 285, PositionY + 250, PositionY + 340};

        this.PositionsX = a;
        this.PositionsY = b;

        for (int i = 0; i < 6; i++)
        {
            this.Structures.Add(new Table());
        }
    }

    public float Rad(float angle)
        => angle * MathF.PI / 180;

    public override void Draw(Graphics g)
    {
        g.DrawImage(FloorImg,
            PositionX, PositionY, 900, 900
        );

        for (int i = 0; i < 6; i++)
            this.Structures[i].Draw(g, PositionX + PositionsX[i], PositionY + PositionsY[i]);
        
    }

    public void ClickCheck(PointF point)
    {
        int num_vertices = this.Polygon.Length;
        double x = point.X, y = point.Y;
        bool inside = false;

        PointF p1 = this.Polygon[0], p2;

        for (int i = 1; i <= num_vertices; i++)
        {
            p2 = this.Polygon[i % num_vertices];

            float miny = p1.Y;
            if (p2.Y < p1.Y) miny = p2.Y;

            float maxy = p1.Y;
            if (p2.Y > p1.Y) maxy = p2.Y;

            float maxx = p1.X;
            if (p2.X > p1.X) maxx = p2.X;

            if (y > miny && y <= maxy && x <= maxx)
            {
                double x_intersection
                    = (y - p1.Y) * (p2.X - p1.X)/ 
                      (p2.Y - p1.Y) + p1.X;

                if (p1.X == p2.X || x <= x_intersection)
                    inside = !inside;      
            }

            p1 = p2;
        }

        // Return the value of the inside flag
        MessageBox.Show(inside.ToString());
    }

    public override void BuyCheckAll()
    {
        foreach (Table Tb in Structures)
            Tb.BuyCheck();
        
    }

    public override void ClickCheckAll(System.Drawing.Point point, Graphics g)
    {
        foreach (Table Tb in Structures)
            Tb.ClickCheck(point, g);
        
    }
}
