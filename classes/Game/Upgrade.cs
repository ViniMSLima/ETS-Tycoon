using System.Collections.Generic;
using System.Drawing;

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
            Bitmap.FromFile("./sprites/button/leftButton.png"),
            Bitmap.FromFile("./sprites/button/rightButton.png"),
            Bitmap.FromFile("./sprites/button/leftButtonClicked.png"),
            Bitmap.FromFile("./sprites/button/rightButtonClicked.png"),
            Bitmap.FromFile("./sprites/coin/Coin.gif"),
            Bitmap.FromFile("./sprites/button/esc_button.png")
        };

        public Upgrade()
            => Upgrades.Add(this);

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
            float pY = 0.1f;

            foreach (Upgrade up in Upgrades)
            {
                g.DrawImage(Images[7],
                Game.Pb.Width * pX,
                Game.Pb.Height * pY,
                Game.Pb.Width * 0.1f,
                Game.Pb.Height * 0.1f
                );

                pY += 0.1f;
            }
        }

        public static void GenerateUpgrades()
        {
            Upgrade up1 = new();
            Upgrade up2 = new();
            Upgrade up3 = new();
            Upgrade up4 = new();
            Upgrade up5 = new();
            Upgrade up6 = new();
            Upgrade up7 = new();
            Upgrade up8 = new();

            //Click upgrades based on programming languages from ETS
        }
    }

}
