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

        //close the app but confirm first thru messageBox
        private void frmMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
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
