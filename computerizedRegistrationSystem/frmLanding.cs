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
    public partial class frmLanding : Form
    {
  
        public frmLanding()
        {
            InitializeComponent();
        }

        private void labelPortal_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            frmLogin formLogin = new frmLogin();
            formLogin.Show();
        }

        private void frmLanding_Load(object sender, EventArgs e)
        {

        }
        //admission button clicked
        private void button2_Click(object sender, EventArgs e)
        {
            Hide(); //hide this form
            frmAdmission formAdmission = new frmAdmission();
            //open admission form
            formAdmission.Show();
        }

        //form closing confirm first thru messagebox
        private void frmLanding_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to exit the application?";
            string title = "Exit the program";
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
                Application.ExitThread();
            }

        }
    }
}
