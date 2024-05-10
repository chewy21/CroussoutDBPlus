
namespace CroussoutDBPlus
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblProgress = new System.Windows.Forms.Label();
            this.comboBoxItemName = new System.Windows.Forms.ComboBox();
            this.buttonItemUpdate = new System.Windows.Forms.Button();
            this.textBoxItemID = new System.Windows.Forms.TextBox();
            this.labelItemID = new System.Windows.Forms.Label();
            this.labelItemName = new System.Windows.Forms.Label();
            this.treeViewRecipe = new System.Windows.Forms.TreeView();
            this.buttonSaveWeaponList = new System.Windows.Forms.Button();
            this.treeListViewItemRecipe = new BrightIdeasSoftware.TreeListView();
            this.groupBoxItemSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewItemRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            resources.ApplyResources(this.lblProgress, "lblProgress");
            this.lblProgress.Name = "lblProgress";
            // 
            // comboBoxItemName
            // 
            this.comboBoxItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
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
            this.labelItemName.Size = new System.Drawing.Size(35, 13);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "Nom :";
            // 
            // treeViewRecipe
            // 
            this.treeViewRecipe.BackColor = System.Drawing.Color.Gainsboro;
            this.treeViewRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewRecipe.Location = new System.Drawing.Point(13, 131);
            this.treeViewRecipe.Name = "treeViewRecipe";
            this.treeViewRecipe.Size = new System.Drawing.Size(404, 840);
            this.treeViewRecipe.TabIndex = 2;
            this.treeViewRecipe.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRecipe_AfterCollapse);
            this.treeViewRecipe.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRecipe_AfterExpand);
            // 
            // buttonSaveWeaponList
            // 
            this.buttonSaveWeaponList.Location = new System.Drawing.Point(491, 95);
            this.buttonSaveWeaponList.Name = "buttonSaveWeaponList";
            this.buttonSaveWeaponList.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveWeaponList.TabIndex = 4;
            this.buttonSaveWeaponList.Text = "Save Weapon List";
            this.buttonSaveWeaponList.UseVisualStyleBackColor = true;
            this.buttonSaveWeaponList.Click += new System.EventHandler(this.buttonSaveWeaponList_Click);
            // 
            // listViewRecipe
            // 
            this.treeListViewItemRecipe.CellEditUseWholeCell = false;
            this.treeListViewItemRecipe.HideSelection = false;
            this.treeListViewItemRecipe.Location = new System.Drawing.Point(13, 458);
            this.treeListViewItemRecipe.Name = "treeListViewItemRecipe";
            this.treeListViewItemRecipe.ShowGroups = false;
            this.treeListViewItemRecipe.Size = new System.Drawing.Size(1239, 515);
            this.treeListViewItemRecipe.TabIndex = 5;
            this.treeListViewItemRecipe.UseCompatibleStateImageBehavior = false;
            this.treeListViewItemRecipe.View = System.Windows.Forms.View.Details;
            this.treeListViewItemRecipe.VirtualMode = true;
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.treeListViewItemRecipe, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
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
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.lblProgress, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonOptRoute, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonExpandAll, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonCollapseAll, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonItemUpdate, 0, 0);
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
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // cbSaveSearchedItem
            // 
            resources.ApplyResources(this.cbSaveSearchedItem, "cbSaveSearchedItem");
            this.cbSaveSearchedItem.Name = "cbSaveSearchedItem";
            this.cbSaveSearchedItem.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonItemUpdate;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.treeListViewItemRecipe);
            this.Controls.Add(this.buttonSaveWeaponList);
            this.Controls.Add(this.treeViewRecipe);
            this.Controls.Add(this.groupBoxItemSearch);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxItemSearch.ResumeLayout(false);
            this.groupBoxItemSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewItemRecipe)).EndInit();
            this.ResumeLayout(false);

        }

        private void TreeViewRecipe_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button buttonItemUpdate;
        private System.Windows.Forms.TextBox textBoxItemID;
        private System.Windows.Forms.Label labelItemID;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.ComboBox comboBoxItemName;
        private System.Windows.Forms.Button buttonSaveWeaponList;
        private BrightIdeasSoftware.TreeListView treeListViewItemRecipe;
    }
}

