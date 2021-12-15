using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace computerizedRegistrationSystem.adminOtherForms
{
    public partial class admin_admit : Form
    {
        public admin_admit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBoxAdmitCollege.Text == "")
            {
                MessageBox.Show("Select a College first.");
            }
            else if (comboBoxAdmitCourse.Text == "")
            {
                MessageBox.Show("Select a Course first.");
            }
            else
            {

            }
        }

        private void admin_admit_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "UPDATE applicantsTable SET status='RETURNED', WHERE applicant_id=" + adminUserControls.UCadmissions.selectedApplicantID;
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
