using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Characters;
using EtsTycoon;


public class Structure
{
    public Image Img { get; set; }
    public PointF[] Points { get; set; }
    public int Price { get; set; }
    public bool Buy { get; set; }
    public Image[] ApprenticeAnimation { get; set; }
    public Dictionary<string, Image> Images { get; set; }
    public Bitmap NameBar { get; set; } = new("./sprites/A.png");

    public virtual void Draw(Graphics g, float roomX, float roomY) { }

    public virtual void BuyCheck() { }
    public virtual void BuyStructure() { }
    public virtual void BuyCharacter(Graphics g, int index) { }
    public virtual bool ClickCheck(PointF point, Graphics g) {return false;}
    public void DrawText(Graphics g, string text, PointF point)
        {
            Color textColor = Color.Black;
            SolidBrush textBrush = new(textColor);

            Font font = new("Arial", 12, FontStyle.Bold);
            SizeF textSize = g.MeasureString(text, font);

            g.DrawImage(NameBar, point.X - 22, point.Y - 82, textSize.Width + 40, textSize.Height + 170);
            g.DrawString(text, font, textBrush, point);
        }

}