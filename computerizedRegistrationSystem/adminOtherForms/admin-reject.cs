using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace computerizedRegistrationSystem.adminOtherForms
{
    public partial class adminReject : Form
    {
        public adminReject()
        {
            InitializeComponent();
        }
        //click reject button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxRemarks.Text == "")
            {
                MessageBox.Show("Enter your remarks/comments.");
                textBoxRemarks.Select();//focus on the text box
            }
            else
            {
                OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                connection.Open();
                try
                {
                    OleDbCommand command = new OleDbCommand();//create command
                    command.Connection = connection;//give command the connection string
                    command.CommandText = "UPDATE applicantsTable SET status='REJECTED',remarks='" + textBoxRemarks.Text + "' WHERE applicant_id=" + adminUserControls.UCadmissions.selectedApplicantID;
                    int execute = command.ExecuteNonQuery(); //execute

                    if (execute > 0)//success
                    {
                        MessageBox.Show("The application ha been rejected. The 'applicant_" + adminUserControls.UCadmissions.selectedApplicantID + "' will be informed.");
                        Close();
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show("An error occured " + error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void adminReject_Load(object sender, EventArgs e)
        {
            labelApplicantID.Text="applicant_"+adminUserControls.UCadmissions.selectedApplicantID;
        }
    }
}
