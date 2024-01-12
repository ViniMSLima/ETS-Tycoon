using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

public class DigitalRoom : Room
{
    public PointF[] Polygon { get; set; }

    public float Rad(float angle)
        => angle * MathF.PI / 180;

    public override void Draw(Graphics g)
    {
        g.DrawImage(FloorImg,
            PositionX, PositionY, 900, 900
        );

        float h = 70, w = 170;

        PointF[] table1Pts = new PointF[]{
            new PointF(0, 0),
            new PointF(h, 0),
            new PointF(h, w),
            new PointF(0, w),
            new PointF(0, 0),
        }.ToIsometric(PositionX + 650, PositionY + 325);

        Table table1  = new(g, this.TableImg, table1Pts);

        g.DrawImage(Bitmap.FromFile("./sprites/table/table.png"), PositionX + 510, PositionY + 145, 200, 200);
        g.DrawImage(Bitmap.FromFile("./sprites/table/buy_table.png"), PositionX + 680, PositionY + 230, 200, 200);

        g.DrawImage(Bitmap.FromFile("./sprites/table/buy_table.png"), PositionX + 410, PositionY + 195, 200, 200);
        g.DrawImage(Bitmap.FromFile("./sprites/table/buy_table.png"), PositionX + 570, PositionY + 285, 200, 200);

        g.DrawImage(Bitmap.FromFile("./sprites/table/buy_table.png"), PositionX + 300, PositionY + 250, 200, 200);
        g.DrawImage(Bitmap.FromFile("./sprites/table/buy_table.png"), PositionX + 460, PositionY + 340, 200, 200);

        float x = 1100, y = 300;
              w = 200;
              h = 400;

        Pen pen = new(Color.Red, 5f);

        PointF[] test = new PointF[]{
            new PointF(0, 0),
            new PointF(w, 0),
            new PointF(w, h),
            new PointF(0, h),
            new PointF(0, 0),
        }.ToIsometric(x, y);

        Polygon = test;

        g.DrawPolygon(pen, test);
    }


    public bool point_in_polygon(PointF point)
    {
        int num_vertices = this.Polygon.Length;
        double x = point.X, y = point.Y;
        bool inside = false;

        PointF p1 = this.Polygon[0], p2;

        for (int i = 1; i <= num_vertices; i++)
        {
            p2 = this.Polygon[i % num_vertices];

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
