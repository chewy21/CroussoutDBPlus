
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
            this.groupBoxItemSearch = new System.Windows.Forms.GroupBox();
            this.buttonSaveWeaponList = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.comboBoxItemName = new System.Windows.Forms.ComboBox();
            this.buttonItemUpdate = new System.Windows.Forms.Button();
            this.textBoxItemID = new System.Windows.Forms.TextBox();
            this.labelItemID = new System.Windows.Forms.Label();
            this.labelItemName = new System.Windows.Forms.Label();
            this.treeListViewItemRecipe = new BrightIdeasSoftware.TreeListView();
            this.hotItemStyle1 = new BrightIdeasSoftware.HotItemStyle();
            this.groupBoxItemSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewItemRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxItemSearch
            // 
            this.groupBoxItemSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxItemSearch.AutoSize = true;
            this.groupBoxItemSearch.Controls.Add(this.buttonSaveWeaponList);
            this.groupBoxItemSearch.Controls.Add(this.lblProgress);
            this.groupBoxItemSearch.Controls.Add(this.comboBoxItemName);
            this.groupBoxItemSearch.Controls.Add(this.buttonItemUpdate);
            this.groupBoxItemSearch.Controls.Add(this.textBoxItemID);
            this.groupBoxItemSearch.Controls.Add(this.labelItemID);
            this.groupBoxItemSearch.Controls.Add(this.labelItemName);
            this.groupBoxItemSearch.Location = new System.Drawing.Point(5, 5);
            this.groupBoxItemSearch.Name = "groupBoxItemSearch";
            this.groupBoxItemSearch.Size = new System.Drawing.Size(1254, 166);
            this.groupBoxItemSearch.TabIndex = 0;
            this.groupBoxItemSearch.TabStop = false;
            this.groupBoxItemSearch.Text = "Recherche d\'item";
            // 
            // buttonSaveWeaponList
            // 
            this.buttonSaveWeaponList.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSaveWeaponList.Location = new System.Drawing.Point(1176, 16);
            this.buttonSaveWeaponList.Name = "buttonSaveWeaponList";
            this.buttonSaveWeaponList.Size = new System.Drawing.Size(75, 147);
            this.buttonSaveWeaponList.TabIndex = 4;
            this.buttonSaveWeaponList.Text = "Save Weapon List";
            this.buttonSaveWeaponList.UseVisualStyleBackColor = true;
            this.buttonSaveWeaponList.Click += new System.EventHandler(this.buttonSaveWeaponList_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(193, 23);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(35, 13);
            this.lblProgress.TabIndex = 7;
            this.lblProgress.Text = "label1";
            // 
            // comboBoxItemName
            // 
            this.comboBoxItemName.FormattingEnabled = true;
            this.comboBoxItemName.Location = new System.Drawing.Point(66, 20);
            this.comboBoxItemName.Name = "comboBoxItemName";
            this.comboBoxItemName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxItemName.TabIndex = 5;
            this.comboBoxItemName.SelectedIndexChanged += new System.EventHandler(this.comboBoxItemName_SelectedIndexChanged);
            // 
            // buttonItemUpdate
            // 
            this.buttonItemUpdate.Location = new System.Drawing.Point(193, 44);
            this.buttonItemUpdate.Name = "buttonItemUpdate";
            this.buttonItemUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonItemUpdate.TabIndex = 4;
            this.buttonItemUpdate.Text = "Mettre à jour";
            this.buttonItemUpdate.UseVisualStyleBackColor = true;
            this.buttonItemUpdate.Click += new System.EventHandler(this.buttonItemUpdate_Click);
            // 
            // textBoxItemID
            // 
            this.textBoxItemID.Location = new System.Drawing.Point(66, 46);
            this.textBoxItemID.Name = "textBoxItemID";
            this.textBoxItemID.Size = new System.Drawing.Size(121, 20);
            this.textBoxItemID.TabIndex = 3;
            // 
            // labelItemID
            // 
            this.labelItemID.AutoSize = true;
            this.labelItemID.Location = new System.Drawing.Point(7, 46);
            this.labelItemID.Name = "labelItemID";
            this.labelItemID.Size = new System.Drawing.Size(24, 13);
            this.labelItemID.TabIndex = 2;
            this.labelItemID.Text = "ID :";
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.Location = new System.Drawing.Point(7, 20);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(35, 13);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "Nom :";
            // 
            // treeListViewItemRecipe
            // 
            this.treeListViewItemRecipe.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListViewItemRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListViewItemRecipe.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.treeListViewItemRecipe.CellEditUseWholeCell = false;
            this.treeListViewItemRecipe.HideSelection = false;
            this.treeListViewItemRecipe.HotItemStyle = this.hotItemStyle1;
            this.treeListViewItemRecipe.Location = new System.Drawing.Point(5, 177);
            this.treeListViewItemRecipe.Name = "treeListViewItemRecipe";
            this.treeListViewItemRecipe.OverlayImage.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.treeListViewItemRecipe.OverlayText.CornerRounding = 64F;
            this.treeListViewItemRecipe.ShowGroups = false;
            this.treeListViewItemRecipe.ShowImagesOnSubItems = true;
            this.treeListViewItemRecipe.Size = new System.Drawing.Size(1254, 803);
            this.treeListViewItemRecipe.TabIndex = 5;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.groupBoxItemSearch);
            this.Controls.Add(this.treeListViewItemRecipe);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxItemSearch.ResumeLayout(false);
            this.groupBoxItemSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewItemRecipe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxItemSearch;
        private System.Windows.Forms.Button buttonItemUpdate;
        private System.Windows.Forms.TextBox textBoxItemID;
        private System.Windows.Forms.Label labelItemID;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.ComboBox comboBoxItemName;
        private System.Windows.Forms.Button buttonSaveWeaponList;
        private BrightIdeasSoftware.TreeListView treeListViewItemRecipe;
        private System.Windows.Forms.Label lblProgress;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle1;
    }
}

