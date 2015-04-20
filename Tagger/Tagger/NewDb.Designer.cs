namespace TaggerNamespace
{
    partial class NewDb
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
            this.rootPath = new System.Windows.Forms.TextBox();
            this.fileNameTags = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rootPath
            // 
            this.rootPath.Location = new System.Drawing.Point(12, 56);
            this.rootPath.Name = "rootPath";
            this.rootPath.Size = new System.Drawing.Size(501, 20);
            this.rootPath.TabIndex = 0;
            // 
            // fileNameTags
            // 
            this.fileNameTags.AutoSize = true;
            this.fileNameTags.Location = new System.Drawing.Point(12, 13);
            this.fileNameTags.Name = "fileNameTags";
            this.fileNameTags.Size = new System.Drawing.Size(160, 17);
            this.fileNameTags.TabIndex = 1;
            this.fileNameTags.Text = "Use file name for stored tags";
            this.fileNameTags.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Root directory path:";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(357, 85);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 3;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(438, 85);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // NewDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 120);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileNameTags);
            this.Controls.Add(this.rootPath);
            this.Name = "NewDb";
            this.Text = "New Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rootPath;
        private System.Windows.Forms.CheckBox fileNameTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}