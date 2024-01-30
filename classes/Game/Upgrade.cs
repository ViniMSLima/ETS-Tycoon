using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Extension;
using Newtonsoft.Json;

namespace EtsTycoon
{
    public class Upgrade
    {
        public string Name { get; set; }
        public string Descritpion { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public static List<Upgrade> Upgrades { get; set; } = new();

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

        public Upgrade()
        {
            Upgrades.Add(this);
        }

        public static void DrawUpgradesStore(Graphics g)
        {
            g.DrawImage(Bitmap.FromFile("./sprites/black_filter.png"), 0, 0);

            g.DrawImage(Images[0],
                Game.Pb.Width * 0.1f,
                Game.Pb.Height * 0.1f,
                Game.Pb.Width * 0.8f,
                Game.Pb.Height * 0.8f
            );

            float pX = 0.1f;
            float pY = 0.08f;

            foreach (Upgrade up in Upgrades)
            {
                g.DrawImage(Images[2],
                Game.Pb.Width * pX,
                Game.Pb.Height * pY + Game.ScrollDelta,
                Game.Pb.Width * 0.8f,
                Game.Pb.Height * 0.8f
                );

                PointF a = new(Game.Pb.Width * (pX + 0.1f), Game.Pb.Height * (pY + 0.225f + Game.ScrollDelta / 1000));

                Text.DrawText(g, up.Name, a, 20);

                pY += 0.12f;
            }
        }

        public static void GenerateUpgrades()
        {
            string json = File.ReadAllText("json/upgrades.json");
            List<Upgrade> upgradesList = JsonConvert.DeserializeObject<List<Upgrade>>(json);

            Upgrades = upgradesList;
        }
    }
}
