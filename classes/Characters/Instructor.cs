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

        public Instructor(CharactersData characterData)
        {
            this.Name = characterData.Name;
            this.Age = characterData.Age;
            this.Boost = characterData.Gain;
            this.Salary = characterData.Salary;
            this.img = new(){Bitmap.FromFile(characterData.Img1), Bitmap.FromFile(characterData.Img2)};
            Game.Instructors.Add(this);
        }
    }
}
