using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

using Characters;
using Rooms;

namespace EtsTycoon
{
    public class Player
    {
        public static float Money { get; set; } = 0;
        public static int CoinPerSecond { get; set; } = 0;
        public static int Level { get; set; } = 1;
        public static int ClickValue { get; set; } = 1;
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
        public Dictionary<string, Image> Images { get; set; } = new(){ 
            {"back", Bitmap.FromFile("./sprites/backgrounds/back_info3.png")},
            {"c_config", Bitmap.FromFile("./sprites/button/c_config.png")},
            {"b_store", Bitmap.FromFile("./sprites/button/b_store.png")}
        };

        public float secondCounter { get; set; } = 0;
        public static string FormatMoney(double money)
        {
            if (money >= 1e9)
                return (money / 1e9).ToString("0.00") + "G";
            else if (money >= 1e6)
                return (money / 1e6).ToString("0.00") + "M";
            else if (money >= 1e3)
                return (money / 1e3).ToString("0.00") + "K";
            else
                return money.ToString("0.00");
        }

        public void Draw(PictureBox pb, Graphics g)
        {
            g.DrawImage(Images["back"], 0, 0, Game.Pb.Width * 0.25f, Game.Pb.Height * 0.22f);
            pb.Controls.Add(this.CoinImg);
            pb.Controls.Add(this.Label);

            this.Label.Font = new Font("Arial", 0.013f * Game.Pb.Width, FontStyle.Bold);

            this.Label.Text = $"${FormatMoney(Player.Money)} - {Player.CoinPerSecond} C/s\nClick Value: {Player.ClickValue}\nApprentices: {Player.Apprentices.Count}\nInstructors: {Player.Instructors.Count}";
            // g.DrawImage(Images["c_config"], 10, pb.Height - 100, Game.Pb.Width * 0.14f, Game.Pb.Height * 0.1f);
            g.DrawImage(Images["b_store"], 10, pb.Height - 100, Game.Pb.Width * 0.14f, Game.Pb.Height * 0.1f);

        }

        DateTime last = DateTime.Now;
        public void UpdateMoney()
        {
            var now = DateTime.Now;
            var time = (float)(now - last).TotalSeconds;
            Money += CoinPerSecond * time;
            last = now;

            secondCounter += time;
            if(secondCounter >= 0.25)
            {
                BossRoom.Index++;
                secondCounter = 0;
                if(BossRoom.Index > 1)
                    BossRoom.Index = 0;
            }
        }
    }
}
