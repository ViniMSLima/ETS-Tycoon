using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Game
{
    public Graphics G { get; set; }
    public Bitmap Bmp { get; set; }
    public Timer Tmr { get; set; }
    public Player Player { get; set; }
    public PictureBox Pb { get; set; }
    public List<Room> Rooms { get; set; } = new();

    public Game()
    {
        Bitmap bmp = null;
        Graphics g = null;

        var timer = new Timer
        {
            Interval = 20,
            //20000 ticks/second
        };

        this.G = g;
        this.Tmr = timer;
        this.Bmp = bmp;
        this.Player = new();

        this.Pb = new()
        {
            Dock = DockStyle.Fill,
        };
    }

    public void Tick()
    {
        G.Clear(Color.White);
        G.DrawImage(Bitmap.FromFile("./sprites/background/grid.jpg"), 0, 0, 2200, 1900);

        foreach (Room r in Rooms)
        {
            r.Draw(G);
        }

        this.Player.DrawInfo(G, Pb);
        this.Pb.Refresh();
    }

    public void Load(Timer timer, System.Media.SoundPlayer sound)
    {
        var form = new Form
        {
            WindowState = FormWindowState.Maximized,
            FormBorderStyle = FormBorderStyle.None,
            Controls = { Pb }
        };

        form.Load += (o, e) =>
        {
            Bmp = new Bitmap(
                Pb.Width,
                Pb.Height
            );
            G = Graphics.FromImage(Bmp);
            G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            G.Clear(Color.Black);
            Pb.Image = Bmp;
            timer.Start();
            sound.PlayLooping();
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

        Pb.MouseDown += (o, e) =>
        {
            foreach (Room r in Rooms)
            {
                r.ClickCheckAll(e.Location);
            }
        };

        Pb.MouseUp += (o, e) =>
        {
            foreach (Room r in Rooms)
            {
                r.BuyCheckAll();
            }
        };

        form.KeyUp += (o, e) =>
        {
            // switch (e.KeyCode)
            // {

            // }
        };

    }

}