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
using System.Configuration;

namespace computerizedRegistrationSystem.studentsUserControls
{
    public partial class registration : UserControl
    {
        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {

            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            //open connection
            try
            {

                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT * FROM studentsTable WHERE student_id="+ frmLogin.id;
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read 
                {
                    
                    lblCollege.Text = reader["college"].ToString();
                    lblCourse.Text = reader["course"].ToString();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
