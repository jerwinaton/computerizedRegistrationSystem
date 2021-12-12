using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computerizedRegistrationSystem
{
    public partial class frmMainStudent : Form
    {
        public frmMainStudent()
        {
            InitializeComponent();
            //set the home user control as default page
            home uc = new home();
            addUserControl(uc);
        }
        private void frmHome_Load(object sender, EventArgs e)
        {


        }
        //logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            frmLogin formLogin = new frmLogin();
            formLogin.Show();
        }
        //method to dynamically load user controls pages
        private void addUserControl (UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        //click events on the side nav and then call the method to change the user
        // controls page on the right
        private void btnHome_Click(object sender, EventArgs e)
        {
            home uc = new home();
            addUserControl(uc);
        }
        //show schedule page
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            schedule uc = new schedule();
            addUserControl(uc);
        }
        //show grades page
        private void btnGrades_Click(object sender, EventArgs e)
        {
            grades uc = new grades();
            addUserControl(uc);
        }
        //show edit profile page
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            profile uc = new profile();
            addUserControl(uc);
        }
        //show change password page
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            password uc = new password();
            addUserControl(uc);
        }

        //show msgbox on closing the form
        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to exit the application?";
            string title = "Error";
            SendKeys.Send("{Tab}");//switch focus to No button by default
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if (result == DialogResult.Yes)
            {
                //exit application and all of the other threads
                System.Windows.Forms.Application.ExitThread();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }
    }
}
