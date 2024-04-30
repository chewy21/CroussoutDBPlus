using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroussoutDBPlus
{
    public class Ingredient
    {
        public int number { get; set; }
        public string formatBuyPriceTimesNumber { get; set; }
        public string formatSellPriceTimesNumber { get; set; }
        public int parentId { get; set; }
        public Item item { get; set; }
    }
}
