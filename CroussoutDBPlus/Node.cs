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
        public string formatBuyPrice { get; private set; }
        public string formatCraftingBuySum { get; private set; }

        //public string Column1 { get; private set; }
        //public string Column2 { get; private set; }
        //public string Column3 { get; private set; }
        public List<Node> Children { get; private set; }

        public Node(long Id, string imageIndex, string Name)//, string col1, string col2, string col3)
        {
            this.Id = Id;
            this.imageIndex = imageIndex;
            this.Name = Name;
            this.formatBuyPrice = "";
            this.formatCraftingBuySum = "";
            this.Children = new List<Node>();

        }
        public Node(long Id, string imageIndex, string Name, string formatBuyPrice)//, string col1, string col2, string col3)
        {
            this.Id = Id;
            this.imageIndex = imageIndex;
            this.Name = Name;
            this.formatBuyPrice = formatBuyPrice;
            this.formatCraftingBuySum = "";
            this.Children = new List<Node>();

        }
        public Node(long Id, string imageIndex, string Name, string formatBuyPrice, string formatCraftingBuySum)//, string col1, string col2, string col3)
        {
            this.Id = Id;
            this.imageIndex = imageIndex;
            this.Name = Name;
            this.formatBuyPrice = formatBuyPrice;
            this.formatCraftingBuySum = formatCraftingBuySum;
            this.Children = new List<Node>();

        }

    }
}
