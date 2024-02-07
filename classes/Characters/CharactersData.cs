using System.Collections.Generic;
using System.Drawing;

namespace Characters
{
    public class CharactersData
    {
        public string Name { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Type { get; set; }
        public string GainType { get; set; }
        public string Age { get; set; }
        public int Salary { get; set; }
        public int Gain { get; set; }
        public int CoinPerSecond { get; set; }
        public int Boost { get; set; }
        public List<Image> Img { get; set; }
    }
}