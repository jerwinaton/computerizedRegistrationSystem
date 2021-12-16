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
    public partial class frmMainAdmin : Form
    {
        public frmMainAdmin()
        {
            InitializeComponent();
            adminUserControls.UChome uc = new adminUserControls.UChome();
            addUserControl(uc);
            btnHome.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnAdmission.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnAccounts.BackColor = Color.FromArgb(12, 55, 27);
            btnStudents.BackColor = Color.FromArgb(12, 55, 27);
            btnSections.BackColor = Color.FromArgb(12, 55, 27);
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnSchedules.BackColor = Color.FromArgb(12, 55, 27);
        }
        //method to dynamically load user controls pages
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        //close the app but confirm first thru messageBox
        private void frmMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to logout?";
            string title = "Logout";
            SendKeys.Send("{Tab}");//switch focus to No button by default
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if (result == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        private void frmMainAdmin_Load(object sender, EventArgs e)
        {
            //get basic info, fullname, id, and image
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {

                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT * FROM adminTable WHERE admin_id=" + frmLogin.id; // where the student_id = to the id the user that logged in (in the login.cs)
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read 
                {
                    lblFullName.Text = reader["first_name"].ToString() + " " + reader["last_name"].ToString();
                    lblAdminID.Text = "admin_" + reader["admin_id"].ToString();
                 
                }

            }
            catch(Exception error)
            {
                MessageBox.Show("Error " + error);
            }
            finally
            {
                connection.Close();
            }
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
        private void button2_Click(object sender, EventArgs e)
        {
            string title = "Logout";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Are you sure ypu want to log out?", title,buttons);
            if (result == DialogResult.Yes)
            {
                Close();
            }
           
        }

     

        private void btnHome_Click(object sender, EventArgs e)
        {
            adminUserControls.UChome uc = new adminUserControls.UChome();
            addUserControl(uc);

            btnHome.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnAdmission.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnAccounts.BackColor = Color.FromArgb(12, 55, 27);
            btnStudents.BackColor = Color.FromArgb(12, 55, 27);
            btnSections.BackColor = Color.FromArgb(12, 55, 27);
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnSchedules.BackColor = Color.FromArgb(12, 55, 27);
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            adminUserControls.UCaccounts uc = new adminUserControls.UCaccounts();
            addUserControl(uc);

            btnAccounts.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnAdmission.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnHome.BackColor = Color.FromArgb(12, 55, 27);
            btnStudents.BackColor = Color.FromArgb(12, 55, 27);
            btnSections.BackColor = Color.FromArgb(12, 55, 27);
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnSchedules.BackColor = Color.FromArgb(12, 55, 27);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            adminUserControls.UCmanage_students uc = new adminUserControls.UCmanage_students();
            addUserControl(uc);

            btnStudents.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnAdmission.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnHome.BackColor = Color.FromArgb(12, 55, 27);
            btnAccounts.BackColor = Color.FromArgb(12, 55, 27);
            btnSections.BackColor = Color.FromArgb(12, 55, 27);
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnSchedules.BackColor = Color.FromArgb(12, 55, 27);
        }

        private void btnAdmission_Click(object sender, EventArgs e)
        {
            btnAdmission.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnHome.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnAccounts.BackColor = Color.FromArgb(12, 55, 27);
            btnStudents.BackColor = Color.FromArgb(12, 55, 27);
            btnSections.BackColor = Color.FromArgb(12, 55, 27);
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnSchedules.BackColor = Color.FromArgb(12, 55, 27);
            //click events on the side nav and then call the method to change the user
            // controls page on the right
            adminUserControls.UCadmissions uc = new adminUserControls.UCadmissions();
            addUserControl(uc);
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            adminUserControls.UCsections uc = new adminUserControls.UCsections();
            addUserControl(uc);

            btnSections.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnHome.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnAccounts.BackColor = Color.FromArgb(12, 55, 27);
            btnStudents.BackColor = Color.FromArgb(12, 55, 27);
            btnAdmission.BackColor = Color.FromArgb(12, 55, 27);
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnSchedules.BackColor = Color.FromArgb(12, 55, 27);
          
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            btnSchedules.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnHome.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnAccounts.BackColor = Color.FromArgb(12, 55, 27);
            btnStudents.BackColor = Color.FromArgb(12, 55, 27);
            btnAdmission.BackColor = Color.FromArgb(12, 55, 27);
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnSections.BackColor = Color.FromArgb(12, 55, 27);
            //click events on the side nav and then call the method to change the user
            // controls page on the right
            adminUserControls.UCschedule uc = new adminUserControls.UCschedule();
            addUserControl(uc);
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            adminUserControls.UCAnnouncements uc = new adminUserControls.UCAnnouncements();
            addUserControl(uc);

            btnAnnouncements.BackColor = Color.FromArgb(215, 170, 47);//add active color
            btnHome.BackColor = Color.FromArgb(12, 55, 27);// remove active bg color
            btnAnnouncements.BackColor = Color.FromArgb(12, 55, 27);
            btnAccounts.BackColor = Color.FromArgb(12, 55, 27);
            btnStudents.BackColor = Color.FromArgb(12, 55, 27);
            btnAdmission.BackColor = Color.FromArgb(12, 55, 27);
            btnSections.BackColor = Color.FromArgb(12, 55, 27);
            btnSchedules.BackColor = Color.FromArgb(12, 55, 27);
        }
    }
}
