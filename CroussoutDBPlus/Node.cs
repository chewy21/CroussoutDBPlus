using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;

namespace CroussoutDBPlus
{
    //---------- test classe node pour treelistview ----------//

    // embedded class
    class Node
    {
        [OLVColumn("Id",IsVisible =false)]
        public long Id { get; private set; }
        [OLVColumn("Icone",ImageAspectName ="168", Name = "imageIndexColumn")]
        public string imageIndex { get; private set; }
        [OLVColumn("Nom",DisplayIndex = 1)]
        public string Name { get; private set; }
        [OLVColumn("Quantité à acheter/crafter")]
        public long Quantity { get; private set; } // quantitée reel (recipe.number)
        [OLVColumn("achat direct (Val. haute)")]
        public string FormatBuyPrice { get; private set; } // prix valeur haute (Item.)
        [OLVColumn("achat direct (Val. basse)")]
        public string FormatSellPrice { get; private set; } // prix valeur basse
        [OLVColumn("achat des items pour craft (Val. haute)")]
        public string FormatCraftingBuySum { get; private set; } // prix somme d'achat craft valeur haute
        [OLVColumn("achat des items pour craft (Val. basse)")]
        public string FormatCraftingSellSum { get; private set; } // prix somme d'achat craft valeur basse
        [OLVColumn("Craft ?", IsEditable=false)]
        public bool BuyCraft {  get; private set; } // if margin negative buy (0) else craft (1)
        [OLVColumn("Marge de profit si crafté")]
        public string FormatCraftingMargin { get; private set; }

        [OLVColumn(IsVisible = false)]
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
            if(recipe.Item.CraftingMargin > 0)
            {
                this.BuyCraft = true;
            }
            else
            {
                this.BuyCraft= false;
            }
            this.FormatCraftingMargin = recipe.Item.FormatCraftingMargin;
            
            this.Children = new List<Node>();
        }


    }
}
