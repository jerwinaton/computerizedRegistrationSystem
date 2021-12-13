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
    public partial class showTempAccount : Form
    {
        public showTempAccount()
        {
            InitializeComponent();
        }
        public string usernameText
        {
            get { return this.lblUsername.Text; }
            set  {this.lblUsername.Text = value; }
        }
        public string passwordText
        {
            get{ return this.lblPassword.Text;}
            set {this.lblPassword.Text = value; }

        }
        private void btnUnderstood_Click(object sender, EventArgs e)
        {
            Close(); // close this form
            frmAdmission frmAdmission = new frmAdmission();
            frmAdmission.Hide();
            //back to landing form
            frmLanding frmLanding = new frmLanding();
            frmLanding.Show();
           
        }
    }
}
