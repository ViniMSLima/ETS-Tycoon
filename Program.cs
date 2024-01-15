using System;
using System.Drawing;
using System.Windows.Forms;

System.Media.SoundPlayer sound = new();
ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
sound.SoundLocation = "./soundtracks/And_so_it_begins.wav";

Game game = new();
Player player = new();

var timer = new Timer {
    Interval = 20,
    //20000 ticks/second
};

DigitalRoom SalaETS = new()
{
    PositionX = 450,
    PositionY = 120
};

var pb = new PictureBox {
    Dock = DockStyle.Fill,
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
    
    SalaETS.Draw(g);

    player.DrawInfo(g, pb);
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
    SalaETS.ClickCheckAll(e.Location);
};

pb.MouseUp += (o, e) =>
{
    SalaETS.BuyCheckAll();
};

form.KeyUp += (o, e) =>
{
    // switch (e.KeyCode)
    // {

    // }
};

Application.Run(form);
