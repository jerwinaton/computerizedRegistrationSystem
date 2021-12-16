namespace computerizedRegistrationSystem
{
    partial class grades
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGrades = new System.Windows.Forms.Label();
            this.lblComingSoon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGrades
            // 
            this.lblGrades.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGrades.AutoSize = true;
            this.lblGrades.Font = new System.Drawing.Font("Verdana", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrades.Location = new System.Drawing.Point(30, 20);
            this.lblGrades.Name = "lblGrades";
            this.lblGrades.Size = new System.Drawing.Size(240, 49);
            this.lblGrades.TabIndex = 5;
            this.lblGrades.Text = "My Grades";
            this.lblGrades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComingSoon
            // 
            this.lblComingSoon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblComingSoon.AutoSize = true;
            this.lblComingSoon.Font = new System.Drawing.Font("Arial", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComingSoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblComingSoon.Location = new System.Drawing.Point(288, 265);
            this.lblComingSoon.Name = "lblComingSoon";
            this.lblComingSoon.Size = new System.Drawing.Size(153, 24);
            this.lblComingSoon.TabIndex = 6;
            this.lblComingSoon.Text = "Coming Soon...";
            // 
            // grades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblComingSoon);
            this.Controls.Add(this.lblGrades);
            this.Name = "grades";
            this.Size = new System.Drawing.Size(729, 555);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrades;
        private System.Windows.Forms.Label lblComingSoon;
    }
}
