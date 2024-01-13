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
    public List<Table> Tables { get; set; }

    public virtual void Draw(Graphics g) {}

}
