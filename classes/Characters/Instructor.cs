using System.Collections.Generic;
using System.Drawing;
using EtsTycoon;

namespace Characters
{
    public class Instructor : CharactersData
    {
        public Instructor(CharactersData characterData)
        {
            this.Name = characterData.Name;
            this.Age = characterData.Age;
            this.Gain = characterData.Gain;
            this.Salary = characterData.Salary;
            this.Img = new(){Bitmap.FromFile(characterData.Img1), Bitmap.FromFile(characterData.Img2)};
            this.GainType = characterData.GainType;
            Game.Instructors.Add(this);
        }
    }
}
