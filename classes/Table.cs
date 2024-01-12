using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class Table
{
    public PointF[] Points { get; set; }
    public Image Image { get; set; }

    public int Price { get; set; }


    public Table(Graphics g, Image img, PointF[] pts)
    {
        this.Image = img;
        this.Points = pts;

        Pen pen = new(Color.Red, 5f);

        g.DrawPolygon(pen, pts);

    }

    public bool point_in_polygon(PointF point)
    {
        int num_vertices = this.Points.Length;
        double x = point.X, y = point.Y;
        bool inside = false;

        PointF p1 = this.Points[0], p2;

        for (int i = 1; i <= num_vertices; i++)
        {
            p2 = this.Points[i % num_vertices];

            float miny = p1.Y;
            if (p2.Y < p1.Y)
                miny = p2.Y;

            float maxy = p1.Y;
            if (p2.Y > p1.Y)
                maxy = p2.Y;

            float maxx = p1.X;
            if (p2.X > p1.X)
                maxx = p2.X;

            if (y > miny)
            {

                if (y <= maxy)
                {

                    if (x <= maxx)
                    {

                        double x_intersection
                            = (y - p1.Y) * (p2.X - p1.X)
                                  / (p2.Y - p1.Y)
                              + p1.X;


                        if (p1.X == p2.X
                            || x <= x_intersection)
                        {
                            inside = !inside;
                        }
                    }
                }
            }
            p1 = p2;
        }

        // Return the value of the inside flag
        MessageBox.Show(inside.ToString());
        return inside;
    }
}