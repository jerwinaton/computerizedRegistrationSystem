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
    public partial class admin_return : Form
    {
        public admin_return()
        {
            InitializeComponent();
        }

        private void admin_return_Load(object sender, EventArgs e)
        {

        }

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
                    command.CommandText = "UPDATE applicantsTable SET status='RETURNED',remarks='" + textBoxRemarks.Text + "' WHERE applicant_id=" + adminUserControls.UCadmissions.selectedApplicantID;
                    int execute = command.ExecuteNonQuery(); //execute

                    if (execute > 0)//success
                    {
                        MessageBox.Show("The form was returned to the user 'applicant_" + adminUserControls.UCadmissions.selectedApplicantID + "' successfully");
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
    }
}
