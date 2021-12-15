using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration; //so we can use the connection string we set on app.config
namespace computerizedRegistrationSystem.applicantsUserControls
{
    public partial class UCRegistration : UserControl
    {
        private string status;//to be used in all the methods in tihs class

        public UCRegistration()
        {
            InitializeComponent();
        }

        private void UCRegistration_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
              

                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT * FROM applicantsTable WHERE applicant_id=" + frmLogin.id; // where the applicant_id = to the id the user that logged in (in the login.cs)
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read 
                {
                     status = reader["status"].ToString();
                    labelRemarks.Text = reader["remarks"].ToString();
                }
                lblStatus.Text = status;
                //change status color dependes on the status
                if (status == "PENDING")
                {
                    lblStatus.ForeColor = Color.Orange;
                    labelRemarks.ForeColor = Color.Orange;
                }
                else if(status == "ACCEPTED")
                {
                    lblTitle.Text = "Your Application has been accepted";
                    lblStatus.ForeColor = Color.Green;
                    labelRemarks.ForeColor = Color.Green;
                }
                else if(status == "RETURNED")// if returned
                {
                    lblTitle.Text = "Your Application has been returned";
                    lblStatus.ForeColor = Color.Orange;
                    labelRemarks.ForeColor = Color.Orange;
                }
                else if(status == "REJECTED") // if rejected
                {
                    lblTitle.Text = "We're very sorry to inform you that your application has been rejected.";
                    lblStatus.ForeColor = Color.Red;
                    labelRemarks.ForeColor = Color.Red;
                }
                else
                {
                    lblTitle.Text = "We've received your follow up, your application is now being processed.";
                    lblStatus.ForeColor = Color.Orange;
                    labelRemarks.ForeColor = Color.Orange;
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show("An error occurred Please Try again"+Environment.NewLine+error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
           
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
