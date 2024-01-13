using System;
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

Player player = new();


DigitalRoom SalaETS = new()
{
    PositionX = 450,
    PositionY = 120
};

Table tb = new()
{
    img = Bitmap.FromFile("./sprites/table/buy_table.png"),
    PositionX = 800,
    PositionY = 300,
    Price = 20
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

timer.Tick += (o, e) =>
{
    g.Clear(Color.White);
    g.DrawImage(Bitmap.FromFile("./sprites/background/grid.jpg"), 0, 0, 2200, 1900);

    Pen pen = new Pen(Color.Gray, 6f);
    Pen pen2 = new Pen(Color.Gray, 2f);
    
    SalaETS.Draw(g);
    hero.Draw(g);
    player.DrawInfo(g, pb);
    
    tb.Draw(g);
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
    tb.Point_in_polygon(e.Location, player);
};

pb.MouseUp += (o, e) =>
{
    tb.BuyCheck();
};

form.KeyUp += (o, e) =>
{
    // switch (e.KeyCode)
    // {

    // }
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
