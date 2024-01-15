using System.Drawing;

public class RoomStructure
{
    public Image img { get; set; }
    public PointF[] Points { get; set; }
    public int Price { get; set; }
    public bool Buy { get; set; }

    public virtual void Draw(Graphics g, float roomX, float roomY) { }
}