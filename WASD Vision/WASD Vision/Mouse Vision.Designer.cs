namespace WASD_Vision
{
    partial class MouseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseForm));
            this.MouseImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MouseImage)).BeginInit();
            this.SuspendLayout();
            // 
            // MouseImage
            // 
            this.MouseImage.BackColor = System.Drawing.Color.Transparent;
            this.MouseImage.Image = global::WASD_Vision.Properties.Resources.Mouse_Default;
            this.MouseImage.Location = new System.Drawing.Point(0, 0);
            this.MouseImage.Name = "MouseImage";
            this.MouseImage.Size = new System.Drawing.Size(597, 615);
            this.MouseImage.TabIndex = 0;
            this.MouseImage.TabStop = false;
            // 
            // MouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(597, 615);
            this.Controls.Add(this.MouseImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MouseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mouse Vision";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MouseForm_FormClosing);
            this.Load += new System.EventHandler(this.MouseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MouseImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MouseImage;
    }
}
