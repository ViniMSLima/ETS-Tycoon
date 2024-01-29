using System.Collections.Generic;

namespace EtsTycoon
{
    public class Upgrade
    {
        public string Name { get; set; }
        public string Descritpion { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public static List<Upgrade> Upgrades { get; set; } = new();

        public Upgrade()
        {
            Upgrades.Add(this);
        }

    }

}
