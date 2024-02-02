using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using MotherClasses;
using Characters;
using Rooms;

using System.Drawing.Drawing2D;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Reflection;

namespace EtsTycoon
{
    public class Game : Form
    {
        public Graphics G { get; set; } = null;
        public Bitmap Bmp { get; set; } = null;
        public Timer Tmr { get; set; }
        public Player Player { get; set; }
        public static PictureBox Pb { get; set; }
        public static List<Room> Rooms { get; set; } = new();
        public List<Room> PlayerRooms { get; set; } = new();
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
            {"start_screen", Bitmap.FromFile("./sprites/backgrounds/start_screen2.png")},
            {"start_btn", Bitmap.FromFile("./sprites/btn_start1.png")},
            {"load_btn", Bitmap.FromFile("./sprites/btn_load1.png")},
            {"settings_btn", Bitmap.FromFile("./sprites/btn_settings1.png")},
            {"exit_btn", Bitmap.FromFile("./sprites/btn_exit1.png")},
        };
        public static List<Apprentice> Apprentices { get; set; } = new List<Apprentice>();
        public static List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public static PointF GeneralPosition { get; set; } = new(0, 0);
        public static PointF PositionNPC { get; set; } = new(1150 + GeneralPosition.X, -200 + GeneralPosition.X);
        public Image Npc1 { get; set; }
        public int Index { get; set; } = 0;

        public static int ScrollDelta { get; set; } = 0;
        public static bool GameStart { get; private set; } = false;

        public static string[] CursorPath { get; set; } = {
            "./sprites/cursor/cur/cursor.cur"
        };

        public static int CursorIndex { get; set; } = 0;

        public Game()
        {
            var timer = new Timer
            {
                Interval = 20,
            };

            this.Tmr = timer;
            this.Player = new();

            Pb = new()
            {
                Dock = DockStyle.Fill,
            };

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

            CreateRooms();

            PlayerRooms.Add(Rooms[0]);

            this.Load += (o, e) =>
            {
                Bmp = new Bitmap(Pb.Width, Pb.Height);

                G = Graphics.FromImage(Bmp);
                G.InterpolationMode = InterpolationMode.NearestNeighbor;
                G.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                G.SmoothingMode = SmoothingMode.HighSpeed;
                G.CompositingQuality = CompositingQuality.AssumeLinear;

                G.Clear(Color.Black);

                CreateCharacters();
                PlayerRooms.Add(Rooms[1]);
                PlayerRooms.Add(Rooms[2]);

                
                Upgrade.GenerateUpgrades();

                Pb.Image = Bmp;
                timer.Start();
                // Sound.StartMusic();
            };

            Controls.Add(Pb);
            timer.Tick += (o, e) => this.Tick();

            KeyDown += (o, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        if (OpenApprenticeStore != null ||
                            OpenInstructorStore != null ||
                            OpenUpgradesStore == true)
                        {
                            OpenApprenticeStore = null;
                            OpenInstructorStore = null;
                            OpenUpgradesStore = false;
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
                        OpenUpgradesStore = !OpenUpgradesStore;
                        break;
                }
            };

            Pb.MouseDown += (o, e) =>
            {
                if (!GameStart)
                    GameStart = true;

                else
                {
                    bool voidClick = true, ClickCheck, ClickCheckBR;

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
                        Upgrade.ClickCheckAll(e.Location);
                    }
                    else
                    {
                        foreach (Room r in PlayerRooms)
                        {
                            ClickCheck = r.ClickCheckStructures(e.Location, G);
                            if (ClickCheck)
                                voidClick = false;
                        }

                        ClickCheckBR = Clicker.Clicks(e.Location);
                        if(ClickCheckBR)
                        {
                            Player.Money += Player.ClickValue;
                            voidClick = false;
                        }
                    }

                    if (voidClick)
                    {
                        DragAndHold = true;
                        PrevMouse = e.Location;
                    }
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

            Pb.MouseWheel += (o, e) => ScrollDelta += e.Delta / 10; //FUTURE ZOOMING DEVELOPMENT
            
        }

        public void Tick()
        {
            this.Cursor = new Cursor(CursorPath[CursorIndex]);
            CursorIndex++;

            if(CursorIndex > CursorPath.Length - 1)
                CursorIndex = 0;

            G.Clear(Color.White);

            if (GameStart)
                DrawGame();
            else
                DrawIntro();

            DrawStore();

            if (OpenUpgradesStore)
            {
                OpenApprenticeStore = null;
                OpenInstructorStore = null;
                Upgrade.DrawUpgradesStore(G);
            }

            // if(Player.Apprentices.Count > 8 && PlayerRooms.Count == 1)
                // PlayerRooms.Add(Rooms[1]);

            // if(Player.Apprentices.Count > 26 && PlayerRooms.Count == 2)
                // PlayerRooms.Add(Rooms[2]);


            Pb.Refresh();
            Player.UpdateMoney();
        }

        public static void CreateCharacters()
        {
            string json = File.ReadAllText("json/characters.json");
            List<CharactersData> characterDataList1 = JsonConvert.DeserializeObject<List<CharactersData>>(json);

            foreach (CharactersData characterData in characterDataList1)
            {
                if (characterData.Type == "Apprentice")
                    _ = new Apprentice(characterData);
                else
                    _ = new Instructor(characterData);
            }

            Apprentices = Apprentice.ApprenticeList;
        }

        public static void CreateRooms()
        {
            _ = new BossRoom()
            {
                PositionX = -530 + GeneralPosition.X,
                PositionY = 567 + GeneralPosition.Y
            };

            _ = new DigitalRoom()
            {
                PositionX = 450 + GeneralPosition.X,
                PositionY = 200 + GeneralPosition.Y
            };

            _ = new Workshop()
            {
                PositionX = -734 + GeneralPosition.X,
                PositionY = -797 + GeneralPosition.Y
            };

        }

        public void DrawIntro()
        {
            G.DrawImage(Images["start_screen"], 0, 0, Pb.Width, Pb.Height);
            G.DrawImage(Images["start_btn"], Pb.Width * 0.265f, Pb.Height * 0.43f, Pb.Width * 0.16f, Pb.Height * 0.2f);
            G.DrawImage(Images["load_btn"], Pb.Width * 0.265f, Pb.Height * 0.475f, Pb.Width * 0.16f, Pb.Height * 0.2f);
            G.DrawImage(Images["settings_btn"], Pb.Width * 0.265f, Pb.Height * 0.52f, Pb.Width * 0.16f, Pb.Height * 0.2f);
            G.DrawImage(Images["exit_btn"], Pb.Width * 0.265f, Pb.Height * 0.562f, Pb.Width * 0.16f, Pb.Height * 0.2f);
        }

        public void DrawGame()
        {
            DrawRoad();

            foreach (Room r in PlayerRooms)
                r.Draw(G);

            DrawNPC();
            Player.Draw(Pb, G);
            Clicker.Draw(G, Rooms[0].PositionX + Game.GeneralPosition.X + 600, Rooms[0].PositionY + Game.GeneralPosition.Y + 650);
        }

        public void DrawRoad()
        {
            G.DrawImage(Images["grid"], 0, 0, 2540, 1900);
            G.DrawImage(Images["crosswalk"], 350 + GeneralPosition.X, 50 + GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -120 + GeneralPosition.X, 285 + GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -590 + GeneralPosition.X, 520 + GeneralPosition.Y, 800, 400);
            G.DrawImage(Images["crosswalk"], -1060 + GeneralPosition.X, 755 + GeneralPosition.Y, 800, 400);
        }

        public void DrawStore()
        {
            if (OpenApprenticeStore != null)
                CharactersStore.Draw(G, "Apprentice");

            if (OpenInstructorStore != null)
                CharactersStore.Draw(G, "Instructor");
        }

        public void DrawNPC()
        {
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

            G.DrawImage(Npc1, PositionNPC.X + GeneralPosition.X, PositionNPC.Y + GeneralPosition.Y, 200, 200);

            if (PositionNPC.X < -1060)
                PositionNPC = new(1350, -300);

            PositionNPC = new(PositionNPC.X - 2, PositionNPC.Y + 1);
        }
    }
}
