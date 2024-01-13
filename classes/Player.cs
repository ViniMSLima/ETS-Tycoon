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
        Money = 100;
        Level = 1;
        this.Coin = Bitmap.FromFile("./sprites/coin/coin.gif");
    }

    public void DrawInfo(Graphics g, PictureBox pb)
    {

        PictureBox coinImg = new()
        {
            Width = 80,
            Height = 80,
            BackColor = Color.FromArgb(0, 0, 0, 0),
            ImageLocation = "./sprites/coin/coin.gif",
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        Label money = new()
        {
            Location = new Point(70, 10),
            Text = $"${Money}",
            BackColor = Color.FromArgb(0, 0, 0, 0),
            Width = 300,
            Height = 100,
            Font = new Font("Calibri", 40, FontStyle.Bold)
        };

        pb.Controls.Add(money);
        pb.Controls.Add(coinImg);
    }
}
