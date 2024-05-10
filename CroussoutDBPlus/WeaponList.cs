using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroussoutDBPlus
{
    public class WeaponList
    {
        public List<Weapon> weapons { get; set; }
    }

    public class Weapon
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

        public Weapon( string id, string name)
        {
            this.Id = id;
            this.Name = name;

        }
    }
}
