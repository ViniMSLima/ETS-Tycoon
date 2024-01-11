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

Player player = new()
{
    Money = 100,
    Level = 1
};

DigitalRoom digitalRoom = new()
{
    PositionX = 800,
    PositionY = 300,
    FloorImg = Bitmap.FromFile("./sprites/floor.png"),
    TableImg = Bitmap.FromFile("./sprites/table.png"),
};

DigitalRoom SalaETS = new()
{
    PositionX = 450,
    PositionY = 120,
    FloorImg = Bitmap.FromFile("./sprites/floor.png"),
    TableImg = Bitmap.FromFile("./sprites/table.png"),
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
    g.Clear(Color.Black);
    pb.Image = bmp;
    timer.Start();
    sound.PlayLooping();

};

timer.Tick += (o, e) =>
{
    g.Clear(Color.White);
    g.DrawImage(Bitmap.FromFile("grid.jpg"), 0, 0, 2000, 1500);
    
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

form.KeyUp += (o, e) =>
{
    switch (e.KeyCode)
    {

    }
};

Application.Run(form);

