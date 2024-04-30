using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroussoutDBPlus
{
    public class Recipe
    {
        public int sumBuy { get; set; }
        public double sumSell { get; set; }
        public double craftingCost { get; set; }
        public Item item { get; set; }
        public List<Ingredient> ingredients { get; set; }
        //public List<GameObject> itemInstance = new();
    }
}
