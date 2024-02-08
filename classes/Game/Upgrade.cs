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
        public static int UpgradeIndex { get; set; } = 0;

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Descritpion { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Cost")]
        public int Cost { get; set; }

        [JsonProperty("Path")]
        public string Path { get; set; }
        [JsonProperty("Cur_Path")]
        public string[] Cur_Path { get; set; }
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
            },
            new PointF[]{
                new(Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.10f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.10f,  Game.Pb.Height * 0.2f),
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

        public Upgrade(string name, int value, string desc, string type, string path, int cost, string[] cur_path)
        {
            this.Name = name;
            this.Value = value;
            this.Descritpion = desc;
            this.Type = type;
            this.Cost = cost;
            this.Cur_Path = cur_path;
            this.Img = Bitmap.FromFile(path);

            Upgrades.Add(this);
        }

        public static bool ClickCheck(PointF point, PointF[] a)
        {
            bool inside = Clicker.ContainsClick(point, a);

            if (inside)
            {
                if (point.Y < Game.Pb.Height * 0.26)
                {
                    Game.OpenUpgradesStore = false;
                }
                else if (point.Y < Game.Pb.Height * 0.38 && Upgrades.Count > 0)
                {
                    UpgradeIndex = 0;
                    BuyUpgrade();
                }
                else if (point.Y < Game.Pb.Height * 0.50 && Upgrades.Count > 1)
                {
                    UpgradeIndex = 1;
                    MessageBox.Show("Can't buy this upgrade before " + Upgrades[0].Descritpion);
                    // Sound.PlaySFX1(0);
                    // BuyUpgrade();
                }
                else if (point.Y < Game.Pb.Height * 0.63 && Upgrades.Count > 2)
                {
                    UpgradeIndex = 2;
                    MessageBox.Show("Can't buy this upgrade before " + Upgrades[1].Descritpion);
                    // Sound.PlaySFX1(0);
                    // BuyUpgrade();
                }
                else if (Upgrades.Count > 3)
                {
                    UpgradeIndex = 3;
                    MessageBox.Show("Can't buy this upgrade before " + Upgrades[2].Descritpion);
                    // Sound.PlaySFX1(0);
                    // BuyUpgrade();

                }
            }

            return inside;
        }

        public static void ClickCheckAll(Point location)
        {
            foreach (PointF[] btn in Buttons)
                ClickCheck(location, btn);
        }

        private static void BuyUpgrade()
        {
            if (Upgrades[UpgradeIndex].Type == "click")
            {
                if (Player.Money > Upgrades[UpgradeIndex].Cost)
                {

                    Player.ClickValue = Upgrades[UpgradeIndex].Value;
                    Player.Money -= Upgrades[UpgradeIndex].Cost;
                    Game.CursorPath = Upgrades[UpgradeIndex].Cur_Path;
                    Upgrades.Remove(Upgrades[UpgradeIndex]);
                }
                else
                    MessageBox.Show("Not enough money!!!");
            }

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
            g.DrawImage(Images[9],
                    Game.Pb.Width * 0.12f,
                    Game.Pb.Height * 0.2f
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
                    Game.Pb.Height * (pY + 0.19f),
                    Game.Pb.Width * 0.05f,
                    Game.Pb.Height * 0.09f
                );

                PointF a = new(Game.Pb.Width * (pX + 0.15f), Game.Pb.Height * (pY + 0.235f));
                PointF b = new(Game.Pb.Width * (pX + 0.3f), Game.Pb.Height * (pY + 0.235f));
                PointF c = new(Game.Pb.Width * (pX + 0.6f), Game.Pb.Height * (pY + 0.235f));

                Text.DrawText(g, Upgrades[i].Name, a, 20);
                Text.DrawText(g, Upgrades[i].Descritpion, b, 20);
                Text.DrawText(g, Upgrades[i].Cost.ToString(), c, 20);

                pY += 0.12f;
            }
        }

        public static void GenerateUpgrades()
        {
            string json = File.ReadAllText("json/upgrades.json");
            List<Upgrade> upgradesList = JsonConvert.DeserializeObject<List<Upgrade>>(json);

            foreach (Upgrade up in upgradesList)
            {
                if (!string.IsNullOrEmpty(up.Path))
                {
                    _ = new Upgrade(up.Name, up.Value, up.Descritpion, up.Type, up.Path, up.Cost, up.Cur_Path);
                }
            }
        }
    }
}
