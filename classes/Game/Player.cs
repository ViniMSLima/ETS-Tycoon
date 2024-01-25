using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Characters;
using System;

namespace EtsTycoon
{
    public class Player
    {
        public static float Money { get; set; } = 2000;
        public static int CoinPerSecond { get; set; } = 1;
        public static int Level { get; set; } = 1;
        public PictureBox CoinImg { get; set; } = new()
            {
                Width = 80,
                Height = 80,
                BackColor = Color.FromArgb(0, 0, 0, 0),
                ImageLocation = "./sprites/coin/coin.gif",
                SizeMode = PictureBoxSizeMode.StretchImage
            };
        public Label Label { get; set; } = new()
            {
                Location = new Point(80, 20),
                BackColor = Color.FromArgb(0, 0, 0, 0),
                ForeColor = Color.White,
                Width = 500,
                Height = 200,
                Font = new Font("Calibri", 30, FontStyle.Bold)
            };
        public static List<Apprentice> Apprentices { get; set; } = new();
        public static List<Instructor> Instructors { get; set; } = new();
        public Image Back { get; set; } = Bitmap.FromFile("./sprites/backgrounds/back_info.png");

        public static string FormatMoney(double money)
        {
            if (money >= 1000000000)
                return (money / 1000000000).ToString("0.00") + "G";
            else if (money >= 1000000)
                return (money / 1000000).ToString("0.00") + "M";
            else if (money >= 1000)
                return (money / 1000).ToString("0.00") + "K";
            else
                return money.ToString("0.00");
        }

        public void DrawInfo(PictureBox pb, Graphics g)
        {
            g.DrawImage(Back, 0, 0, 550, 260);
            pb.Controls.Add(this.CoinImg);
            pb.Controls.Add(this.Label);
            this.Label.Text = $"${FormatMoney(Player.Money)} - {Player.CoinPerSecond} C/s\nLevel: {Player.Level}\nApprentices: {Player.Apprentices.Count}\nInstructors: {Player.Instructors.Count}";
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
