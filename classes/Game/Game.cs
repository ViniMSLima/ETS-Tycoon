using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using MotherClasses;
using Characters;
using Rooms;
using System.Runtime.CompilerServices;

namespace EtsTycoon
{
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
        public ApprenticeStore ApStore { get; set; } = new();
        public InstructorStore InStore { get; set; } = new();
        public bool DragAndHold { get; set; } = false;
        public PointF dMouse { get; set; } = new(0, 0);
        public PointF PrevMouse { get; set; }

        public Dictionary<string, Image> Images { get; set; } = new()
        {
            {"grid", Bitmap.FromFile("./sprites/backgrounds/grid.jpg")},
            {"crosswalk", Bitmap.FromFile("./sprites/crosswalk.png")},
            {"limpador", Bitmap.FromFile("./sprites/limpador.png")},
            {"limpador2", Bitmap.FromFile("./sprites/limpador2.png")},
        };
        public static List<Apprentice> Apprentices { get; set; } = new List<Apprentice>();
        public static PointF GeneralPosition { get; set; }= new(0, 0);
        public static PointF PositionNPC { get; set; }= new(1150 + GeneralPosition.X, -200 + GeneralPosition.X);
        public Image Npc1 { get; set; }
        public int Index { get; set; }

        public Game()
        {
            Index = 0;
            Bitmap bmp = null;
            Graphics g = null;
            System.Media.SoundPlayer sound = new()
            {
                SoundLocation = "./soundtracks/And_so_it_begins.wav"
            };

            var timer = new Timer
            {
                Interval = 20,
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
                PositionX = 450 + GeneralPosition.X,
                PositionY = 200 + GeneralPosition.Y
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
                        if (Game.OpenApprenticeStore == true)
                            Game.OpenApprenticeStore = false;
                        else
                            Application.Exit();

                        break;

                    case Keys.W:
                        GeneralPosition = new(GeneralPosition.X, GeneralPosition.Y - 25);
                        break;

                    case Keys.A:
                        GeneralPosition = new(GeneralPosition.X - 25, GeneralPosition.Y);
                        break;

                    case Keys.S:
                        GeneralPosition = new(GeneralPosition.X , GeneralPosition.Y + 25);
                        break;

                    case Keys.D:
                        GeneralPosition = new(GeneralPosition.X + 25, GeneralPosition.Y);
                        break;
                }
            };

            Pb.MouseDown += (o, e) =>
            {
                bool voidClick = true, ClickCheck;

                foreach (Room r in Rooms){
                    ClickCheck = r.ClickCheckAll(e.Location, G);
                    if(ClickCheck)
                        voidClick = false;
                }

                if(voidClick){
                    DragAndHold = true;
                    PrevMouse = e.Location;
                }
            };

            Pb.MouseUp += (o, e) =>
            {
                DragAndHold = false;
                foreach (Room r in Rooms)
                    r.BuyCheckAll();
            };

            Pb.MouseMove += (o, e) =>
            {
                if(DragAndHold)
                {
                    dMouse = new((PrevMouse.X - e.Location.X) * (-1), (PrevMouse.Y - e.Location.Y) * (-1));
                    GeneralPosition = new(GeneralPosition.X + dMouse.X, GeneralPosition.Y + dMouse.Y);

                    PrevMouse = e.Location;
                }
            };
        }

        public void Tick()
        {
            G.Clear(Color.White);
            G.DrawImage(Images["grid"], 0, 0, 2540, 1900);

            const int speed = 3;
            if (Index < speed)
            {
                this.Npc1 = Images["limpador"];
                Index++;
            }
            else
            {
                this.Npc1 = Images["limpador2"];
                Index++;
                if (Index > 2 * speed)
                    Index = 0;
            }

            G.DrawImage(Images["crosswalk"],  350 + Game.GeneralPosition.X, 50 + Game.GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -120 + Game.GeneralPosition.X, 285 + Game.GeneralPosition.Y, 800, 400);
            G.DrawImage(this.Npc1, PositionNPC.X + Game.GeneralPosition.X, PositionNPC.Y + Game.GeneralPosition.Y, 200, 200);

            
            if(PositionNPC.X < -200)
                Game.PositionNPC = new(1350, -300);

            Game.PositionNPC = new(PositionNPC.X - 2, PositionNPC.Y + 1);

            foreach (Room r in Rooms)
                r.Draw(G);

            if (OpenApprenticeStore)
                ApStore.Draw(G);
            if (OpenInstructorStore)
                InStore.Draw(G);

            this.Player.DrawInfo(Pb);
            this.Pb.Refresh();

            TickCounter = 0;
            Player.UpdateMoney();
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

}