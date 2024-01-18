using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Characters;
using System;

namespace EtsTycoon
{
    public class Player
    {
        public static float Money { get; set; }
        public static int CoinPerSecond { get; set; }
        public int Level { get; set; }
        public PictureBox CoinImg { get; set; }
        public Label Label { get; set; }
        public List<Apprentice> Apprentices { get; set; }
        public List<Instructor> Instructors { get; set; }

        public Player()
        {
            Money = 10000;
            Level = 1;
            CoinPerSecond = 1;

            this.CoinImg = new()
            {
                Width = 80,
                Height = 80,
                BackColor = Color.FromArgb(0, 0, 0, 0),
                ImageLocation = "./sprites/coin/coin.gif",
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            this.Label = new()
            {
                Location = new Point(80, 20),
                Text = $"${Player.Money} - {Player.CoinPerSecond} Coin/second",
                BackColor = Color.FromArgb(0, 0, 0, 0),
                Width = 1200,
                Height = 100,
                Font = new Font("Calibri", 40, FontStyle.Bold)
            };
        }

        public void DrawInfo(PictureBox pb)
        {
            pb.Controls.Add(this.CoinImg);
            pb.Controls.Add(this.Label);
            this.Label.Text = $"${MathF.Round(Player.Money)} - {Player.CoinPerSecond} Coin/second";
        }

        DateTime last = DateTime.Now;
        public void UpdateMoney()
        {
            var now = DateTime.Now;
            var time = (float)(now - last).TotalSeconds;
            Money += CoinPerSecond * time;
            last = now;
        }
    }

}