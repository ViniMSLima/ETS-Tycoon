using System.Collections.Generic;
using System.Drawing;
using Characters;
using EtsTycoon;


public class Structure
{
    public Image Img { get; set; }
    public PointF[] Points { get; set; }
    public int Price { get; set; }
    public bool Buy { get; set; }
    public Apprentice Apprentice { get; set; }
    public Image[] ApprenticeAnimation { get; set; }
    public Dictionary<string, Image> Images { get; set; }
    public virtual void Draw(Graphics g, float roomX, float roomY) { }
}
