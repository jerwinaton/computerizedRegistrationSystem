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
    public partial class frmMainAdmin : Form
    {
        public frmMainAdmin()
        {
            InitializeComponent();
        }
        //method to dynamically load user controls pages
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        //close the app but confirm first thru messageBox
        private void frmMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to logout?";
            string title = "Logout";
            SendKeys.Send("{Tab}");//switch focus to No button by default
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if (result == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            btnEditProfile.BackColor = Color.FromArgb(215, 170, 47);
            //btnEditInfo.BackColor = Color.FromArgb(12, 55, 27); // remove active bg color
            //click events on the side nav and then call the method to change the user
            // controls page on the right
            adminUserControls.UCadmissions uc = new adminUserControls.UCadmissions();
            addUserControl(uc);
        }

        private void frmMainAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Close();
           
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            adminUserControls.UCAnnouncements uc = new adminUserControls.UCAnnouncements();
            addUserControl(uc);
        }
    }
}
