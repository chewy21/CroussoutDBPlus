using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroussoutDBPlus
{
    //---------- test classe node pour treelistview ----------//

    // embedded class
    class Node
    {
        public long Id { get; private set; }
        public string imageIndex { get; private set; }
        public string Name { get; private set; }
        public long Quantity { get; private set; } // quantitée reel (recipe.number)
        public string FormatBuyPrice { get; private set; } // prix valeur haute (Item.)
        public string FormatSellPrice { get; private set; } // prix valeur basse
        public string FormatCraftingBuySum { get; private set; } // prix somme d'achat craft valeur haute
        public string FormatCraftingSellSum { get; private set; } // prix somme d'achat craft valeur basse
        public bool BuyCraft {  get; private set; } // if margin negative buy (0) else craft (1)



        //public string Column1 { get; private set; }
        //public string Column2 { get; private set; }
        //public string Column3 { get; private set; }
        public List<Node> Children { get; private set; }

        
        public Node(Recipe recipe)
        {
            this.Id = recipe.Item.Id;
            this.imageIndex = recipe.Item.Id.ToString();
            this.Name = recipe.Item.Name;
            this.Quantity = recipe.Number;
            this.FormatBuyPrice = recipe.Item.FormatBuyPrice;
            this.FormatSellPrice = recipe.Item.FormatSellPrice;
            this.FormatCraftingBuySum = recipe.Item.FormatCraftingBuySum;
            this.FormatCraftingSellSum = recipe.Item.FormatCraftingSellSum;
            if(recipe.Item.Margin > 0)
            {
                this.BuyCraft = true;
            }
            else
            {
                this.BuyCraft= false;
            }
            
            this.Children = new List<Node>();
        }


    }
}
