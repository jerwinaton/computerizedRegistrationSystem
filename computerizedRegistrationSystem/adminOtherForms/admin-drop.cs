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
    public partial class admin_drop : Form
    {
        public admin_drop()
        {
            InitializeComponent();
        }

        private void admin_drop_Load(object sender, EventArgs e)
        {
            labelStudentID.Text = "student_" + adminUserControls.UCmanage_students.selectedStudentID;
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
                    command.CommandText = "UPDATE studentsTable SET status='DROPPED', remarks='" + textBoxRemarks.Text + "' WHERE student_id=" + adminUserControls.UCmanage_students.selectedStudentID;
                    int execute = command.ExecuteNonQuery(); //execute

                    if (execute > 0)//success
                    {
                        MessageBox.Show("The student has been dropped. The 'student_" + adminUserControls.UCmanage_students.selectedStudentID + "' will be informed.");
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
