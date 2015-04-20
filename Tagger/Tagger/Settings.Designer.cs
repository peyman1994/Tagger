namespace TaggerNamespace
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.saveLocation = new System.Windows.Forms.TextBox();
            this.updateSqlLocation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.databases = new System.Windows.Forms.ListView();
            this.refresh = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.setDefault = new System.Windows.Forms.Button();
            this.newDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save Location";
            // 
            // saveLocation
            // 
            this.saveLocation.Location = new System.Drawing.Point(15, 32);
            this.saveLocation.Name = "saveLocation";
            this.saveLocation.Size = new System.Drawing.Size(355, 20);
            this.saveLocation.TabIndex = 1;
            // 
            // updateSqlLocation
            // 
            this.updateSqlLocation.Location = new System.Drawing.Point(376, 30);
            this.updateSqlLocation.Name = "updateSqlLocation";
            this.updateSqlLocation.Size = new System.Drawing.Size(75, 23);
            this.updateSqlLocation.TabIndex = 2;
            this.updateSqlLocation.Text = "Update";
            this.updateSqlLocation.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Databases";
            // 
            // databases
            // 
            this.databases.Location = new System.Drawing.Point(15, 80);
            this.databases.Name = "databases";
            this.databases.Size = new System.Drawing.Size(433, 165);
            this.databases.TabIndex = 4;
            this.databases.UseCompatibleStateImageBehavior = false;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(15, 255);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(94, 23);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(115, 255);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(109, 23);
            this.remove.TabIndex = 6;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            // 
            // setDefault
            // 
            this.setDefault.Location = new System.Drawing.Point(230, 255);
            this.setDefault.Name = "setDefault";
            this.setDefault.Size = new System.Drawing.Size(107, 23);
            this.setDefault.TabIndex = 7;
            this.setDefault.Text = "Set as Default";
            this.setDefault.UseVisualStyleBackColor = true;
            // 
            // newDb
            // 
            this.newDb.Location = new System.Drawing.Point(343, 255);
            this.newDb.Name = "newDb";
            this.newDb.Size = new System.Drawing.Size(105, 23);
            this.newDb.TabIndex = 8;
            this.newDb.Text = "New";
            this.newDb.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 290);
            this.Controls.Add(this.newDb);
            this.Controls.Add(this.setDefault);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.databases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updateSqlLocation);
            this.Controls.Add(this.saveLocation);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saveLocation;
        private System.Windows.Forms.Button updateSqlLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView databases;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button setDefault;
        private System.Windows.Forms.Button newDb;
    }
}