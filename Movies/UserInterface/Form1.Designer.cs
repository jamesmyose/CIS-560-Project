
namespace UserInterface
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
            this.bt_ActorMovie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_ActorMovie
            // 
            this.bt_ActorMovie.Location = new System.Drawing.Point(29, 25);
            this.bt_ActorMovie.Name = "bt_ActorMovie";
            this.bt_ActorMovie.Size = new System.Drawing.Size(75, 23);
            this.bt_ActorMovie.TabIndex = 0;
            this.bt_ActorMovie.Text = "ActorMovie";
            this.bt_ActorMovie.UseVisualStyleBackColor = true;
            this.bt_ActorMovie.Click += new System.EventHandler(this.bt_ActorMovie_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_ActorMovie);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_ActorMovie;
    }
}

