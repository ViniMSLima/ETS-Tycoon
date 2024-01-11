using System;
using System.Drawing;
using System.Windows.Forms;

System.Media.SoundPlayer sound = new();
ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
sound.SoundLocation = "./soundtracks/And_so_it_begins.wav";

Apprentice hero = new();
Player player = new()
{
    Money = 100,
    Level = 1
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

