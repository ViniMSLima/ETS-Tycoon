using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using EtsTycoon;

public class Menu
{
    public static List<PointF[]> Buttons { get; set; } = new(){
            new PointF[]{
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.51f),
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.51f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.50f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.50f),
            },
            new PointF[]{
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.555f),
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.555f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.545f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.545f),
            },
            new PointF[]{
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.60f),
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.60f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.59f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.59f),
            },
            new PointF[]{
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.645f),
                new(Game.Pb.Width * 0.285f,  Game.Pb.Height * 0.645f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.635f + Game.Pb.Height * 0.035f),
                new(Game.Pb.Width * 0.285f + Game.Pb.Width * 0.13f,  Game.Pb.Height * 0.635f),
            },
            
    };

    public static int H { get; set; } = 100;
    public static int W { get; set; } = 40;

    public Menu()
    {

    }

    public static bool Clicks(PointF point, PointF[] button)
    {
        int num_vertices = button.Length;
        double x = point.X, y = point.Y;
        bool inside = false;

        PointF p1 = button[0], p2;

        for (int i = 1; i <= num_vertices; i++)
        {
            p2 = button[i % num_vertices];

            float miny = p1.Y;
            if (p2.Y < p1.Y) miny = p2.Y;

            float maxy = p1.Y;
            if (p2.Y > p1.Y) maxy = p2.Y;

            float maxx = p1.X;
            if (p2.X > p1.X) maxx = p2.X;

            if (y > miny && y <= maxy && x <= maxx)
            {
                double x_intersection =
                (y - p1.Y) * (p2.X - p1.X) /
                (p2.Y - p1.Y) + p1.X;

                if (p1.X == p2.X || x <= x_intersection)
                    inside = !inside;
            }

            p1 = p2;
        }

        if (inside)
        {            
            if(point.Y < Game.Pb.Height * 0.545)
            {
                MessageBox.Show("START");
            }
            else if(point.Y < Game.Pb.Height * 0.59)
            {
                MessageBox.Show("LOAD");
            }
            else if(point.Y < Game.Pb.Height * 0.64)
            {
                MessageBox.Show("SETTINGS");
            }
            else
            {
                if (MessageBox.Show("Close game?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
                
                // Application.Exit();
            }
        }
        return inside;
    }

    public static void ClickCheckAll(PointF point)
    {
            Clicks(point, Buttons[0]);
            Clicks(point, Buttons[1]);
            Clicks(point, Buttons[2]);
            Clicks(point, Buttons[3]);
    }

    public static void Draw(Graphics g)
    {
        Pen pen = new(Color.Red, 5f);

        foreach(PointF[] btn in Buttons)
        {
            g.DrawPolygon(pen, btn);
        }
    }

    public static bool Hover(PointF point, PointF[] button)
    {
        int num_vertices = button.Length;
        double x = point.X, y = point.Y;
        bool inside = false;

        PointF p1 = button[0], p2;

        for (int i = 1; i <= num_vertices; i++)
        {
            p2 = button[i % num_vertices];

            float miny = p1.Y;
            if (p2.Y < p1.Y) miny = p2.Y;

            float maxy = p1.Y;
            if (p2.Y > p1.Y) maxy = p2.Y;

            float maxx = p1.X;
            if (p2.X > p1.X) maxx = p2.X;

            if (y > miny && y <= maxy && x <= maxx)
            {
                double x_intersection =
                (y - p1.Y) * (p2.X - p1.X) /
                (p2.Y - p1.Y) + p1.X;

                if (p1.X == p2.X || x <= x_intersection)
                    inside = !inside;
            }

            p1 = p2;
        }

        if (inside)
        {            
            if(point.Y < Game.Pb.Height * 0.545)
            {
                MessageBox.Show("START");
            }
            else if(point.Y < Game.Pb.Height * 0.59)
            {
                MessageBox.Show("LOAD");
            }
            else if(point.Y < Game.Pb.Height * 0.64)
            {
                MessageBox.Show("SETTINGS");
            }
            else
            {
                if (MessageBox.Show("Close game?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
                
                // Application.Exit();
            }
        }
        return inside;
    }
}

