using System.Collections.Generic;

public class Room
{
    public int Level { get; set; }
    public List<Apprentice> RoomAprentices { get; set; }
    public Instructor RoomInstructor { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int SizeX { get; set; }
    public int SizeY { get; set; }

}
