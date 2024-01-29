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
        }
    }

}
