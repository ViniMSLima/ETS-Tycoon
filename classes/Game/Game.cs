using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using MotherClasses;
using Characters;
using Rooms;

using Newtonsoft.Json;

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
        public static Structure OpenInstructorStore { get; set; }
        public static bool OpenUpgradesStore { get; set; }
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
        public static PointF GeneralPosition { get; set; } = new(0, 0);
        public static PointF PositionNPC { get; set; } = new(1150 + GeneralPosition.X, -200 + GeneralPosition.X);
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

            BossRoom BossRoom = new()
            {
                PositionX = -530 + GeneralPosition.X,
                PositionY = 567 + GeneralPosition.Y
            };

            Rooms.Add(SalaETS);
            Rooms.Add(Workshop);
            Rooms.Add(BossRoom);

            this.Load += (o, e) =>
            {
                bmp = new Bitmap(Pb.Width, Pb.Height);

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
                        if (Game.OpenApprenticeStore != null || Game.OpenInstructorStore != null || Game.OpenUpgradesStore == true)
                        {
                            Game.OpenApprenticeStore = null;
                            Game.OpenInstructorStore = null;
                            Game.OpenUpgradesStore = false;
                            CharactersStore.StoreIndex = 0;
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
                        GeneralPosition = new(GeneralPosition.X, GeneralPosition.Y + 25);
                        break;

                    case Keys.D:
                        GeneralPosition = new(GeneralPosition.X + 25, GeneralPosition.Y);
                        break;

                    case Keys.B:
                        Sound.PlaySFX1(3);
                        OpenUpgradesStore = true;
                        break;
                }
            };

            Pb.MouseDown += (o, e) =>
            {
                Player.Money += Player.ClickValue;

                bool voidClick = true, ClickCheck;

                if (OpenApprenticeStore != null)
                {
                    voidClick = false;
                    CharactersStore.ClickCheckAll(e.Location, OpenApprenticeStore, G);
                }
                else if (OpenInstructorStore != null)
                {
                    voidClick = false;
                    CharactersStore.ClickCheckAll(e.Location, OpenInstructorStore, G);
                }
                else if (OpenUpgradesStore)
                {
                    voidClick = false;
                    // Store.ClickCheckAll(e.Location, OpenUpgradesStore, G);
                }
                else
                {
                    foreach (Room r in Rooms)
                    {
                        ClickCheck = r.ClickCheckStructures(e.Location, G);
                        if (ClickCheck)
                            voidClick = false;
                    }
                }

                if (voidClick)
                {
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
                if (DragAndHold)
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
            G.DrawImage(Images["crosswalk"], 350 + Game.GeneralPosition.X, 50 + Game.GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -120 + Game.GeneralPosition.X, 285 + Game.GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -590 + Game.GeneralPosition.X, 520 + Game.GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -1060 + Game.GeneralPosition.X, 755 + Game.GeneralPosition.Y, 800, 400);

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

            G.DrawImage(this.Npc1, PositionNPC.X + Game.GeneralPosition.X, PositionNPC.Y + Game.GeneralPosition.Y, 200, 200);

            if (PositionNPC.X < -1060)
                Game.PositionNPC = new(1350, -300);

            Game.PositionNPC = new(PositionNPC.X - 2, PositionNPC.Y + 1);

            Player.Draw(Pb, G);

            if (OpenApprenticeStore != null)
                CharactersStore.Draw(G, "Apprentice");

            if (OpenInstructorStore != null)
                CharactersStore.Draw(G, "Instructor");

            if (OpenUpgradesStore)
                CharactersStore.Draw(G, "Upgrade");

            Pb.Refresh();

            TickCounter = 0;
            Player.UpdateMoney();
        }

        public static void CreateCharacters()
        {
            string json = File.ReadAllText("characters/characters.json");
            List<CharactersData> characterDataList1 = JsonConvert.DeserializeObject<List<CharactersData>>(json);

            foreach (CharactersData characterData in characterDataList1)
            {
                if (characterData.Type == "Apprentice")
                    _ = new Apprentice(characterData);
                else
                    _ = new Instructor(characterData);
            }
        }
    }
}
