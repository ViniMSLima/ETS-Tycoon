using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Characters;
using Rooms;

public class Game : Form
{
    public Graphics G { get; set; }
    public Bitmap Bmp { get; set; }
    public Timer Tmr { get; set; }
    public int TickCounter { get; set; }
    public Player Player { get; set; }
    public PictureBox Pb { get; set; }
    public List<Room> Rooms { get; set; } = new();
    public static bool OpenApprenticeStore { get; set; }
    public static bool OpenInstructorStore { get; set; }
    public Store ApprenticeStore { get; set; } = new();
    public Store InstructorStore { get; set; } = new();
    public static List<Apprentice> Apprentices { get; set; } = new List<Apprentice>();

    public Game()
    {
        Bitmap bmp = null;
        Graphics g = null;
        System.Media.SoundPlayer sound = new()
        {
            SoundLocation = "./soundtracks/And_so_it_begins.wav"
        };

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

        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.None;

        DigitalRoom SalaETS = new()
        {
            PositionX = 450,
            PositionY = 120
        };

        Rooms.Add(SalaETS);

        this.Load += (o, e) =>
        {
            bmp = new Bitmap(
                Pb.Width,
                Pb.Height
            );

            G = Graphics.FromImage(bmp);
            G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            G.Clear(Color.Black);
            CreateCharacters();
            Pb.Image = bmp;
            timer.Start();
            sound.PlayLooping();
        };

        Controls.Add(Pb);
        timer.Tick += (o, e) => this.Tick();

        KeyDown += (o, e) =>
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if(Game.OpenApprenticeStore == true)
                        Game.OpenApprenticeStore = false;
                    else
                        Application.Exit();
                    break;
            }
        };

        Pb.MouseDown += (o, e) =>
        {
            foreach (Room r in Rooms)
                r.ClickCheckAll(e.Location, G);
        };

        Pb.MouseUp += (o, e) =>
        {
            foreach (Room r in Rooms)
                r.BuyCheckAll();
        };
    }

    public void Tick()
    {
        G.Clear(Color.White);
        G.DrawImage(Bitmap.FromFile("./sprites/backgrounds/grid.jpg"), 0, 0, 2200, 1900);

        foreach (Room r in Rooms)
            r.Draw(G);

        if (OpenApprenticeStore)
            this.ApprenticeStore.Draw(G);
        if (OpenInstructorStore)
            this.InstructorStore.Draw(G);

        this.Player.DrawInfo(G, Pb);
        this.Pb.Refresh();
        TickCounter++;

        if(TickCounter > 6)
        {
            TickCounter = 0;
            Player.Money += Player.CoinPerSecond;
        }
    }

    public static void CreateCharacters()
    {
        Apprentice Anabelly = new("Anabelly Montibeller", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Benhur = new("Benhur Feld", "18", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Eliana = new("Eliana Almeida", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Emyli = new("Emyli Quadros", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Eric = new("Eric Coutinho", "18", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Felipe = new("Felipe Vieira", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Guilherme = new("Guilherme Proença", "18", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Tavares = new("Guilherme Tavares", "18", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Juan = new("Juan Campos", "22", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Lander = new("Lander Gerotto", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Luis = new("Luis dos Santos", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Luiz = new("Luiz Rosa", "18", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Marcos = new("Marcos Henrique", "20", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Mateus = new("Mateus Leite", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Maycon = new("Maycon Bertulino", "20", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Murilo = new("Murilo Socek", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Renato = new("Renato Mendes", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);
        Apprentice Vinicius = new("Vinícius Lima", "19", "./sprites/apprentice/table/table_apprentice1.png", 1, 300);

    }
}
