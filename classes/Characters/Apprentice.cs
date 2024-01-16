using System.Drawing;
using EtsTycoon;

namespace Characters
{
    public class Apprentice
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public Image img;
        public int CoinPerSecond { get; set; }
        public int Salary { get; set; }

        public Apprentice(string name, string age, string imgPath, int coinPerSecond, int salary)
        {
            this.Name = name;
            this.Age = age;
            this.img = Bitmap.FromFile(imgPath);
            this.CoinPerSecond = coinPerSecond;
            this.Salary = salary;
            this.img = Bitmap.FromFile("./sprites/apprentice/table/table_apprentice1.png");
            Game.Apprentices.Add(this);
        }
    }
}
