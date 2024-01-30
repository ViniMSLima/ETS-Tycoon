using System.Collections.Generic;
using System.Drawing;
using System.IO;

using Extension;
using Newtonsoft.Json;

namespace EtsTycoon
{
    public class Upgrade
    {
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
                    new(Game.Pb.Width * 0.135f,  Game.Pb.Height * 0.4f),
                    new(Game.Pb.Width * 0.135f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                    new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                    new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f),
                },
                new PointF[]{
                new(Game.Pb.Width * 0.82f,  Game.Pb.Height * 0.4f),
                new(Game.Pb.Width * 0.82f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f),
            },
                new PointF[]{
                new(Game.Pb.Width * 0.217f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.217f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.217f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.217f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
              },
                new PointF[]{
                new(Game.Pb.Width * 0.427f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.427f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.427f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.427f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
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
