
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
            this.groupBoxItemSearch = new System.Windows.Forms.GroupBox();
            this.buttonItemUpdate = new System.Windows.Forms.Button();
            this.textBoxItemID = new System.Windows.Forms.TextBox();
            this.labelItemID = new System.Windows.Forms.Label();
            this.labelItemName = new System.Windows.Forms.Label();
            this.treeViewRecipe = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxItemName = new System.Windows.Forms.ComboBox();
            this.buttonSaveWeaponList = new System.Windows.Forms.Button();
            this.groupBoxItemSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxItemSearch
            // 
            this.groupBoxItemSearch.Controls.Add(this.comboBoxItemName);
            this.groupBoxItemSearch.Controls.Add(this.buttonItemUpdate);
            this.groupBoxItemSearch.Controls.Add(this.textBoxItemID);
            this.groupBoxItemSearch.Controls.Add(this.labelItemID);
            this.groupBoxItemSearch.Controls.Add(this.labelItemName);
            this.groupBoxItemSearch.Location = new System.Drawing.Point(13, 13);
            this.groupBoxItemSearch.Name = "groupBoxItemSearch";
            this.groupBoxItemSearch.Size = new System.Drawing.Size(391, 111);
            this.groupBoxItemSearch.TabIndex = 0;
            this.groupBoxItemSearch.TabStop = false;
            this.groupBoxItemSearch.Text = "Recherche d\'item";
            // 
            // buttonItemUpdate
            // 
            this.buttonItemUpdate.Location = new System.Drawing.Point(310, 82);
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
            // treeViewRecipe
            // 
            this.treeViewRecipe.Location = new System.Drawing.Point(13, 131);
            this.treeViewRecipe.Name = "treeViewRecipe";
            this.treeViewRecipe.Size = new System.Drawing.Size(766, 303);
            this.treeViewRecipe.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 460);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(766, 488);
            this.dataGridView1.TabIndex = 3;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.buttonSaveWeaponList);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeViewRecipe);
            this.Controls.Add(this.groupBoxItemSearch);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "formMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxItemSearch.ResumeLayout(false);
            this.groupBoxItemSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxItemSearch;
        private System.Windows.Forms.Button buttonItemUpdate;
        private System.Windows.Forms.TextBox textBoxItemID;
        private System.Windows.Forms.Label labelItemID;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.TreeView treeViewRecipe;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxItemName;
        private System.Windows.Forms.Button buttonSaveWeaponList;
    }
}

