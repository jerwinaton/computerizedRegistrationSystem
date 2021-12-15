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
    public partial class frmApplicant : Form
    {
        private string fullName, id;

        public frmApplicant()
        {
            InitializeComponent();
            applicantsUserControls.UCRegistration uc = new applicantsUserControls.UCRegistration();
            addUserControl(uc);
            btnRegistration.BackColor = Color.FromArgb(215, 170, 47);
            //set as default page
        }

        private void main_applicant_Load(object sender, EventArgs e)
        {
            //get basic info, fullname, id, and image
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
                    fullName = reader["first_name"].ToString()+" "+ reader["middle_name"].ToString()+" "+ reader["last_name"].ToString();
                    id = reader["applicant_id"].ToString();
                    pictureBoxUserImage.BackgroundImage = byteArrayToImage((byte [])reader["1x1_picture"]);
                }
                
                lblUsername.Text = "applicant_"+id; //set name
                lblName.Text = fullName; //set id
                //pictureBoxUserImage
            }
            catch
            {

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
        //method to dynamically load user controls pages
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            btnRegistration.BackColor = Color.FromArgb(215, 170, 47);
            btnEditInfo.BackColor = Color.FromArgb(12, 55, 27); // remove active bg color
            //click events on the side nav and then call the method to change the user
            // controls page on the right
            applicantsUserControls.UCRegistration uc = new applicantsUserControls.UCRegistration();
              addUserControl(uc);
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            btnEditInfo.BackColor = Color.FromArgb(215, 170, 47); // add active bg color
            btnRegistration.BackColor = Color.FromArgb(12, 55, 27); // remove active bg color
            
            applicantsUserControls.UCMyInfo uc = new applicantsUserControls.UCMyInfo();
            addUserControl(uc);
        }

        private void frmApplicant_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to exit this page?";
            string title = "Close this page";
            SendKeys.Send("{Tab}");
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
             
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
           
        }
    }
}
