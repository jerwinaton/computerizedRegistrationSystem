namespace computerizedRegistrationSystem.adminOtherForms
{
    partial class adminReject
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.labelApplicantID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(184, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "Reject";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(67, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Remarks";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.textBoxRemarks.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxRemarks.ForeColor = System.Drawing.Color.Black;
            this.textBoxRemarks.Location = new System.Drawing.Point(71, 50);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(346, 153);
            this.textBoxRemarks.TabIndex = 4;
            // 
            // labelApplicantID
            // 
            this.labelApplicantID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelApplicantID.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelApplicantID.Location = new System.Drawing.Point(159, 7);
            this.labelApplicantID.Name = "labelApplicantID";
            this.labelApplicantID.Size = new System.Drawing.Size(170, 38);
            this.labelApplicantID.TabIndex = 7;
            this.labelApplicantID.Text = "Applicant";
            this.labelApplicantID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adminReject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(505, 284);
            this.Controls.Add(this.labelApplicantID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRemarks);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(521, 323);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(521, 323);
            this.Name = "adminReject";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reject Application";
            this.Load += new System.EventHandler(this.adminReject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelApplicantID;
    }
}