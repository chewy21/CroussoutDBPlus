
namespace CroussoutDBPlus
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lblProgress = new System.Windows.Forms.Label();
            this.comboBoxItemName = new System.Windows.Forms.ComboBox();
            this.buttonItemUpdate = new System.Windows.Forms.Button();
            this.textBoxItemID = new System.Windows.Forms.TextBox();
            this.labelItemID = new System.Windows.Forms.Label();
            this.labelItemName = new System.Windows.Forms.Label();
            this.treeListViewItemRecipe = new BrightIdeasSoftware.TreeListView();
            this.hotItemStyle1 = new BrightIdeasSoftware.HotItemStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbSaveSearchedItem = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOptRoute = new System.Windows.Forms.Button();
            this.buttonExpandAll = new System.Windows.Forms.Button();
            this.buttonCollapseAll = new System.Windows.Forms.Button();
            this.cbUpdateToOptiRoad = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.recettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxAddRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxRecipeMangement = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxCustomRecipeHandling = new System.Windows.Forms.ToolStripMenuItem();
            this.objectListViewResourceTotal = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.objectListViewResourceRecomended = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.labelResourceTotal = new System.Windows.Forms.Label();
            this.labelResourceRecomendedTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewItemRecipe)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewResourceTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewResourceRecomended)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            resources.ApplyResources(this.lblProgress, "lblProgress");
            this.lblProgress.Name = "lblProgress";
            // 
            // comboBoxItemName
            // 
            this.comboBoxItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.comboBoxItemName, "comboBoxItemName");
            this.comboBoxItemName.FormattingEnabled = true;
            this.comboBoxItemName.Name = "comboBoxItemName";
            this.comboBoxItemName.Sorted = true;
            this.comboBoxItemName.SelectedIndexChanged += new System.EventHandler(this.comboBoxItemName_SelectedIndexChanged);
            // 
            // buttonItemUpdate
            // 
            resources.ApplyResources(this.buttonItemUpdate, "buttonItemUpdate");
            this.buttonItemUpdate.Name = "buttonItemUpdate";
            this.buttonItemUpdate.UseVisualStyleBackColor = true;
            this.buttonItemUpdate.Click += new System.EventHandler(this.buttonItemUpdate_Click);
            // 
            // textBoxItemID
            // 
            resources.ApplyResources(this.textBoxItemID, "textBoxItemID");
            this.textBoxItemID.Name = "textBoxItemID";
            // 
            // labelItemID
            // 
            resources.ApplyResources(this.labelItemID, "labelItemID");
            this.labelItemID.Name = "labelItemID";
            // 
            // labelItemName
            // 
            resources.ApplyResources(this.labelItemName, "labelItemName");
            this.labelItemName.Name = "labelItemName";
            // 
            // treeListViewItemRecipe
            // 
            this.treeListViewItemRecipe.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListViewItemRecipe.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.treeListViewItemRecipe.CellEditUseWholeCell = false;
            this.treeListViewItemRecipe.CellVerticalAlignment = System.Drawing.StringAlignment.Near;
            this.tableLayoutPanel1.SetColumnSpan(this.treeListViewItemRecipe, 4);
            resources.ApplyResources(this.treeListViewItemRecipe, "treeListViewItemRecipe");
            this.treeListViewItemRecipe.FullRowSelect = true;
            this.treeListViewItemRecipe.HeaderWordWrap = true;
            this.treeListViewItemRecipe.HideSelection = false;
            this.treeListViewItemRecipe.HotItemStyle = this.hotItemStyle1;
            this.treeListViewItemRecipe.Name = "treeListViewItemRecipe";
            this.treeListViewItemRecipe.OverlayText.CornerRounding = 64F;
            this.treeListViewItemRecipe.RowHeight = 28;
            this.tableLayoutPanel1.SetRowSpan(this.treeListViewItemRecipe, 2);
            this.treeListViewItemRecipe.ShowGroups = false;
            this.treeListViewItemRecipe.ShowImagesOnSubItems = true;
            this.treeListViewItemRecipe.UseAlternatingBackColors = true;
            this.treeListViewItemRecipe.UseCellFormatEvents = true;
            this.treeListViewItemRecipe.UseCompatibleStateImageBehavior = false;
            this.treeListViewItemRecipe.UseHotItem = true;
            this.treeListViewItemRecipe.View = System.Windows.Forms.View.Details;
            this.treeListViewItemRecipe.VirtualMode = true;
            this.treeListViewItemRecipe.Expanded += new System.EventHandler<BrightIdeasSoftware.TreeBranchExpandedEventArgs>(this.TreeListViewItemRecipe_Expand);
            this.treeListViewItemRecipe.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.treeListViewRecipe_FormatCell);
            this.treeListViewItemRecipe.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeListViewRecipe_FormatRow);
            // 
            // hotItemStyle1
            // 
            this.hotItemStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.hotItemStyle1.FontStyle = System.Drawing.FontStyle.Bold;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.treeListViewItemRecipe, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStripMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.objectListViewResourceTotal, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.objectListViewResourceRecomended, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelResourceTotal, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelResourceRecomendedTotal, 1, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.comboBoxItemName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelItemName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxItemID, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelItemID, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbSaveSearchedItem, 1, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // cbSaveSearchedItem
            // 
            resources.ApplyResources(this.cbSaveSearchedItem, "cbSaveSearchedItem");
            this.cbSaveSearchedItem.Name = "cbSaveSearchedItem";
            this.cbSaveSearchedItem.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.buttonOptRoute, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonExpandAll, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonCollapseAll, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonItemUpdate, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblProgress, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbUpdateToOptiRoad, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // buttonOptRoute
            // 
            resources.ApplyResources(this.buttonOptRoute, "buttonOptRoute");
            this.buttonOptRoute.Name = "buttonOptRoute";
            this.buttonOptRoute.UseVisualStyleBackColor = true;
            this.buttonOptRoute.Click += new System.EventHandler(this.buttonOptRoute_Click);
            // 
            // buttonExpandAll
            // 
            resources.ApplyResources(this.buttonExpandAll, "buttonExpandAll");
            this.buttonExpandAll.Name = "buttonExpandAll";
            this.buttonExpandAll.UseVisualStyleBackColor = true;
            this.buttonExpandAll.Click += new System.EventHandler(this.buttonExpandAll_Click);
            // 
            // buttonCollapseAll
            // 
            resources.ApplyResources(this.buttonCollapseAll, "buttonCollapseAll");
            this.buttonCollapseAll.Name = "buttonCollapseAll";
            this.buttonCollapseAll.UseVisualStyleBackColor = true;
            this.buttonCollapseAll.Click += new System.EventHandler(this.buttonCollapseAll_Click);
            // 
            // cbUpdateToOptiRoad
            // 
            resources.ApplyResources(this.cbUpdateToOptiRoad, "cbUpdateToOptiRoad");
            this.cbUpdateToOptiRoad.Checked = true;
            this.cbUpdateToOptiRoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUpdateToOptiRoad.Name = "cbUpdateToOptiRoad";
            this.cbUpdateToOptiRoad.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tableLayoutPanel1.SetColumnSpan(this.menuStripMain, 4);
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recettesToolStripMenuItem});
            this.menuStripMain.Name = "menuStripMain";
            // 
            // recettesToolStripMenuItem
            // 
            this.recettesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxAddRecipe,
            this.toolStripTextBoxRecipeMangement,
            this.toolStripTextBoxCustomRecipeHandling});
            this.recettesToolStripMenuItem.Name = "recettesToolStripMenuItem";
            resources.ApplyResources(this.recettesToolStripMenuItem, "recettesToolStripMenuItem");
            // 
            // toolStripTextBoxAddRecipe
            // 
            this.toolStripTextBoxAddRecipe.Name = "toolStripTextBoxAddRecipe";
            resources.ApplyResources(this.toolStripTextBoxAddRecipe, "toolStripTextBoxAddRecipe");
            this.toolStripTextBoxAddRecipe.Click += new System.EventHandler(this.toolStripTextBoxAddRecipe_Click);
            // 
            // toolStripTextBoxRecipeMangement
            // 
            this.toolStripTextBoxRecipeMangement.Name = "toolStripTextBoxRecipeMangement";
            resources.ApplyResources(this.toolStripTextBoxRecipeMangement, "toolStripTextBoxRecipeMangement");
            // 
            // toolStripTextBoxCustomRecipeHandling
            // 
            this.toolStripTextBoxCustomRecipeHandling.Checked = true;
            this.toolStripTextBoxCustomRecipeHandling.CheckOnClick = true;
            this.toolStripTextBoxCustomRecipeHandling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripTextBoxCustomRecipeHandling.Name = "toolStripTextBoxCustomRecipeHandling";
            resources.ApplyResources(this.toolStripTextBoxCustomRecipeHandling, "toolStripTextBoxCustomRecipeHandling");
            // 
            // objectListViewResourceTotal
            // 
            this.objectListViewResourceTotal.AllColumns.Add(this.olvColumn2);
            this.objectListViewResourceTotal.AllColumns.Add(this.olvColumn3);
            this.objectListViewResourceTotal.AllColumns.Add(this.olvColumn4);
            this.objectListViewResourceTotal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.objectListViewResourceTotal.CellEditUseWholeCell = false;
            this.objectListViewResourceTotal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
            this.objectListViewResourceTotal.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.objectListViewResourceTotal, "objectListViewResourceTotal");
            this.objectListViewResourceTotal.HasCollapsibleGroups = false;
            this.objectListViewResourceTotal.HideSelection = false;
            this.objectListViewResourceTotal.Name = "objectListViewResourceTotal";
            this.objectListViewResourceTotal.UseCompatibleStateImageBehavior = false;
            this.objectListViewResourceTotal.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            resources.ApplyResources(this.olvColumn2, "olvColumn2");
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Id";
            resources.ApplyResources(this.olvColumn3, "olvColumn3");
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Quantity";
            resources.ApplyResources(this.olvColumn4, "olvColumn4");
            // 
            // objectListViewResourceRecomended
            // 
            this.objectListViewResourceRecomended.AllColumns.Add(this.olvColumn1);
            this.objectListViewResourceRecomended.AllColumns.Add(this.olvColumn5);
            this.objectListViewResourceRecomended.AllColumns.Add(this.olvColumn6);
            this.objectListViewResourceRecomended.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.objectListViewResourceRecomended.CellEditUseWholeCell = false;
            this.objectListViewResourceRecomended.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn5,
            this.olvColumn6});
            this.objectListViewResourceRecomended.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.objectListViewResourceRecomended, "objectListViewResourceRecomended");
            this.objectListViewResourceRecomended.HideSelection = false;
            this.objectListViewResourceRecomended.Name = "objectListViewResourceRecomended";
            this.objectListViewResourceRecomended.UseCompatibleStateImageBehavior = false;
            this.objectListViewResourceRecomended.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            resources.ApplyResources(this.olvColumn1, "olvColumn1");
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Id";
            resources.ApplyResources(this.olvColumn5, "olvColumn5");
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "Quantity";
            resources.ApplyResources(this.olvColumn6, "olvColumn6");
            // 
            // labelResourceTotal
            // 
            resources.ApplyResources(this.labelResourceTotal, "labelResourceTotal");
            this.labelResourceTotal.Name = "labelResourceTotal";
            // 
            // labelResourceRecomendedTotal
            // 
            resources.ApplyResources(this.labelResourceRecomendedTotal, "labelResourceRecomendedTotal");
            this.labelResourceRecomendedTotal.Name = "labelResourceRecomendedTotal";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.buttonItemUpdate;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewItemRecipe)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewResourceTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewResourceRecomended)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonItemUpdate;
        private System.Windows.Forms.TextBox textBoxItemID;
        private System.Windows.Forms.Label labelItemID;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.ComboBox comboBoxItemName;
        private System.Windows.Forms.Label lblProgress;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonOptRoute;
        private System.Windows.Forms.Button buttonExpandAll;
        private System.Windows.Forms.Button buttonCollapseAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public BrightIdeasSoftware.TreeListView treeListViewItemRecipe;
        private System.Windows.Forms.CheckBox cbSaveSearchedItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private BrightIdeasSoftware.ObjectListView objectListViewResourceTotal;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.ObjectListView objectListViewResourceRecomended;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.Label labelResourceTotal;
        private System.Windows.Forms.Label labelResourceRecomendedTotal;
        private System.Windows.Forms.ToolStripMenuItem recettesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBoxAddRecipe;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBoxCustomRecipeHandling;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBoxRecipeMangement;
        private System.Windows.Forms.CheckBox cbUpdateToOptiRoad;
    }
}

