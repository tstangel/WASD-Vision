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
            this.LeftButton = new System.Windows.Forms.PictureBox();
            this.RightButton = new System.Windows.Forms.PictureBox();
            this.Wheel = new System.Windows.Forms.PictureBox();
            this.ThumbForward = new System.Windows.Forms.PictureBox();
            this.ThumbBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MouseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // MouseImage
            // 
            this.MouseImage.Location = new System.Drawing.Point(0, 0);
            this.MouseImage.Name = "MouseImage";
            this.MouseImage.Size = new System.Drawing.Size(100, 50);
            this.MouseImage.TabIndex = 6;
            this.MouseImage.TabStop = false;
            // 
            // LeftButton
            // 
            this.LeftButton.BackColor = System.Drawing.Color.Transparent;
            this.LeftButton.Location = new System.Drawing.Point(0, 0);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(118, 170);
            this.LeftButton.TabIndex = 1;
            this.LeftButton.TabStop = false;
            // 
            // RightButton
            // 
            this.RightButton.BackColor = System.Drawing.Color.Transparent;
            this.RightButton.Location = new System.Drawing.Point(118, 0);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(437, 46);
            this.RightButton.TabIndex = 2;
            this.RightButton.TabStop = false;
            // 
            // Wheel
            // 
            this.Wheel.BackColor = System.Drawing.Color.Transparent;
            this.Wheel.Location = new System.Drawing.Point(118, 46);
            this.Wheel.Name = "Wheel";
            this.Wheel.Size = new System.Drawing.Size(437, 123);
            this.Wheel.TabIndex = 3;
            this.Wheel.TabStop = false;
            // 
            // ThumbForward
            // 
            this.ThumbForward.BackColor = System.Drawing.Color.Transparent;
            this.ThumbForward.Location = new System.Drawing.Point(0, 170);
            this.ThumbForward.Name = "ThumbForward";
            this.ThumbForward.Size = new System.Drawing.Size(118, 412);
            this.ThumbForward.TabIndex = 4;
            this.ThumbForward.TabStop = false;
            // 
            // ThumbBack
            // 
            this.ThumbBack.BackColor = System.Drawing.Color.Transparent;
            this.ThumbBack.Location = new System.Drawing.Point(118, 169);
            this.ThumbBack.Name = "ThumbBack";
            this.ThumbBack.Size = new System.Drawing.Size(437, 412);
            this.ThumbBack.TabIndex = 5;
            this.ThumbBack.TabStop = false;
            // 
            // MouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(555, 581);
            this.Controls.Add(this.ThumbBack);
            this.Controls.Add(this.ThumbForward);
            this.Controls.Add(this.Wheel);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.MouseImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MouseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mouse Vision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MouseForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MouseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MouseImage;
        private System.Windows.Forms.PictureBox LeftButton;
        private System.Windows.Forms.PictureBox RightButton;
        private System.Windows.Forms.PictureBox Wheel;
        private System.Windows.Forms.PictureBox ThumbForward;
        private System.Windows.Forms.PictureBox ThumbBack;
    }
}
