using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Player
{
    public static int Money { get; set; }
    public int Level { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public PictureBox CoinImg { get; set; }
    public Label Label { get; set; }
    public List<Apprentice> Apprentices { get; set; }
    public List<Instructor> Instructors { get; set; }

    public Player()
    {
        Money = 100;
        Level = 1;

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
            Location = new Point(70, 10),
            Text = $"${Player.Money}",
            BackColor = Color.FromArgb(0, 0, 0, 0),
            Width = 300,
            Height = 100,
            Font = new Font("Calibri", 40, FontStyle.Bold)
        };
    }

    public void DrawInfo(Graphics g, PictureBox pb)
    {
        pb.Controls.Add(this.CoinImg);
        pb.Controls.Add(this.Label);
        this.Label.Text = $"${Player.Money}";
    }
}
