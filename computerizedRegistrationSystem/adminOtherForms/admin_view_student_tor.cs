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
using System.IO;
using System.Configuration;

namespace computerizedRegistrationSystem.adminOtherForms
{
    public partial class admin_view_student_tor : Form
    {
        public admin_view_student_tor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin_view_student_tor_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();

            try
            {
                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT tor_filename, tor FROM studentsTable WHERE student_id=" + adminUserControls.UCmanage_students.selectedStudentID; 
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read/get data
                {
                    label1.Text = reader["tor_filename"].ToString();
                    pictureBox1.BackgroundImage = byteArrayToImage((byte[])reader["tor"]);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error);
            }
            finally
            {
                connection.Close();
            }

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image retval = null;
            using (MemoryStream stream = new MemoryStream(byteArrayIn))
            {
                retval = (Image)new Bitmap(stream);
            }
            return retval;
        }
    }
}
