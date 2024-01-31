using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Extension;
using Newtonsoft.Json;

namespace EtsTycoon
{
    public class Upgrade
    {
        public static int StoreIndex { get; set; } = 0;


        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Descritpion { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Path")]
        public string Path { get; set; }
        public Image Img { get; set; }
        public static List<Upgrade> Upgrades { get; set; } = new();

        public static List<PointF[]> Buttons { get; set; } = new(){
            new PointF[]{
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.28f),
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.28f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.28f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.28f),
            },
            new PointF[]{
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.40f),
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.40f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.40f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.40f),
            },
            new PointF[]{
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.52f),
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.52f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.52f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.52f),
            },
            new PointF[]{
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.64f),
                new(Game.Pb.Width * 0.18f,  Game.Pb.Height * 0.64f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.64f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.18f + Game.Pb.Width * 0.65f,  Game.Pb.Height * 0.64f),
            }
            };

        public static List<Image> Images { get; set; } = new()
        {
            Bitmap.FromFile("./sprites/backgrounds/storeBackground.png"),
            Bitmap.FromFile("./sprites/backgrounds/storeCard.png"),
            Bitmap.FromFile("./sprites/backgrounds/upgradeCard.png"),
            Bitmap.FromFile("./sprites/button/leftButton.png"),
            Bitmap.FromFile("./sprites/button/rightButton.png"),
            Bitmap.FromFile("./sprites/button/leftButtonClicked.png"),
            Bitmap.FromFile("./sprites/button/rightButtonClicked.png"),
            Bitmap.FromFile("./sprites/backgrounds/storeCenterButton.png"),
            Bitmap.FromFile("./sprites/coin/Coin.gif"),
            Bitmap.FromFile("./sprites/button/esc_button.png")
        };

        public Upgrade(string name, int value, string desc, string type, string path)
        {
            this.Name = name;
            this.Value = value;
            this.Descritpion = desc;
            this.Type = type;
            this.Img = Bitmap.FromFile(path);

            Upgrades.Add(this);
        }

        public static bool ClickCheck(PointF point, PointF[] a)
        {
            int num_vertices = a.Length;
            double x = point.X, y = point.Y;
            bool inside = false;

            PointF p1 = a[0], p2;

            for (int i = 1; i <= num_vertices; i++)
            {
                p2 = a[i % num_vertices];

                float miny = p1.Y;
                if (p2.Y < p1.Y) miny = p2.Y;

                float maxy = p1.Y;
                if (p2.Y > p1.Y) maxy = p2.Y;

                float maxx = p1.X;
                if (p2.X > p1.X) maxx = p2.X;

                if (y > miny && y <= maxy && x <= maxx)
                {
                    double x_intersection =
                    (y - p1.Y) * (p2.X - p1.X) /
                    (p2.Y - p1.Y) + p1.X;

                    if (p1.X == p2.X || x <= x_intersection)
                        inside = !inside;
                }

                p1 = p2;
            }

            int storeSize = 0;

            if (inside)
            {
                if (point.Y < Game.Pb.Height * 0.3)
                {
                    Game.OpenApprenticeStore = null;
                    Game.OpenInstructorStore = null;
                }
                else if (point.X > Game.Pb.Width * 0.8234375)
                {
                    if (StoreIndex < storeSize - 3)
                        StoreIndex++;
                }
                else if (point.X > Game.Pb.Width * 0.635417)
                {
                    Sound.PlaySFX1(0);
                }
                else if (point.X > Game.Pb.Width * 0.42760417)
                {
                    Sound.PlaySFX1(0);
                }
                else if (point.X > Game.Pb.Width * 0.2177083)
                {
                    Sound.PlaySFX1(0);
                }
                else if (point.X < Game.Pb.Width * 0.1822917)
                {
                    if (StoreIndex > 0)
                        StoreIndex--;
                }
            }

            MessageBox.Show(inside.ToString());
            return inside;
        }

        public static void ClickCheckAll(Point location)
        {
            ClickCheck(location, Buttons[0]);
            ClickCheck(location, Buttons[1]);
            ClickCheck(location, Buttons[2]);
            ClickCheck(location, Buttons[3]);
        }


        public static void DrawUpgradesStore(Graphics g)
        {
            g.DrawImage(Bitmap.FromFile("./sprites/black_filter.png"), 0, 0, Game.Pb.Width, Game.Pb.Height);

            g.DrawImage(Images[0],
                Game.Pb.Width * 0.1f,
                Game.Pb.Height * 0.1f,
                Game.Pb.Width * 0.8f,
                Game.Pb.Height * 0.8f
            );

            float pX = 0.1f;
            float pY = 0.08f;

            var index = 4;
            if (Upgrades.Count < 4)
                index = Upgrades.Count;

            for (int i = 0; i < index; i++)
            {
                g.DrawImage(Images[2],
                    Game.Pb.Width * pX,
                    Game.Pb.Height * pY,
                    Game.Pb.Width * 0.8f,
                    Game.Pb.Height * 0.8f
                );

                g.DrawImage(Upgrades[i].Img,
                    Game.Pb.Width * (pX + 0.1f),
                    Game.Pb.Height * (pY + 0.185f),
                    Game.Pb.Width * 0.06f,
                    Game.Pb.Height * 0.11f
                );

                PointF a = new(Game.Pb.Width * (pX + 0.15f), Game.Pb.Height * (pY + 0.235f));
                PointF b = new(Game.Pb.Width * (pX + 0.3f), Game.Pb.Height * (pY + 0.235f));

                Text.DrawText(g, Upgrades[i].Name, a, 20);
                Text.DrawText(g, Upgrades[i].Descritpion, b, 20);

                pY += 0.12f;
            }


            Pen pen = new(Color.Red, 5f);

            g.DrawPolygon(pen, Buttons[0]);
            g.DrawPolygon(pen, Buttons[1]);
            g.DrawPolygon(pen, Buttons[2]);
            g.DrawPolygon(pen, Buttons[3]);

        }

        public static void GenerateUpgrades()
        {
            string json = File.ReadAllText("json/upgrades.json");
            List<Upgrade> upgradesList = JsonConvert.DeserializeObject<List<Upgrade>>(json);

            foreach (Upgrade up in upgradesList)
            {
                if (!string.IsNullOrEmpty(up.Path))
                {
                    _ = new Upgrade(up.Name, up.Value, up.Descritpion, up.Type, up.Path);
                }
            }
        }
    }
}
