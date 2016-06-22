namespace KeyboardMouseHooks
{
    partial class MouseVision
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
            this.MouseImage = new System.Windows.Forms.PictureBox();
            this.Grid = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MouseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // MouseImage
            // 
            this.MouseImage.BackColor = System.Drawing.Color.Transparent;
            this.MouseImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MouseImage.Image = global::KeyboardMouseHooks.Properties.Resources.Mouse_Default;
            this.MouseImage.InitialImage = null;
            this.MouseImage.Location = new System.Drawing.Point(0, 0);
            this.MouseImage.Name = "MouseImage";
            this.MouseImage.Size = new System.Drawing.Size(597, 615);
            this.MouseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MouseImage.TabIndex = 0;
            this.MouseImage.TabStop = false;
            // 
            // Grid
            // 
            this.Grid.BackColor = System.Drawing.Color.Transparent;
            this.Grid.Location = new System.Drawing.Point(-5000, -5000);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(10000, 10000);
            this.Grid.TabIndex = 1;
            this.Grid.TabStop = false;
            this.Grid.Visible = false;
            this.Grid.Click += new System.EventHandler(this.Grid_Click);
            // 
            // MouseVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(597, 615);
            this.Controls.Add(this.MouseImage);
            this.Controls.Add(this.Grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MouseVision";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MouseVision";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MouseVision_FormClosing);
            this.Load += new System.EventHandler(this.MouseVision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MouseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MouseImage;
        private System.Windows.Forms.PictureBox Grid;
    }
}