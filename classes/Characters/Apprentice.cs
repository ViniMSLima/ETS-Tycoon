using System.Collections.Generic;
using System.Drawing;
using EtsTycoon;

namespace Characters
{
    public class Apprentice
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public List<Image> Img { get; set; }
        public int CoinPerSecond { get; set; }
        public int Salary { get; set; }

        public Apprentice(CharactersData characterData)
        {
            this.Name = characterData.Name;
            this.Age = characterData.Age;
            this.CoinPerSecond = characterData.Gain;
            this.Salary = characterData.Salary;
            this.Img = new(){Bitmap.FromFile(characterData.Img1), Bitmap.FromFile(characterData.Img2)};
            Game.Apprentices.Add(this);
        }
    }
}
