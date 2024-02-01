using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using EtsTycoon;

namespace Characters
{
    public class Apprentice : CharactersData
    {
        public static List<Apprentice> ApprenticeList { get; set; } = new();
        public Apprentice(CharactersData characterData)
        {
            this.Name = characterData.Name;
            this.Age = characterData.Age;
            this.Gain = characterData.Gain;
            this.Salary = characterData.Salary;
            this.Img = new(){Bitmap.FromFile(characterData.Img1), Bitmap.FromFile(characterData.Img2)};
            this.GainType = characterData.GainType;
            ApprenticeList.Add(this);
        }
    }
}
