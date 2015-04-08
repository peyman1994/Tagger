namespace TaggerNamespace
{
    partial class Tagger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tagger));
            this.rootPath = new System.Windows.Forms.TextBox();
            this.Tag = new System.Windows.Forms.Button();
            this.tagContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.newTag = new System.Windows.Forms.ComboBox();
            this.treeView = new TaggerNamespace.MultiSelectTreeview();
            this.SuspendLayout();
            // 
            // rootPath
            // 
            this.rootPath.Location = new System.Drawing.Point(12, 12);
            this.rootPath.Name = "rootPath";
            this.rootPath.Size = new System.Drawing.Size(354, 20);
            this.rootPath.TabIndex = 0;
            // 
            // Tag
            // 
            this.Tag.Location = new System.Drawing.Point(628, 48);
            this.Tag.Name = "Tag";
            this.Tag.Size = new System.Drawing.Size(75, 23);
            this.Tag.TabIndex = 4;
            this.Tag.Text = "Tag";
            this.Tag.UseVisualStyleBackColor = true;
            this.Tag.Click += new System.EventHandler(this.tag_Click);
            // 
            // tagContainer
            // 
            this.tagContainer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tagContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagContainer.Location = new System.Drawing.Point(465, 311);
            this.tagContainer.Name = "tagContainer";
            this.tagContainer.Padding = new System.Windows.Forms.Padding(5);
            this.tagContainer.Size = new System.Drawing.Size(238, 184);
            this.tagContainer.TabIndex = 6;
            // 
            // newTag
            // 
            this.newTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.newTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.newTag.DisplayMember = "Name";
            this.newTag.FormattingEnabled = true;
            this.newTag.Location = new System.Drawing.Point(465, 48);
            this.newTag.Name = "newTag";
            this.newTag.Size = new System.Drawing.Size(157, 21);
            this.newTag.TabIndex = 7;
            this.newTag.ValueMember = "Id";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(13, 48);
            this.treeView.Name = "treeView";
            this.treeView.SelectedNodes = ((System.Collections.Generic.List<System.Windows.Forms.TreeNode>)(resources.GetObject("treeView.SelectedNodes")));
            this.treeView.Size = new System.Drawing.Size(434, 447);
            this.treeView.TabIndex = 5;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // Tagger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 513);
            this.Controls.Add(this.newTag);
            this.Controls.Add(this.tagContainer);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.Tag);
            this.Controls.Add(this.rootPath);
            this.Name = "Tagger";
            this.Text = "Tagger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void treeView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox rootPath;
        private System.Windows.Forms.Button Tag;
        private global::TaggerNamespace.MultiSelectTreeview treeView;
        private System.Windows.Forms.FlowLayoutPanel tagContainer;
        private System.Windows.Forms.ComboBox newTag;
    }
}

