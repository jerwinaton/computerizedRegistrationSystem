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
using System.IO;

namespace computerizedRegistrationSystem
{
    public partial class frmMainStudent : Form
    {
        public frmMainStudent()
        {
            InitializeComponent();
            //set the home user control as default page
            home uc = new home();
            addUserControl(uc);
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            //get basic info, fullname, id, and image
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {

                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT * FROM studentsTable WHERE student_id=" + frmLogin.id; // where the student_id = to the id the user that logged in (in the login.cs)
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read 
                {
                    lblFullName.Text = reader["first_name"].ToString() + " " + reader["middle_name"].ToString() + " " + reader["last_name"].ToString();
                    lblStudentID.Text = "student_" +reader["student_id"].ToString();
                    pictureBoxUserImage.BackgroundImage = byteArrayToImage((byte[])reader["1x1_picture"]);
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            //get updated announcements
         
        }
        //method to convert byte to image
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image retval = null;
            using (MemoryStream stream = new MemoryStream(byteArrayIn))
            {
                retval = (Image)new Bitmap(stream);
            }
            return retval;
        }
        //logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
           
        }
        //method to dynamically load user controls pages
        private void addUserControl (UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        //click events on the side nav and then call the method to change the user
        // controls page on the right
        private void btnHome_Click(object sender, EventArgs e)
        {
            home uc = new home();
            addUserControl(uc);
        }
        //show schedule page
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            schedule uc = new schedule();
            addUserControl(uc);
        }
        //show grades page
        private void btnGrades_Click(object sender, EventArgs e)
        {
            grades uc = new grades();
            addUserControl(uc);
        }
        //show edit profile page
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            profile uc = new profile();
            addUserControl(uc);
        }
        //show change password page
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            password uc = new password();
            addUserControl(uc);
        }

        //show msgbox on closing the form
        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
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
                frmLogin formLogin = new frmLogin();
                formLogin.Show();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }

       
    }
}
