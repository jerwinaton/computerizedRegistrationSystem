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
using System.IO;

namespace computerizedRegistrationSystem.applicantsUserControls
{
    public partial class UCMyInfo : UserControl
    {
        private bool TOR = false, diploma = false, picture = false; //declared in the class scope so other methods can use it
       // private byte[] diplomaContent, TORContent;
        public UCMyInfo()
        {
            InitializeComponent();
        }

        private void textBoxFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }

        private void UCMyInfo_Load(object sender, EventArgs e)
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
                command.CommandText = "SELECT * FROM applicantsTable WHERE applicant_id=" + frmLogin.id; // where the applicant_id = to the id the user that logged in (in the login.cs)
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
                    pictureBox1x1Image.BackgroundImage = byteArrayToImage((byte[])reader["1x1_picture"]);//converted byte to image
                    lblUploadImage.Text = reader["1X1_picture_filename"].ToString();
                    lblUploadDiploma.Text = reader["diploma_filename"].ToString();
                    lblUploadTOR.Text = reader["tor_filename"].ToString();
                    pictureBox1.BackgroundImage = byteArrayToImage((byte[])reader["1x1_picture"]);//converted byte to image

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
            labelAge.Text = CalculateAge(dateTimePickerBirthDate.Value).ToString();
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
        //accept only numbers
        private void textBoxStudentContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxFatherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxMotherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //end of accept only numbers

        // accept only letters
        private void textBoxFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void textBoxMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void textBoxLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void textBoxFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void textBoxFatherWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void btnUploadDiploma_Click(object sender, EventArgs e)
        {

        }

        private void lblUploadDiploma_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadTOR_Click(object sender, EventArgs e)
        {

        }

        private void lblUploadTOR_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {

        }

        private void lblUploadImage_Click(object sender, EventArgs e)
        {

        }

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

        private void comboBoxCollege_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void textBoxMotherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void textBoxMotherWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }
        //end of accept only letters

        //validate the form
        private bool canProceed()
        {
            //SIMPLE VALIDATION

            if (textBoxFName.Text == "")//check if empty
            {
                string msgbx_message = "Enter your first name.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxFName.Select(); //focus on first name textbox
                return false;
            }
            else if (textBoxMName.Text == "")//check if empty
            {
                string msgbx_message = "Enter your middle name.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxMName.Select();
                return false;
            }
            else if (textBoxLName.Text == "")//check if empty
            {
                string msgbx_message = "Enter your last name.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxLName.Select();
                return false;
            }
            else if (comboBoxGender.Text == "")//check if empty
            {
                string msgbx_message = "Choose your gender.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);

                return false;
            }
            else if (textBoxEmail.Text == "")//check if empty
            {
                string msgbx_message = "Enter your email.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxEmail.Select();
                return false;
            }
            else if (comboBoxDistrict.Text == "")//check if empty
            {
                string msgbx_message = "Choose your District.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);

                return false;
            }
            else if (comboBoxTown.Text == "")//check if empty
            {
                string msgbx_message = "Choose your Town.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);

                return false;
            }
            else if (comboBoxBrgy.Text == "")//check if empty
            {
                string msgbx_message = "Choose your Barangay.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);

                return false;
            }
            else if (textBoxStudentContactNo.Text == "" || textBoxStudentContactNo.Text == "09***")//check if empty or default
            {
                string msgbx_message = "Enter your contact number.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxStudentContactNo.Select();
                return false;
            }
            else if (textBoxHouseNo.Text == "")//check if empty
            {
                string msgbx_message = "Enter your house #.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxHouseNo.Select();
                return false;
            }
            else if (textBoxStreet.Text == "")//check if empty
            {
                string msgbx_message = "Enter your address's street.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxStreet.Select();
                return false;
            }
            else if (textBoxZipCode.Text == "")//check if empty
            {
                string msgbx_message = "Enter your address's zipcode.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxZipCode.Select();
                return false;
            }
            else if (textBoxFatherName.Text == "")//check if empty
            {
                string msgbx_message = "Enter your father's name.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxFatherName.Select();
                return false;
            }
            else if (textBoxFatherWork.Text == "")//check if empty
            {
                string msgbx_message = "Enter your father's work. Type N/A if none.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxFatherWork.Select();
                return false;
            }
            else if (textBoxFatherNo.Text == "")//check if empty
            {
                string msgbx_message = "Enter your father's contact #.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxFatherNo.Select();
                return false;
            }
            else if (textBoxMotherName.Text == "")//check if empty
            {
                string msgbx_message = "Enter your mother's name.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxMotherName.Select();
                return false;
            }
            else if (textBoxMotherWork.Text == "")//check if empty
            {
                string msgbx_message = "Enter your mother's work. Type N/A if none.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxMotherWork.Select();
                return false;
            }
            else if (textBoxMotherNo.Text == "")//check if empty
            {
                string msgbx_message = "Enter your mother's contact #.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxMotherNo.Select();
                return false;
            }
            else if (textBoxLastSchool.Text == "")//check if empty
            {
                string msgbx_message = "Enter the school you graduated.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                textBoxLastSchool.Select();
                return false;
            }
            else if (picture == false)//check if empty
            {
                string msgbx_message = "Please upload your 1by1 picture.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                return false;
            }
            else if (diploma == false)//check if empty
            {
                string msgbx_message = "Please upload a PDF copy of your diploma.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                return false;
            }
            else if (TOR == false)//check if empty
            {
                string msgbx_message = "Please upload a PDF copy of your Transcript of Records.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
