using System.Collections.Generic;
using System.Drawing;

using Characters;

namespace Structures
{
    public class Room
    {
        public int Level { get; set; }
        public List<Apprentice> RoomAprentices { get; set; }
        public Instructor RoomInstructor { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public int Value { get; set; } = 1000; 
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public bool Locked { get; set; } = true;
        public Image FloorImg { get; set; }
        public Image TableImg { get; set; }
        public List<Structure> Structures { get; set; } = new();
        public float[] PositionsX { get; set; }
        public float[] PositionsY { get; set; }
        public virtual void Draw(Graphics g) { }
        public void BuyCheckAll() {
            for(int i = 0; i < Structures.Count; i++)
            {
                Structures[i].BuyCheck();
            }
         }
        public bool ClickCheckStructures(Point point, Graphics g) 
        { 
            bool a, b = false;

            for(int i = 0; i < Structures.Count; i++)
            {
                a = Structures[i].ClickCheck(point);
                if(a)
                    b = true;
            }

            return b;
        }
    }
}
