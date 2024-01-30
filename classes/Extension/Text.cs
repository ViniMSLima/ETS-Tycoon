using System.Drawing;
using EtsTycoon;

namespace Extension
{
    public class Text
    {
        public static void DrawText(Graphics g, string text, PointF point, int Size)
        {
            Color textColor = Color.BlanchedAlmond;
            SolidBrush textBrush = new(textColor);

            Font font = new("Arial", Size * Game.Pb.Width * 0.0005f, FontStyle.Bold);
            g.DrawString(text, font, textBrush, point);
        }
    }
}
