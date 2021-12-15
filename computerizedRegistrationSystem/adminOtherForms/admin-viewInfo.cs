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

            //generate barangays automatically for comboboxBrgy
            string[] barangays = new string[906];
            barangays[0] = ""; //set first item to blank
            for (int i = 0; i < 905; i++)
            {
                barangays[i + 1] = (i + 1).ToString();
            }
            comboBoxBrgy.DataSource = barangays;

            dateTimePickerBirthDate.Format = DateTimePickerFormat.Custom;
            // Display the date as "12 31 2021".  
            dateTimePickerBirthDate.CustomFormat = "MM dd yyyy";


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
            //for the age
            labelAge.Text = CalculateAge(dateTimePickerBirthDate.Value).ToString() ;

        }
        //calculate age
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
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

        private void comboBoxCourse1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCourse1.SelectedIndex == 0)
            {
                comboBoxCourse2.Items.Clear();
                string[] COURSES = { "Bachelor of Science in Computer Engineering", "Bachelor in Electronics Engineering", "Bachelor in Information Technology with Specialization in Cybersecurity", "Bachelor in Information Technology with Specialization in Data Science" };
                comboBoxCourse2.Items.AddRange(COURSES);
            }
            else if (comboBoxCourse1.SelectedIndex == 1)
            {
                comboBoxCourse2.Items.Clear();
                string[] COURSES = { "Bachelor of Science in Information Technology", "Bachelor in Electronics Engineering", "Bachelor in Information Technology with Specialization in Cybersecurity", "Bachelor in Information Technology with Specialization in Data Science" };
                comboBoxCourse2.Items.AddRange(COURSES);
            }
            else if (comboBoxCourse1.SelectedIndex == 2)
            {
                comboBoxCourse2.Items.Clear();
                string[] COURSES = { "Bachelor of Science in Information Technology", "Bachelor of Science in Computer Engineering", "Bachelor in Information Technology with Specialization in Cybersecurity", "Bachelor in Information Technology with Specialization in Data Science" };
                comboBoxCourse2.Items.AddRange(COURSES);
            }
            else if (comboBoxCourse1.SelectedIndex == 3)
            {
                comboBoxCourse2.Items.Clear();
                string[] COURSES = { "Bachelor of Science in Information Technology", "Bachelor of Science in Computer Engineering", "Bachelor in Electronics Engineering", "Bachelor in Information Technology with Specialization in Data Science" };
                comboBoxCourse2.Items.AddRange(COURSES);
            }
            else if (comboBoxCourse1.SelectedIndex == 4)
            {
                comboBoxCourse2.Items.Clear();
                string[] COURSES = { "Bachelor of Science in Information Technology", "Bachelor of Science in Computer Engineering", "Bachelor in Electronics Engineering", "Bachelor in Information Technology with Specialization in Cybersecurity" };
                comboBoxCourse2.Items.AddRange(COURSES);
            }
        }

        //populate town combobox based on the values selected in the district combobox
        private void comboBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDistrict.Text == "1")
            {
                comboBoxTown.Items.Clear();
                comboBoxTown.Items.Add("TONDO 1 (WEST)");
            }
            else if (comboBoxDistrict.Text == "2")
            {
                comboBoxTown.Items.Clear();
                comboBoxTown.Items.Add("TONDO 2 (EAST)");
            }
            else if (comboBoxDistrict.Text == "3")
            {
                comboBoxTown.Items.Clear();
                string[] CITIES = { "BINONDO", "QUIAPO", "SAN NICOLAS", "SANTA CRUZ" };
                comboBoxTown.Items.AddRange(CITIES);
            }
            else if (comboBoxDistrict.Text == "4")
            {
                comboBoxTown.Items.Clear();
                comboBoxTown.Items.Add("SAMPALOC");
            }
            else if (comboBoxDistrict.Text == "5")
            {
                comboBoxTown.Items.Clear();
                string[] CITIES = { "ERMITA", "INTRAMUROS", "MALATE", "PORT AREA", "SAN ANDRES", "SOUTH PACO" };
                comboBoxTown.Items.AddRange(CITIES);
            }
            else if (comboBoxDistrict.Text == "6")
            {
                comboBoxTown.Items.Clear();
                string[] CITIES = { "NORTH PACO", "PANDACAN", "SAN MIGUEL", "SANTA ANA", "SANTA MESA" };
                comboBoxTown.Items.AddRange(CITIES);
            }
        }
        //POPULATE STRAND COMBOBOX BASED ON THE VALUE OF TRACK COMBOBOX
        private void comboBoxTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTrack.SelectedIndex == 0)
            {
                comboBoxStrand.Items.Clear();
                string[] STRANDS = { "General Academic (GA)", "Humanities and Social Sciences (HUMMS)", "Science, Technology, Engineering and Mathematics (STEM)", "Accountancy, Business and Management (ABM)" };
                comboBoxStrand.Items.AddRange(STRANDS);
            }
            else if (comboBoxTrack.SelectedIndex == 1)
            {
                comboBoxStrand.Items.Clear();
                string[] STRANDS = { "Agri-Fishery Arts", "Home Economics", "Industrial Arts", "Information and Communications Technology (ICT)" };
                comboBoxStrand.Items.AddRange(STRANDS);
            }
            else if (comboBoxTrack.SelectedIndex == 2)
            {
                comboBoxStrand.Items.Clear();
                comboBoxStrand.Items.Add("NONE");
            }
            else if (comboBoxTrack.SelectedIndex == 3)
            {
                comboBoxStrand.Items.Clear();
                comboBoxStrand.Items.Add("NONE");
            }
        }
    }
}
