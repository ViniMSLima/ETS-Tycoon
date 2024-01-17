using System.Collections.Generic;
using System.Drawing;
using EtsTycoon;

namespace Characters
{
    public class Apprentice
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public List<Image> img { get; set; }
        public int CoinPerSecond { get; set; }
        public int Salary { get; set; }

        public Apprentice(string name, string age, string img1Path, string img2Path, int coinPerSecond, int salary)
        {
            this.Name = name;
            this.Age = age;
            this.CoinPerSecond = coinPerSecond;
            this.Salary = salary;
            this.img = new(){Bitmap.FromFile(img1Path), Bitmap.FromFile(img2Path)};
            Game.Apprentices.Add(this);
        }
    }
}
