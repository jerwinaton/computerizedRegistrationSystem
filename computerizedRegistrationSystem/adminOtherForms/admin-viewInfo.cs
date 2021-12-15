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

namespace computerizedRegistrationSystem.adminOtherForms
{
    public partial class admin_viewInfo : Form
    {
        public admin_viewInfo()
        {
            InitializeComponent();
        }

        private void admin_viewInfo_Load(object sender, EventArgs e)
        {
            label1.Text = adminUserControls.UCadmissions.selectedApplicantID;
            //MAIN CODE RETRIEVE DATA FROM DATABASE
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
                 

                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT * FROM applicantsTable WHERE applicant_id=" + adminUserControls.UCadmissions.selectedApplicantID; // where the applicant_id = to the id the selectedApplicant in datagridview in adminUserControls/UCadmissions
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read/get data
                {

                    textBoxFName.Text = reader["first_name"].ToString();
                    textBoxMName.Text = reader["middle_name"].ToString();
                    textBoxLName.Text = reader["last_name"].ToString();
                    comboBoxGender.SelectedItem = reader["gender"].ToString();
                    dateTimePickerBirthDate.Value = Convert.ToDateTime(reader["birthdate"].ToString());
                    textBoxEmail.Text = reader["email"].ToString();
                    textBoxStudentContactNo.Text = reader["contact_no"].ToString();
                    textBoxHouseNo.Text = reader["house_no"].ToString();
                    textBoxStreet.Text = reader["street"].ToString();
                    comboBoxDistrict.SelectedItem = reader["district"].ToString();
                    comboBoxBrgy.SelectedItem = reader["barangay"].ToString();
                    comboBoxTown.SelectedItem = reader["town"].ToString();
                    textBoxZipCode.Text = reader["zip_code"].ToString();
                    textBoxMotherName.Text = reader["mothers_name"].ToString();
                    textBoxMotherNo.Text = reader["mothers_contact_no"].ToString();
                    textBoxMotherWork.Text = reader["mothers_occupation"].ToString();
                    textBoxFatherName.Text = reader["fathers_name"].ToString();
                    textBoxFatherNo.Text = reader["fathers_contact_no"].ToString();
                    textBoxFatherWork.Text = reader["fathers_occupation"].ToString();
                    textBoxLastSchool.Text = reader["last_school_attended"].ToString();
                    textBoxHonors.Text = reader["honors_awards"].ToString();
                  
                   // lblUploadImage.Text = reader["1X1_picture_filename"].ToString();
                   // lblUploadDiploma.Text = reader["diploma_filename"].ToString();
                   // lblUploadTOR.Text = reader["tor_filename"].ToString();
                    pictureBox1x1Image.BackgroundImage = byteArrayToImage((byte[])reader["1x1_picture"]);//converted byte to image

                    comboBoxCollege.SelectedItem = reader["college_applied"].ToString();
                    comboBoxCourse1.SelectedItem = reader["course_choice1"].ToString();
                    comboBoxCourse2.SelectedItem = reader["course_choice2"].ToString();

                    comboBoxTrack.SelectedItem = reader["track"].ToString();
                    comboBoxStrand.SelectedItem = reader["strand"].ToString();
                }

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
    }
}
