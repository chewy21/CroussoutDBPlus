
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
            this.labelItemName = new System.Windows.Forms.Label();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.textBoxItemID = new System.Windows.Forms.TextBox();
            this.labelItemID = new System.Windows.Forms.Label();
            this.buttonItemUpdate = new System.Windows.Forms.Button();
            this.listBoxItemRecipe = new System.Windows.Forms.ListBox();
            this.groupBoxItemSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxItemSearch
            // 
            this.groupBoxItemSearch.Controls.Add(this.buttonItemUpdate);
            this.groupBoxItemSearch.Controls.Add(this.textBoxItemID);
            this.groupBoxItemSearch.Controls.Add(this.labelItemID);
            this.groupBoxItemSearch.Controls.Add(this.textBoxItemName);
            this.groupBoxItemSearch.Controls.Add(this.labelItemName);
            this.groupBoxItemSearch.Location = new System.Drawing.Point(13, 13);
            this.groupBoxItemSearch.Name = "groupBoxItemSearch";
            this.groupBoxItemSearch.Size = new System.Drawing.Size(391, 111);
            this.groupBoxItemSearch.TabIndex = 0;
            this.groupBoxItemSearch.TabStop = false;
            this.groupBoxItemSearch.Text = "Recherche d\'item";
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
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(66, 20);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(100, 20);
            this.textBoxItemName.TabIndex = 1;
            // 
            // textBoxItemID
            // 
            this.textBoxItemID.Location = new System.Drawing.Point(66, 46);
            this.textBoxItemID.Name = "textBoxItemID";
            this.textBoxItemID.Size = new System.Drawing.Size(100, 20);
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
            // buttonItemUpdate
            // 
            this.buttonItemUpdate.Location = new System.Drawing.Point(179, 82);
            this.buttonItemUpdate.Name = "buttonItemUpdate";
            this.buttonItemUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonItemUpdate.TabIndex = 4;
            this.buttonItemUpdate.Text = "Mettre à jour";
            this.buttonItemUpdate.UseVisualStyleBackColor = true;
            // 
            // listBoxItemRecipe
            // 
            this.listBoxItemRecipe.FormattingEnabled = true;
            this.listBoxItemRecipe.Location = new System.Drawing.Point(13, 131);
            this.listBoxItemRecipe.Name = "listBoxItemRecipe";
            this.listBoxItemRecipe.Size = new System.Drawing.Size(391, 303);
            this.listBoxItemRecipe.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxItemRecipe);
            this.Controls.Add(this.groupBoxItemSearch);
            this.Name = "Form1";
            this.Text = "formMain";
            this.groupBoxItemSearch.ResumeLayout(false);
            this.groupBoxItemSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxItemSearch;
        private System.Windows.Forms.Button buttonItemUpdate;
        private System.Windows.Forms.TextBox textBoxItemID;
        private System.Windows.Forms.Label labelItemID;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.ListBox listBoxItemRecipe;
    }
}

