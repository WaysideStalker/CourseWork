namespace ZhevakinArtemenkoRGR
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.DeytelStartPicture = new System.Windows.Forms.PictureBox();
            this.MackonellStartPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DeytelStartPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MackonellStartPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // DeytelStartPicture
            // 
            this.DeytelStartPicture.Image = ((System.Drawing.Image)(resources.GetObject("DeytelStartPicture.Image")));
            this.DeytelStartPicture.Location = new System.Drawing.Point(100, 0);
            this.DeytelStartPicture.Name = "DeytelStartPicture";
            this.DeytelStartPicture.Size = new System.Drawing.Size(397, 600);
            this.DeytelStartPicture.TabIndex = 0;
            this.DeytelStartPicture.TabStop = false;
            this.DeytelStartPicture.Click += new System.EventHandler(this.DeytelStartPicture_Click);
            // 
            // MackonellStartPicture
            // 
            this.MackonellStartPicture.Image = ((System.Drawing.Image)(resources.GetObject("MackonellStartPicture.Image")));
            this.MackonellStartPicture.Location = new System.Drawing.Point(690, 0);
            this.MackonellStartPicture.Name = "MackonellStartPicture";
            this.MackonellStartPicture.Size = new System.Drawing.Size(373, 600);
            this.MackonellStartPicture.TabIndex = 1;
            this.MackonellStartPicture.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.MackonellStartPicture);
            this.Controls.Add(this.DeytelStartPicture);
            this.Name = "MainPage";
            this.Text = "MainPage";
            ((System.ComponentModel.ISupportInitialize)(this.DeytelStartPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MackonellStartPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DeytelStartPicture;
        private System.Windows.Forms.PictureBox MackonellStartPicture;
    }
}