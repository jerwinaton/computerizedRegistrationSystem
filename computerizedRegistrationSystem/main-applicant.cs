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
    public partial class frmApplicant : Form
    {
        public frmApplicant()
        {
            InitializeComponent();
            applicantsUserControls.UCRegistration uc = new applicantsUserControls.UCRegistration();
            addUserControl(uc);
            //set as default page
        }

        private void main_applicant_Load(object sender, EventArgs e)
        {

        }
        //method to dynamically load user controls pages
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            //click events on the side nav and then call the method to change the user
            // controls page on the right
            applicantsUserControls.UCRegistration uc = new applicantsUserControls.UCRegistration();
              addUserControl(uc);
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            applicantsUserControls.UCMyInfo uc = new applicantsUserControls.UCMyInfo();
            addUserControl(uc);
        }

        private void frmApplicant_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to exit this page?";
            string title = "Close this page";
            SendKeys.Send("{Tab}");
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
             
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}
