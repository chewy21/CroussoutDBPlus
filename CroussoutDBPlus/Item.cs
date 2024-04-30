using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroussoutDBPlus
{
    public class Item
    {
        //public int ID { get; set; }
        //public string JSON { get; set; }
        //public string Name { get; set; }

        public int id { get; set; }
        public string name { get; set; }
        public double sellPrice { get; set; }
        public int buyPrice { get; set; }
        public int amount { get; set; } //nombre d'item donné par le craft
        public string formatCraftingMargin { get; set; }
        public string craftVsBuy { get; set; }
        public string lastUpdateTime { get; set; } //dernière récupération des données
        public int rarityId { get; set; }
        public string formatBuyPrice { get; set; }
        public string formatSellPrice { get; set; }
        public int craftingResultAmount { get; set; }
        //public Texture image;


    }
}
