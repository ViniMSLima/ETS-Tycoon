using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using MotherClasses;
using Characters;
using Rooms;
using System.Runtime.CompilerServices;
using Structures;

namespace EtsTycoon
{
    public class Game : Form
    {
        public Graphics G { get; set; }
        public Bitmap Bmp { get; set; }
        public Timer Tmr { get; set; }
        public int TickCounter { get; set; }
        public Player Player { get; set; }
        public static PictureBox Pb { get; set; }
        public List<Room> Rooms { get; set; } = new();
        public static Structure OpenApprenticeStore { get; set; } = null;
        public static InstructorsTable OpenInstructorStore { get; set; }
        public ApprenticeStore ApStore { get; set; } = new();
        public InstructorStore InStore { get; set; } = new();
        public bool DragAndHold { get; set; } = false;
        public PointF dMouse { get; set; } = new(0, 0);
        public PointF PrevMouse { get; set; }

        public Dictionary<string, Image> Images { get; set; } = new()
        {
            {"grid",      Bitmap.FromFile("./sprites/backgrounds/grid.jpg")},
            {"crosswalk", Bitmap.FromFile("./sprites/crosswalk.png")},
            {"limpador",  Bitmap.FromFile("./sprites/limpador.png")},
            {"limpador2", Bitmap.FromFile("./sprites/limpador2.png")},
        };
        public static List<Apprentice> Apprentices { get; set; } = new List<Apprentice>();
        public static List<Instructor> Instructors { get; set; } = new List<Instructor>();
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

            Pb = new()
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

            Workshop Workshop = new()
            {
                PositionX = -734 + GeneralPosition.X,
                PositionY = -797 + GeneralPosition.Y
            };

            Rooms.Add(SalaETS);
            Rooms.Add(Workshop);

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
                        if (Game.OpenApprenticeStore != null || Game.OpenInstructorStore != null)
                        {
                            Game.OpenApprenticeStore = null;
                            Game.OpenInstructorStore = null;
                            Store.StoreIndex = 0;
                        }
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

                if (OpenApprenticeStore != null)
                {
                    voidClick = false;
                    ApStore.Draw(G);
                    Store.ClickCheck(e.Location, Store.Btn1, OpenApprenticeStore, G);
                    Store.ClickCheck(e.Location, Store.Btn2, OpenApprenticeStore, G);
                    Store.ClickCheck(e.Location, Store.Btn3, OpenApprenticeStore, G);
                    Store.ClickCheck(e.Location, Store.Btn4, OpenApprenticeStore, G);
                    Store.ClickCheck(e.Location, Store.Btn5, OpenApprenticeStore, G);
                }
                else if (OpenInstructorStore != null)
                {
                    voidClick = false;
                    ApStore.Draw(G);
                    Store.ClickCheck(e.Location, Store.Btn1, OpenInstructorStore, G);
                    Store.ClickCheck(e.Location, Store.Btn2, OpenInstructorStore, G);
                    Store.ClickCheck(e.Location, Store.Btn3, OpenInstructorStore, G);
                    Store.ClickCheck(e.Location, Store.Btn4, OpenInstructorStore, G);
                    Store.ClickCheck(e.Location, Store.Btn5, OpenInstructorStore, G);
                }
                else
                {
                    foreach (Room r in Rooms){
                        ClickCheck = r.ClickCheckAll(e.Location, G);
                        if(ClickCheck)
                            voidClick = false;
                    }
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


            foreach (Room r in Rooms)
                r.Draw(G);

            G.DrawImage(Images["crosswalk"],  350 + Game.GeneralPosition.X, 50 + Game.GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -120 + Game.GeneralPosition.X, 285 + Game.GeneralPosition.Y, 800, 400);
            G.DrawImage(this.Npc1, PositionNPC.X + Game.GeneralPosition.X, PositionNPC.Y + Game.GeneralPosition.Y, 200, 200);
            
            if(PositionNPC.X < -200)
                Game.PositionNPC = new(1350, -300);

            Game.PositionNPC = new(PositionNPC.X - 2, PositionNPC.Y + 1);

            if (OpenApprenticeStore != null)
                ApStore.Draw(G);
                
            if (OpenInstructorStore != null)
                InStore.Draw(G);

            Player.DrawInfo(Pb, G);
            Pb.Refresh();

            TickCounter = 0;
            Player.UpdateMoney();
        }

        public static void CreateCharacters()
        {
            Apprentice Anabelly = new("Anabelly Montibeller", "19", "./sprites/apprentice/table/table_apprentice1.png",  "./sprites/apprentice/table/table_apprentice2.png", 1, 300);
            Apprentice Benhur = new("Benhur Feld", "18", "./sprites/apprentice/table/benhur/benhur1.png", "./sprites/apprentice/table/benhur/benhur2.png", 1, 300);
            Apprentice Eliana = new("Eliana Almeida", "19", "./sprites/apprentice/table/table_apprentice1.png", "./sprites/apprentice/table/table_apprentice2.png", 1, 300);
            Apprentice Emyli = new("Emyli Quadros", "19", "./sprites/apprentice/table/emyli/emyli1.png", "./sprites/apprentice/table/emyli/emyli2.png", 1, 300);
            Apprentice Eric = new("Eric Coutinho", "18", "./sprites/apprentice/table/eric/eric1.png", "./sprites/apprentice/table/eric/eric2.png", 1, 300);
            Apprentice Felipe = new("Felipe Vieira", "19", "./sprites/apprentice/table/felipe/felipe1.png", "./sprites/apprentice/table/felipe/felipe2.png", 1, 300);
            Apprentice Guilherme = new("Guilherme Proença", "18", "./sprites/apprentice/table/table_apprentice1.png", "./sprites/apprentice/table/table_apprentice2.png", 1, 300);
            Apprentice Tavares = new("Tavares (Guilherme)", "18", "./sprites/apprentice/table/tavares/tavares1.png", "./sprites/apprentice/table/tavares/tavares2.png", 1, 300);
            Apprentice Juan = new("Juan Campos", "22", "./sprites/apprentice/table/juan/juan1.png", "./sprites/apprentice/table/juan/juan2.png", 1, 300);
            Apprentice Lander = new("Lander Gerotto", "19", "./sprites/apprentice/table/lander/lander1.png", "./sprites/apprentice/table/lander/lander2.png", 1, 300);
            Apprentice Luis = new("Luis dos Santos", "19", "./sprites/apprentice/table/luis/luis1.png", "./sprites/apprentice/table/luis/luis2.png", 1, 300);
            Apprentice Rosa = new("Rosa (Luiz)", "18", "./sprites/apprentice/table/rosa/rosa1.png", "./sprites/apprentice/table/rosa/rosa2.png", 1, 300);
            Apprentice Marcos = new("Marcos Henrique", "20", "./sprites/apprentice/table/marcos/marcos1.png", "./sprites/apprentice/table/marcos/marcos2.png", 1, 300);
            Apprentice Mateus = new("Mateus Leite", "19", "./sprites/apprentice/table/table_apprentice1.png", "./sprites/apprentice/table/table_apprentice2.png", 1, 300);
            Apprentice Maycon = new("Maycon Bertulino", "20", "./sprites/apprentice/table/maycon/maycon1.png", "./sprites/apprentice/table/maycon/maycon2.png", 1, 300);
            Apprentice Murilo = new("Murilo Socek", "19", "./sprites/apprentice/table/table_apprentice1.png", "./sprites/apprentice/table/table_apprentice2.png", 1, 300);
            Apprentice Renato = new("Renato Mendes", "19", "./sprites/apprentice/table/table_apprentice1.png", "./sprites/apprentice/table/table_apprentice2.png", 1, 300);
            Apprentice Vinicius = new("Vinícius Lima", "19", "./sprites/apprentice/table/vini/vini1.png", "./sprites/apprentice/table/vini/vini2.png", 1, 300);

            Instructor Trevisan = new("Trevisan", "24", "./sprites/instructors/instructor1.png", "./sprites/instructors/instructor2.png", 5, 300);
            Instructor Dom = new("Dom", "24", "./sprites/instructors/instructor1.png", "./sprites/instructors/instructor2.png", 5, 300);
            Instructor Fer = new("Fer", "24", "./sprites/instructors/instructor1.png", "./sprites/instructors/instructor2.png", 5, 300);
            Instructor Alisson = new("Alisson", "24", "./sprites/instructors/instructor1.png", "./sprites/instructors/instructor2.png", 5, 300);
            Instructor Queila = new("Queila", "24", "./sprites/instructors/instructor1.png", "./sprites/instructors/instructor2.png", 5, 300);
            Instructor Moll = new("Moll", "24", "./sprites/instructors/instructor1.png", "./sprites/instructors/instructor2.png", 5, 300);
            Instructor Balem = new("Balem", "24", "./sprites/instructors/instructor1.png", "./sprites/instructors/instructor2.png", 5, 300);
        }
    }
}
