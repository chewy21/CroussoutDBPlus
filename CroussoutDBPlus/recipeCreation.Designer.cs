namespace CroussoutDBPlus
{
    partial class recipeCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeListViewRecipeCreation = new BrightIdeasSoftware.TreeListView();
            this.btnRecipeCreationSave = new System.Windows.Forms.Button();
            this.btnRecipeCreationCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewRecipeCreation)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.treeListViewRecipeCreation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRecipeCreationSave, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRecipeCreationCancel, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treeListViewRecipeCreation
            // 
            this.treeListViewRecipeCreation.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.treeListViewRecipeCreation.CellEditUseWholeCell = false;
            this.tableLayoutPanel1.SetColumnSpan(this.treeListViewRecipeCreation, 3);
            this.treeListViewRecipeCreation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViewRecipeCreation.HideSelection = false;
            this.treeListViewRecipeCreation.Location = new System.Drawing.Point(3, 3);
            this.treeListViewRecipeCreation.Name = "treeListViewRecipeCreation";
            this.treeListViewRecipeCreation.ShowGroups = false;
            this.treeListViewRecipeCreation.Size = new System.Drawing.Size(778, 495);
            this.treeListViewRecipeCreation.TabIndex = 0;
            this.treeListViewRecipeCreation.UseCompatibleStateImageBehavior = false;
            this.treeListViewRecipeCreation.View = System.Windows.Forms.View.Details;
            this.treeListViewRecipeCreation.VirtualMode = true;
            this.treeListViewRecipeCreation.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.treeListViewRecipeCreation_CellEditFinished);
            // 
            // btnRecipeCreationSave
            // 
            this.btnRecipeCreationSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipeCreationSave.Location = new System.Drawing.Point(547, 504);
            this.btnRecipeCreationSave.Name = "btnRecipeCreationSave";
            this.btnRecipeCreationSave.Size = new System.Drawing.Size(114, 54);
            this.btnRecipeCreationSave.TabIndex = 1;
            this.btnRecipeCreationSave.Text = "Sauvegarder";
            this.btnRecipeCreationSave.UseVisualStyleBackColor = true;
            // 
            // btnRecipeCreationCancel
            // 
            this.btnRecipeCreationCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipeCreationCancel.Location = new System.Drawing.Point(667, 504);
            this.btnRecipeCreationCancel.Name = "btnRecipeCreationCancel";
            this.btnRecipeCreationCancel.Size = new System.Drawing.Size(114, 54);
            this.btnRecipeCreationCancel.TabIndex = 2;
            this.btnRecipeCreationCancel.Text = "Annuler";
            this.btnRecipeCreationCancel.UseVisualStyleBackColor = true;
            this.btnRecipeCreationCancel.Click += new System.EventHandler(this.btnRecipeCreationCancel_Click);
            // 
            // recipeCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "recipeCreation";
            this.Text = "recipeCreation";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewRecipeCreation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BrightIdeasSoftware.TreeListView treeListViewRecipeCreation;
        private System.Windows.Forms.Button btnRecipeCreationSave;
        private System.Windows.Forms.Button btnRecipeCreationCancel;
    }
}