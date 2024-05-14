using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CroussoutDBPlus
{
    public partial class recipeCreation : Form
    {
        private List<Node> listOfItem;
        public recipeCreation()
        {
            InitializeComponent();


            // creation and customization of NameColumn
            BrightIdeasSoftware.OLVColumn NameColumn = new BrightIdeasSoftware.OLVColumn();
            NameColumn.AspectName = "Name";
            NameColumn.Text = "Nom";
            treeListViewRecipeCreation.Columns.Add(NameColumn);
            // creation and customization of IdColumn
            BrightIdeasSoftware.OLVColumn IdColumn = new BrightIdeasSoftware.OLVColumn();
            IdColumn.AspectName = "Id";
            IdColumn.Text = "Id";
            treeListViewRecipeCreation.Columns.Add(IdColumn);
            // creation and customization of quantityColumn
            BrightIdeasSoftware.OLVColumn QuantityColumn = new BrightIdeasSoftware.OLVColumn();
            QuantityColumn.AspectName = "Quantity";
            QuantityColumn.Text = "Quantity";
            treeListViewRecipeCreation.Columns.Add(QuantityColumn);


            //Global customization of treeListViewRecipeCreation
            treeListViewRecipeCreation.HeaderWordWrap = true;
            treeListViewRecipeCreation.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.F2Only;

            Node parentCustomRecipe = new Node(1, "Enter Name here", 1);
            listOfItem = new List<Node> { parentCustomRecipe };
            treeListViewRecipeCreation.Roots = listOfItem;

            treeListViewRecipeCreation.AutoResizeColumns();


        }

        private void btnRecipeCreationCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeListViewRecipeCreation_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            treeListViewRecipeCreation.AutoResizeColumns();
        }
    }
}
