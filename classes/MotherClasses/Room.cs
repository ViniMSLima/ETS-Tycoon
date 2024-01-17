using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using Characters;
using Rooms;

namespace MotherClasses
{

    public class Room
    {
        public int Level { get; set; }
        public List<Apprentice> RoomAprentices { get; set; }
        public Instructor RoomInstructor { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public Image FloorImg { get; set; }
        public Image TableImg { get; set; }
        public List<Structure> Structures { get; set; } = new();
        public float[] PositionsX { get; set; }
        public float[] PositionsY { get; set; }
        public virtual void Draw(Graphics g) { }
        public virtual void BuyCheckAll() { }
        public virtual void ClickCheck(PointF point) { }
        public virtual bool ClickCheckAll(System.Drawing.Point a, Graphics g) { return false; }
    }
}
