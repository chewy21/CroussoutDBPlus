﻿using BrightIdeasSoftware;
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

        //public string imageIndex { get; private set; }

        public long FactionNumber { get; private set; }

        public string Name { get; private set; }

        public long Quantity { get; private set; } // quantitée reel (recipe.number)
        //public long TypeId { get; set; }

        public string FormatBuyPrice { get; private set; } // prix valeur haute (Item.)

        public string FormatSellPrice { get; private set; } // prix valeur basse

        public string FormatCraftingBuySum { get; private set; } // prix somme d'achat craft valeur haute
 
        public string FormatCraftingSellSum { get; private set; } // prix somme d'achat craft valeur basse

        public bool BuyCraft {  get; private set; } // if margin negative buy (0) else craft (1)

        public string FormatCraftingMargin { get; private set; }

        public List<Node> Children { get; private set; }

        
        public Node(Recipe recipe)
        {
            this.Id = recipe.Item.Id;
            //this.imageIndex = recipe.Item.Id.ToString();
            if (recipe.Item.CraftingResultAmount > 0)
            {
                this.FactionNumber = recipe.Item.FactionNumber;
            }
            else { 
                this.FactionNumber = 0; 
            
            }
            
            this.Name = recipe.Item.Name;
            this.Quantity = recipe.Number;
            //this.TypeId = recipe.Item.TypeId;
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
        public Node(long id, string name, long quantity)
        {
            Id = id;
            //FactionNumber = factionNumber;
            Name = name;
            Quantity = quantity;

        }
    }
}
