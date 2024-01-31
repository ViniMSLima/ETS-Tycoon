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
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.2f),
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

    public Upgrade(string name, int value, string desc, string type, string path, int cost)
    {
        this.Name = name;
        this.Value = value;
        this.Descritpion = desc;
        this.Type = type;
        this.Cost = cost;
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

        if (inside)
        {
            if (point.Y < Game.Pb.Height * 0.26)
            {
                Game.OpenUpgradesStore = false;
            }
            else if (point.Y < Game.Pb.Height * 0.38)
            {
                UpgradeIndex = 0;
            }
            else if (point.Y < Game.Pb.Height * 0.50)
            {
                UpgradeIndex = 1;
                Sound.PlaySFX1(0);
            }
            else if (point.Y < Game.Pb.Height * 0.63)
            {
                UpgradeIndex = 2;
                Sound.PlaySFX1(0);
            }
            else 
            {
                UpgradeIndex = 3;
                Sound.PlaySFX1(0);
            }

            if(Player.Money > Upgrades[UpgradeIndex].Cost)
                BuyUpgrade();
            
            else
                MessageBox.Show("Not enough money!!!");
        }

        return inside;
    }

    public static void ClickCheckAll(Point location)
    {
        foreach(PointF[] btn in Buttons)
            ClickCheck(location, btn);
    }

    public static void BuyUpgrade()
    {
        if(Upgrades[UpgradeIndex].Type == "click")
        {
            Player.ClickValue = Upgrades[UpgradeIndex].Value;
            Player.Money -= Upgrades[UpgradeIndex].Cost;
        }

        Upgrades.Remove(Upgrades[UpgradeIndex]);
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


        Pen pen = new(Color.Red, 5f);

        g.DrawPolygon(pen, Buttons[0]);
        g.DrawPolygon(pen, Buttons[1]);
        g.DrawPolygon(pen, Buttons[2]);
        g.DrawPolygon(pen, Buttons[3]);
        g.DrawPolygon(pen, Buttons[4]);

    }

    public static void GenerateUpgrades()
    {
        string json = File.ReadAllText("json/upgrades.json");
        List<Upgrade> upgradesList = JsonConvert.DeserializeObject<List<Upgrade>>(json);

        foreach (Upgrade up in upgradesList)
        {
            if (!string.IsNullOrEmpty(up.Path))
            {
                _ = new Upgrade(up.Name, up.Value, up.Descritpion, up.Type, up.Path, up.Cost);
            }
        }
    }
}
}
