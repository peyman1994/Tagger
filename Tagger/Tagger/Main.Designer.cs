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
            this.tagButton = new System.Windows.Forms.Button();
            this.tagContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.newTag = new System.Windows.Forms.ComboBox();
            this.recentTags = new System.Windows.Forms.FlowLayoutPanel();
            this.recentTagsLabel = new System.Windows.Forms.Label();
            this.tagContainerLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tagTab = new System.Windows.Forms.TabPage();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.treeView = new TaggerNamespace.MultiSelectTreeview();
            this.tabControl1.SuspendLayout();
            this.tagTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tagButton
            // 
            this.tagButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tagButton.Location = new System.Drawing.Point(640, 11);
            this.tagButton.Name = "tagButton";
            this.tagButton.Size = new System.Drawing.Size(36, 23);
            this.tagButton.TabIndex = 4;
            this.tagButton.Text = "Tag";
            this.tagButton.UseVisualStyleBackColor = true;
            this.tagButton.Click += new System.EventHandler(this.tagButton_Click);
            // 
            // tagContainer
            // 
            this.tagContainer.BackColor = System.Drawing.SystemColors.Window;
            this.tagContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagContainer.Location = new System.Drawing.Point(438, 296);
            this.tagContainer.Name = "tagContainer";
            this.tagContainer.Padding = new System.Windows.Forms.Padding(5);
            this.tagContainer.Size = new System.Drawing.Size(238, 160);
            this.tagContainer.TabIndex = 6;
            // 
            // newTag
            // 
            this.newTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.newTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.newTag.DisplayMember = "Name";
            this.newTag.FormattingEnabled = true;
            this.newTag.Location = new System.Drawing.Point(438, 11);
            this.newTag.Name = "newTag";
            this.newTag.Size = new System.Drawing.Size(196, 21);
            this.newTag.TabIndex = 7;
            this.newTag.ValueMember = "Id";
            // 
            // recentTags
            // 
            this.recentTags.BackColor = System.Drawing.SystemColors.Window;
            this.recentTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recentTags.Location = new System.Drawing.Point(438, 61);
            this.recentTags.Name = "recentTags";
            this.recentTags.Padding = new System.Windows.Forms.Padding(5);
            this.recentTags.Size = new System.Drawing.Size(238, 203);
            this.recentTags.TabIndex = 8;
            // 
            // recentTagsLabel
            // 
            this.recentTagsLabel.AutoSize = true;
            this.recentTagsLabel.Location = new System.Drawing.Point(435, 45);
            this.recentTagsLabel.Name = "recentTagsLabel";
            this.recentTagsLabel.Size = new System.Drawing.Size(69, 13);
            this.recentTagsLabel.TabIndex = 9;
            this.recentTagsLabel.Text = "Recent Tags";
            // 
            // tagContainerLabel
            // 
            this.tagContainerLabel.AutoSize = true;
            this.tagContainerLabel.Location = new System.Drawing.Point(435, 280);
            this.tagContainerLabel.Name = "tagContainerLabel";
            this.tagContainerLabel.Size = new System.Drawing.Size(76, 13);
            this.tagContainerLabel.TabIndex = 10;
            this.tagContainerLabel.Text = "Selected Tags";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tagTab);
            this.tabControl1.Controls.Add(this.searchTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 488);
            this.tabControl1.TabIndex = 11;
            // 
            // tagTab
            // 
            this.tagTab.BackColor = System.Drawing.SystemColors.Control;
            this.tagTab.Controls.Add(this.treeView);
            this.tagTab.Controls.Add(this.tagButton);
            this.tagTab.Controls.Add(this.newTag);
            this.tagTab.Controls.Add(this.recentTagsLabel);
            this.tagTab.Controls.Add(this.tagContainerLabel);
            this.tagTab.Controls.Add(this.recentTags);
            this.tagTab.Controls.Add(this.tagContainer);
            this.tagTab.Location = new System.Drawing.Point(4, 22);
            this.tagTab.Name = "tagTab";
            this.tagTab.Padding = new System.Windows.Forms.Padding(3);
            this.tagTab.Size = new System.Drawing.Size(682, 462);
            this.tagTab.TabIndex = 0;
            this.tagTab.Text = "Tag";
            // 
            // searchTab
            // 
            this.searchTab.Location = new System.Drawing.Point(4, 22);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(682, 462);
            this.searchTab.TabIndex = 1;
            this.searchTab.Text = "Search";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(6, 6);
            this.treeView.Name = "treeView";
            this.treeView.SelectedNodes = ((System.Collections.Generic.List<System.Windows.Forms.TreeNode>)(resources.GetObject("treeView.SelectedNodes")));
            this.treeView.Size = new System.Drawing.Size(423, 450);
            this.treeView.TabIndex = 5;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_DoubleClick);
            // 
            // Tagger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 513);
            this.Controls.Add(this.tabControl1);
            this.Name = "Tagger";
            this.Text = "Tagger";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tagTab.ResumeLayout(false);
            this.tagTab.PerformLayout();
            this.ResumeLayout(false);

        }

        void treeView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button tagButton;
        private global::TaggerNamespace.MultiSelectTreeview treeView;
        private System.Windows.Forms.FlowLayoutPanel tagContainer;
        private System.Windows.Forms.ComboBox newTag;
        private System.Windows.Forms.FlowLayoutPanel recentTags;
        private System.Windows.Forms.Label recentTagsLabel;
        private System.Windows.Forms.Label tagContainerLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tagTab;
        private System.Windows.Forms.TabPage searchTab;
    }
}

