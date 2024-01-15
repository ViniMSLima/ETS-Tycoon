using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

public class Room
{
    public int Level { get; set; }
    public List<Apprentice> RoomAprentices { get; set; }
    public Instructor RoomInstructor { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public Image FloorImg { get; set; }
    public Image TableImg { get; set; }
    public List<RoomStructure> Structures { get; set; } = new();
    public float[] PositionsX { get; set; }
    public float[] PositionsY { get; set; }
    public virtual void Draw(Graphics g) { }
    public virtual void BuyCheckAll() { }
    public virtual void ClickCheckAll(System.Drawing.Point a, Graphics g) { }



}
