namespace Assembly_stag
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openTxtImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurentImageAsItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurentImageAsAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("imagePictureBox.Image")));
            this.imagePictureBox.Location = new System.Drawing.Point(164, 15);
            this.imagePictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(671, 489);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePictureBox.TabIndex = 5;
            this.imagePictureBox.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 127);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 48);
            this.button2.TabIndex = 8;
            this.button2.Text = "Enter your message";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 263);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 48);
            this.button3.TabIndex = 9;
            this.button3.Text = "Decrypt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(855, 27);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(74, 24);
            this.toolStripSplitButton1.Text = "Option";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem1,
            this.openTxtImageToolStripMenuItem});
            this.openImageToolStripMenuItem.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openImageToolStripMenuItem.Text = "open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // openImageToolStripMenuItem1
            // 
            this.openImageToolStripMenuItem1.Name = "openImageToolStripMenuItem1";
            this.openImageToolStripMenuItem1.Size = new System.Drawing.Size(185, 26);
            this.openImageToolStripMenuItem1.Text = "open image";
            this.openImageToolStripMenuItem1.Click += new System.EventHandler(this.openImageToolStripMenuItem1_Click);
            // 
            // openTxtImageToolStripMenuItem
            // 
            this.openTxtImageToolStripMenuItem.Name = "openTxtImageToolStripMenuItem";
            this.openTxtImageToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.openTxtImageToolStripMenuItem.Text = "open txt image";
            this.openTxtImageToolStripMenuItem.Click += new System.EventHandler(this.openTxtImageToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCurentImageAsItToolStripMenuItem,
            this.saveCurentImageAsAFileToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save as";
            // 
            // saveCurentImageAsItToolStripMenuItem
            // 
            this.saveCurentImageAsItToolStripMenuItem.Name = "saveCurentImageAsItToolStripMenuItem";
            this.saveCurentImageAsItToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.saveCurentImageAsItToolStripMenuItem.Text = "Image";
            this.saveCurentImageAsItToolStripMenuItem.Click += new System.EventHandler(this.saveCurentImageAsItToolStripMenuItem_Click);
            // 
            // saveCurentImageAsAFileToolStripMenuItem
            // 
            this.saveCurentImageAsAFileToolStripMenuItem.Name = "saveCurentImageAsAFileToolStripMenuItem";
            this.saveCurentImageAsAFileToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.saveCurentImageAsAFileToolStripMenuItem.Text = "Text";
            this.saveCurentImageAsAFileToolStripMenuItem.Click += new System.EventHandler(this.saveCurentImageAsAFileToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 196);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 48);
            this.button1.TabIndex = 12;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 339);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 48);
            this.button4.TabIndex = 13;
            this.button4.Text = "save encrypted image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 543);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.imagePictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openTxtImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurentImageAsItToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurentImageAsAFileToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}

