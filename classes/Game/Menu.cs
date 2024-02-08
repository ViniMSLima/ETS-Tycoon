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

    public static Dictionary<string, Image> Images { get; set; } = new()
    {
        {"start_screen", Bitmap.FromFile("./sprites/backgrounds/start_screen3.png")},
        {"start1", Bitmap.FromFile("./sprites/menu/btn_start1.png")},
        {"load1", Bitmap.FromFile("./sprites/menu/btn_load1.png")},
        {"settings1", Bitmap.FromFile("./sprites/menu/btn_settings1.png")},
        {"exit1", Bitmap.FromFile("./sprites/menu/btn_exit1.png")},
        {"start2", Bitmap.FromFile("./sprites/menu/btn_start2.png")},
        {"load2", Bitmap.FromFile("./sprites/menu/btn_load2.png")},
        {"settings2", Bitmap.FromFile("./sprites/menu/btn_settings2.png")},
        {"exit2", Bitmap.FromFile("./sprites/menu/btn_exit2.png")},
    };

    public static Dictionary<string, Image> ImageButtons { get; set; } = new()
    {
        {"start_btn", Bitmap.FromFile("./sprites/menu/btn_start1.png")},
        {"load_btn", Bitmap.FromFile("./sprites/menu/btn_load1.png")},
        {"settings_btn", Bitmap.FromFile("./sprites/menu/btn_settings1.png")},
        {"exit_btn", Bitmap.FromFile("./sprites/menu/btn_exit1.png")},
    };

    public static int H { get; set; } = 100;
    public static int W { get; set; } = 40;

    public static bool Clicks(PointF point, PointF[] button)
    {
        bool inside = Clicker.ContainsClick(point, button);

        if (inside)
        {
            if (point.Y < Game.Pb.Height * 0.545)
            {
                Game.GameStart = true;
                Game.Tutorial1 = true;
            }
            else if (point.Y < Game.Pb.Height * 0.59)
            {
                MessageBox.Show("LOAD SCREEN");
            }
            else if (point.Y < Game.Pb.Height * 0.64)
            {
                MessageBox.Show("SETTINGS SCREEN");
            }
            else
            {
                if (MessageBox.Show("Close game?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
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

    public static void HoverAll(PointF point)
    {
        Hover(point, Buttons[0]);
        Hover(point, Buttons[1]);
        Hover(point, Buttons[2]);
        Hover(point, Buttons[3]);
    }

    public static void Draw(Graphics g)
    {

        g.DrawImage(Images["start_screen"], 0, 0, Game.Pb.Width, Game.Pb.Height);
        g.DrawImage(ImageButtons["start_btn"], Game.Pb.Width * 0.265f, Game.Pb.Height * 0.43f, Game.Pb.Width * 0.16f, Game.Pb.Height * 0.2f);
        g.DrawImage(ImageButtons["load_btn"], Game.Pb.Width * 0.265f, Game.Pb.Height * 0.475f, Game.Pb.Width * 0.16f, Game.Pb.Height * 0.2f);
        g.DrawImage(ImageButtons["settings_btn"], Game.Pb.Width * 0.265f, Game.Pb.Height * 0.52f, Game.Pb.Width * 0.16f, Game.Pb.Height * 0.2f);
        g.DrawImage(ImageButtons["exit_btn"], Game.Pb.Width * 0.265f, Game.Pb.Height * 0.562f, Game.Pb.Width * 0.16f, Game.Pb.Height * 0.2f);
    }

    public static bool Hover(PointF point, PointF[] button)
    {
        bool inside = Clicker.ContainsClick(point, button);

        if (inside)
        {
            if (point.Y < Game.Pb.Height * 0.545)
            {
                ImageButtons["start_btn"] = Images["start2"];
                ImageButtons["load_btn"] = Images["load1"];
                ImageButtons["settings_btn"] = Images["settings1"];
                ImageButtons["exit_btn"] = Images["exit1"];
            }
            else if (point.Y < Game.Pb.Height * 0.59)
            {
                ImageButtons["start_btn"] = Images["start1"];
                ImageButtons["load_btn"] = Images["load2"];
                ImageButtons["settings_btn"] = Images["settings1"];
                ImageButtons["exit_btn"] = Images["exit1"];

            }
            else if (point.Y < Game.Pb.Height * 0.64)
            {
                ImageButtons["start_btn"] = Images["start1"];
                ImageButtons["load_btn"] = Images["load1"];
                ImageButtons["settings_btn"] = Images["settings2"];
                ImageButtons["exit_btn"] = Images["exit1"];
            }
            else
            {
                ImageButtons["start_btn"] = Images["start1"];
                ImageButtons["load_btn"] = Images["load1"];
                ImageButtons["settings_btn"] = Images["settings1"];
                ImageButtons["exit_btn"] = Images["exit2"];
            }
        }

        return inside;
    }
}

