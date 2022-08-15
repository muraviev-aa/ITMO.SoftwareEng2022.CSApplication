namespace ITMO.CSCourse2022.WFApp5_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GREENPEACE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GREENPEACE
            // 
            this.GREENPEACE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GREENPEACE.Location = new System.Drawing.Point(100, 93);
            this.GREENPEACE.Name = "GREENPEACE";
            this.GREENPEACE.Size = new System.Drawing.Size(348, 59);
            this.GREENPEACE.TabIndex = 0;
            this.GREENPEACE.Text = "GREENPEACE";
            this.GREENPEACE.UseVisualStyleBackColor = true;
            this.GREENPEACE.Click += new System.EventHandler(this.GREENPEACE_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(540, 275);
            this.Controls.Add(this.GREENPEACE);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button GREENPEACE;
    }
}