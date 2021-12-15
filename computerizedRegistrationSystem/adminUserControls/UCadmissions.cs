using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace computerizedRegistrationSystem.adminUserControls
{
    public partial class UCadmissions : UserControl
    {
        public static string selectedApplicantID=""; 
        public UCadmissions()
        {
            InitializeComponent();
        }

        //get id of selected cell
        private void dataGridViewApplications_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridViewApplications.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                selectedApplicantID = row.Cells[2].Value.ToString(); //applicant id column
               
            }
        }

        private void UCadmissions_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT status,remarks,applicant_id,email,first_name,middle_name,last_name,gender,contact_no,town,college_applied,course_choice1,course_choice2,date_applied FROM applicantsTable";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command); // will help to fill the data
                DataTable dt = new DataTable(); //fill this with the values from adapter
                adapter.Fill(dt);
                dataGridViewApplications.DataSource = dt;

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
        //view info button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedApplicantID == "")
            {
                string title = "View applicant's information";
                MessageBox.Show("Choose an applicant first. (Reload the table)",title);
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_viewInfo>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_viewInfo>().First().Close();

                adminOtherForms.admin_viewInfo viewInfo = new adminOtherForms.admin_viewInfo();
                viewInfo.Show();
            }
            
   
        }
        //view TOR
        private void button6_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedApplicantID == "")
            {
                string title = "View Transcript of Records";
                MessageBox.Show("Choose an applicant first. (Reload the table)",title);
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_viewTOR>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_viewTOR>().First().Close();

                adminOtherForms.admin_viewTOR viewTOR = new adminOtherForms.admin_viewTOR();
                viewTOR.Show();
            }
            
        }
        //view Diploma
        private void button5_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedApplicantID=="")
            {
                string title = "View Diploma";
                MessageBox.Show("Choose an applicant first. (Reload the table)",title);
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_viewDiploma>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_viewDiploma>().First().Close();

                adminOtherForms.admin_viewDiploma viewDiploma = new adminOtherForms.admin_viewDiploma();
                viewDiploma.Show();
            }
        }
        //return the form
        private void button2_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedApplicantID == "")
            {
                string title = "Return the form";
                MessageBox.Show("Choose an applicant first. (Reload the table)",title);
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_return>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_return>().First().Close();

                adminOtherForms.admin_return adminReturn = new adminOtherForms.admin_return();
                adminReturn.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedApplicantID == "")
            {
                MessageBox.Show("Choose an applicant first. (Reload the table)");
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_return>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_return>().First().Close();

                adminOtherForms.admin_return adminReturn = new adminOtherForms.admin_return();
                adminReturn.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedApplicantID == "")
            {
                MessageBox.Show("Choose an applicant first. (Reload the table)");
            }
            else
            {
                string message = "Are you sure you want admit applicant_"+ selectedApplicantID+"?";
                string title = "Admit the applicant";
                SendKeys.Send("{Tab}");
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons);
                //if No is selected cancel form closing event
                if (result == DialogResult.Yes)
                {
                    
                }
               
            }
        }
    }
}
