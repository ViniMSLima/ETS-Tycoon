using System.Collections.Generic;
using System.Drawing;
using EtsTycoon;

namespace Characters
{
    public class Instructor
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public List<Image> img { get; set; }
        public int Boost { get; set; }
        public int Salary { get; set; }

        public Instructor(string name, string age, string img1Path, string img2Path, int boost, int salary)
        {
            this.Name = name;
            this.Age = age;
            this.Boost = boost;
            this.Salary = salary;
            this.img = new(){Bitmap.FromFile(img1Path), Bitmap.FromFile(img2Path)};
            Game.Instructors.Add(this);
        }
    }
}
