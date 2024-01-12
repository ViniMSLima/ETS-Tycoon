using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

System.Media.SoundPlayer sound = new();
ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
sound.SoundLocation = "./soundtracks/And_so_it_begins.wav";

Apprentice hero = new()
{
    X = 800,
    Y = 600
};

Player player = new()
{
    Money = 100,
    Level = 1
};

DigitalRoom digitalRoom = new()
{
    PositionX = 800,
    PositionY = 300,
    FloorImg = Bitmap.FromFile("./sprites/floor/floor.png"),
    TableImg = Bitmap.FromFile("./sprites/table/table.png"),
};

DigitalRoom SalaETS = new()
{
    PositionX = 450,
    PositionY = 120,
    FloorImg = Bitmap.FromFile("./sprites/floor/floor.png"),
    TableImg = Bitmap.FromFile("./sprites/table/table.png"),
};

var pb = new PictureBox {
    Dock = DockStyle.Fill,
};

var timer = new Timer {
    Interval = 20,
};

var form = new Form {
    WindowState = FormWindowState.Maximized,
    FormBorderStyle = FormBorderStyle.None,
    Controls = { pb }
};

form.Load += (o, e) =>
{
    bmp = new Bitmap(
        pb.Width, 
        pb.Height
    );
    g = Graphics.FromImage(bmp);
    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
    g.Clear(Color.Black);
    pb.Image = bmp;
    timer.Start();
    sound.PlayLooping();

};

float dx = 0, dy = 0;

timer.Tick += (o, e) =>
{
    g.Clear(Color.White);
    g.DrawImage(Bitmap.FromFile("./sprites/background/grid.jpg"), 0, 0, 2200, 1900);

    dx++;
    dy++;

    Pen pen = new Pen(Color.Gray, 6f);
    Pen pen2 = new Pen(Color.Gray, 2f);

    // for (int y = 0; y < 3000; y += 200)
    // {
    //     g.DrawLines(pen, new PointF[] {
    //         new PointF(0, 0),
    //         new PointF(3000, 0),
    //     }.ToIsometric(dx, y + dy));
    // }
    // for (int x = -2000; x < 2000; x += 200)
    // {
    //     g.DrawLines(pen, new PointF[] {
    //         new PointF(0, 0),
    //         new PointF(0, -3000),
    //     }.ToIsometric(x + dx, dy));
    // }
    // for (int y = 0; y < 3000; y += 100)
    // {
    //     g.DrawLines(pen2, new PointF[] {
    //         new PointF(0, 0),
    //         new PointF(3000, 0),
    //     }.ToIsometric(dx, y + dy));
    // }
    // for (int x = -2000; x < 2000; x += 100)
    // {
    //     g.DrawLines(pen2, new PointF[] {
    //         new PointF(0, 0),
    //         new PointF(0, -3000),
    //     }.ToIsometric(dx + x, dy));
    // }
    
    digitalRoom.Draw(g);
    SalaETS.Draw(g);
    hero.Draw(g);
    player.DrawInfo(g, player, pb);
    
    pb.Refresh();
};

form.KeyDown += (o, e) =>
{
    switch (e.KeyCode)
    {
        case Keys.Escape:
            Application.Exit();
            break;
    }
};

pb.MouseDown += (o, e) =>
{
    digitalRoom.point_in_polygon(e.Location);
};

form.KeyUp += (o, e) =>
{
    switch (e.KeyCode)
    {

    }
};

Application.Run(form);

public class Game
{
    public Game()
    {

    }

    public static void BuyRoom()
    {

    }

    public static void BuyApprentice(Room room)
    {

    }


    


}