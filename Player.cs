using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Player
{
    public int Money { get; set; }
    public int Level { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public List<Apprentice> Apprentices { get; set; }
    public List<Instructor> Instructors { get; set; }

    public Image Coin { get; set; }

    public Player()
    {
        this.Coin = Bitmap.FromFile("./sprites/coin/coin.gif");
    }

    public void DrawInfo(Graphics g, Player player, PictureBox pb)
    {
        g.DrawImage(this.Coin,
            5, 3, 80, 70
        );

        PictureBox coinImg = new()
        {
            Width = 80,
            Height = 80,
            ImageLocation = "./sprites/coin/coin.gif",
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        Label money = new()
        {
            Location = new Point(90, 30),
            Text = $"Coins: {player.Money}",
            Width = 300,
            Height = 100,
            Font = new Font("Calibri", 30, FontStyle.Bold)
        };

        pb.Controls.Add(money);
        pb.Controls.Add(coinImg);
    }
}
