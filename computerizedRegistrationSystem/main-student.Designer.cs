namespace computerizedRegistrationSystem
{
    partial class frmMainStudent
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnGrades = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pictureBoxUserImage = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserImage)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(55)))), ((int)(((byte)(27)))));
            this.panel1.Controls.Add(this.btnRegistration);
            this.panel1.Controls.Add(this.btnEditProfile);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnGrades);
            this.panel1.Controls.Add(this.btnSchedule);
            this.panel1.Controls.Add(this.lblStudentID);
            this.panel1.Controls.Add(this.lblFullName);
            this.panel1.Controls.Add(this.pictureBoxUserImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 555);
            this.panel1.TabIndex = 0;
            // 
            // btnRegistration
            // 
            this.btnRegistration.FlatAppearance.BorderSize = 0;
            this.btnRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistration.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistration.ForeColor = System.Drawing.Color.White;
            this.btnRegistration.Location = new System.Drawing.Point(-2, 347);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(200, 35);
            this.btnRegistration.TabIndex = 7;
            this.btnRegistration.Text = "Registration";
            this.btnRegistration.UseVisualStyleBackColor = true;
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.FlatAppearance.BorderSize = 0;
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfile.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProfile.ForeColor = System.Drawing.Color.White;
            this.btnEditProfile.Location = new System.Drawing.Point(0, 307);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(200, 35);
            this.btnEditProfile.TabIndex = 6;
            this.btnEditProfile.Text = "My Profile";
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 519);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 35);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(0, 479);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(200, 35);
            this.btnChangePassword.TabIndex = 5;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(0, 187);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(200, 35);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnGrades
            // 
            this.btnGrades.FlatAppearance.BorderSize = 0;
            this.btnGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrades.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrades.ForeColor = System.Drawing.Color.White;
            this.btnGrades.Location = new System.Drawing.Point(0, 267);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Size = new System.Drawing.Size(200, 35);
            this.btnGrades.TabIndex = 1;
            this.btnGrades.Text = "My Grades";
            this.btnGrades.UseVisualStyleBackColor = true;
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Location = new System.Drawing.Point(0, 227);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(200, 35);
            this.btnSchedule.TabIndex = 1;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // lblStudentID
            // 
            this.lblStudentID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(170)))), ((int)(((byte)(47)))));
            this.lblStudentID.Location = new System.Drawing.Point(8, 124);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(185, 23);
            this.lblStudentID.TabIndex = 2;
            this.lblStudentID.Text = "20-22-0859";
            this.lblStudentID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.White;
            this.lblFullName.Location = new System.Drawing.Point(8, 143);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(185, 23);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Jhone Michael Matias";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxUserImage
            // 
            this.pictureBoxUserImage.BackgroundImage = global::computerizedRegistrationSystem.Properties.Resources.udm_logo1;
            this.pictureBoxUserImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxUserImage.Location = new System.Drawing.Point(38, 9);
            this.pictureBoxUserImage.Name = "pictureBoxUserImage";
            this.pictureBoxUserImage.Size = new System.Drawing.Size(126, 113);
            this.pictureBoxUserImage.TabIndex = 1;
            this.pictureBoxUserImage.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.Controls.Add(this.button1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(200, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(729, 555);
            this.panelContainer.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(265, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 138);
            this.button1.TabIndex = 7;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMainStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 555);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel1);
            this.Name = "frmMainStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDM Portal | Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHome_FormClosing);
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserImage)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.PictureBox pictureBoxUserImage;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegistration;
    }
}