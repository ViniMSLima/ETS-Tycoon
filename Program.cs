using System;
using System.Drawing;
using System.Windows.Forms;

System.Media.SoundPlayer sound = new();

ApplicationConfiguration.Initialize();

Player player = new()
{
    Money = 100,
    Level = 1
};

Apprentice aptc = new Apprentice();

Bitmap bmp = null;
Graphics g = null;

sound.SoundLocation = "./soundtracks/And_so_it_begins.wav";

PictureBox info = new() {
    Width = 50,
    Height = 50,
    Dock = DockStyle.Left
};

var form = new Form
{
    Text = "ETS Tycoon",
    WindowState = FormWindowState.Maximized,
    FormBorderStyle = FormBorderStyle.None

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

Label money = new()
{
    Location = new Point(30, 5),
    Text = $"Coins: {player.Money}",
    Width = 300,
    Height = 100,
    Font = new Font("Calibri", 20) 
};

info.ImageLocation = "./sprites/coin/coin.gif";
info.SizeMode = PictureBoxSizeMode.AutoSize;

form.Controls.Add(info);
form.Controls.Add(money);

var pb = new PictureBox {
    Dock = DockStyle.Fill,
};

var timer = new Timer {
    Interval = 20,
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
    g.Clear(Color.LightBlue);

    aptc.Draw(g);
    
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


Application.Run(form);
