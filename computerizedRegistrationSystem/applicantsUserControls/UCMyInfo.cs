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
        private byte[] diplomaContent, TORContent, imageContent;
       public string status, remarks;

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
                    pictureBox1x1Image.BackgroundImage = byteArrayToImage((byte[])reader["1x1_picture"]);//converted byte to image

                    lblUploadTOR.Text = reader["tor_filename"].ToString();

                    pictureBox2.BackgroundImage = byteArrayToImage((byte[])reader["diploma"]);//converted byte to image

                    pictureBox3.BackgroundImage = byteArrayToImage((byte[])reader["tor"]);//converted byte to image

                    comboBoxCollege.SelectedItem = reader["college_applied"].ToString();
                    comboBoxCourse1.SelectedItem = reader["course_choice1"].ToString();
                    comboBoxCourse2.SelectedItem = reader["course_choice2"].ToString();

                    comboBoxTrack.SelectedItem = reader["track"].ToString();
                    comboBoxStrand.SelectedItem = reader["strand"].ToString();

                    status = reader["status"].ToString(); //get status for later programs
                    remarks = reader["remarks"].ToString(); ////get remarks for later programs
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

            if (status == "RETURNED")
            {
                textBoxFName.Enabled = true;
                textBoxMName.Enabled = true;
                textBoxLName.Enabled = true;
                comboBoxGender.Enabled = true;
                dateTimePickerBirthDate.Enabled = true;
                textBoxEmail.Enabled = true;
                textBoxStudentContactNo.Enabled = true;
                textBoxHouseNo.Enabled = true;
                textBoxStreet.Enabled = true;

                comboBoxDistrict.Enabled = true;
                comboBoxBrgy.Enabled = true;
                comboBoxTown.Enabled = true;
                textBoxZipCode.Enabled = true;
                textBoxMotherName.Enabled = true;
                textBoxMotherNo.Enabled = true;
                textBoxMotherWork.Enabled = true;
                textBoxFatherName.Enabled = true;
                textBoxFatherNo.Enabled = true;

                textBoxFatherWork.Enabled = true;
                textBoxLastSchool.Enabled = true;
                textBoxHonors.Enabled = true;
                comboBoxCollege.Enabled = true;
                comboBoxCourse1.Enabled = true;
                comboBoxCourse2.Enabled = true;

                comboBoxTrack.Enabled = true;
                comboBoxStrand.Enabled = true;

                btnUploadImage.Enabled = true;
                btnUploadDiploma.Enabled = true;
                btnUploadTOR.Enabled = true;

                btnSubmit.Enabled = true;
            }



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
       
        private void btnUploadDiploma_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            //'SET THIS FOR ONE FILE SELECTION ONLY.
            open.Multiselect = false;
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // image full file path  
                string filePathDiploma = open.FileName;
                //get the filename only
                string fileName = Path.GetFileName(filePathDiploma);
                lblUploadDiploma.Text = fileName;
                btnUploadDiploma.Text = "Change File";
                lblUploadDiploma.ForeColor = Color.Green; // change color to green if a file has been chosen

                FileInfo file1 = new FileInfo(filePathDiploma);
                diplomaContent = File.ReadAllBytes(filePathDiploma); //read the file and store int byte[]
            }
        
        }

     
        private void btnUploadTOR_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            //'SET THIS FOR ONE FILE SELECTION ONLY.
            open.Multiselect = false;
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // image full file path  
                string filePathTOR = open.FileName;
                //get the filename only
                string fileName = Path.GetFileName(filePathTOR);
                lblUploadTOR.Text = fileName;
                btnUploadTOR.Text = "Change File";
                lblUploadTOR.ForeColor = Color.Green; // change color to green if a file has been chosen

                FileInfo file1 = new FileInfo(filePathTOR);
                TORContent = File.ReadAllBytes(filePathTOR); //read the file and store int byte[]
            }
        }


        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            //'SET THIS FOR ONE FILE SELECTION ONLY.
            open.Multiselect = false;
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {  
                // display image in picture box  
                pictureBox1.BackgroundImage = Image.FromFile(open.FileName);
                // image full file path  
                string filePathImage = open.FileName;
                //get the filename only
                string fileName = Path.GetFileName(filePathImage);
                lblUploadImage.Text = fileName;
                btnUploadImage.Text = "Change File";
                lblUploadImage.ForeColor = Color.Green; // change color to green if a file has been chosen
                            
               
                FileInfo file1 = new FileInfo(filePathImage);
                imageContent = File.ReadAllBytes(filePathImage); //read the file and store int byte[]
            }
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
        //method to convert image to byte, so we can save that byte to the database
        private byte[] imageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, format);
                return memoryStream.ToArray();
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (canProceed())//call the canProceed method which validates the form and returns true or false
            {
                string message = "Before submitting, have you reviewed your information?";
                string title = "Submit the Form?";
                SendKeys.Send("{Tab}");
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;


                DialogResult result = MessageBox.Show(message, title, buttons);
                //if No stop submitting
                if (result == DialogResult.No)
                {

                }
                //if yes submit the form
                else if (result == DialogResult.Yes)
                {
                   try
                    {
                        

                        Program.connection.Open(); //open connection to database

                        OleDbCommand command = new OleDbCommand();//create command
                        command.Connection = Program.connection;//give command the connection string
                        command.CommandText = "UPDATE applicantsTable SET first_name='" + textBoxFName.Text.ToUpper() + "',middle_name='" + textBoxMName.Text.ToUpper() + "'," +
                            "last_name='" + textBoxLName.Text.ToUpper() + "',gender='" + comboBoxGender.Text + "',birthdate='" + dateTimePickerBirthDate.Value.ToShortDateString() + "'," +
                            "email='" + textBoxEmail.Text.ToLower() + "',contact_no='" + textBoxStudentContactNo.Text + "',house_no='" + textBoxHouseNo.Text.ToUpper() + "'," +
                            "street='" + textBoxStreet.Text.ToUpper() + "',district='" + comboBoxDistrict.Text + "'," +
                                         "barangay='" + comboBoxBrgy.Text + "',town='" + comboBoxTown.Text + "',zip_code='" + textBoxZipCode.Text + "'," +
                                         "mothers_name='" + textBoxMotherName.Text.ToUpper() + "',mothers_contact_no='" + textBoxMotherNo.Text + "'," +
                                         "mothers_occupation='" + textBoxMotherWork.Text.ToUpper() + "',fathers_name='" + textBoxFatherName.Text.ToUpper() + "'," +
                                         "fathers_contact_no='" + textBoxFatherNo.Text + "',fathers_occupation='" + textBoxFatherWork.Text.ToUpper() + "'," +
                                         "last_school_attended='" + textBoxLastSchool.Text.ToUpper() + "',honors_awards='" + textBoxHonors.Text.ToUpper() + "'," +
                                         "1x1_picture_filename='" + lblUploadImage.Text + "',1x1_picture=@imageContent, diploma_filename='" + lblUploadDiploma.Text + "'," +
                                         "diploma= @diplomaContent, tor_filename='"+ lblUploadTOR.Text+"',tor=@TORContent," +
                                         "status='FOLLOW UP',track='"+comboBoxTrack.Text+"',strand='"+ comboBoxStrand.Text+"',college_applied='"+ comboBoxCollege.Text+"'," +
                                         "course_choice1='"+ comboBoxCourse1.Text+"',course_choice2='"+ comboBoxCourse2.Text+"' WHERE applicant_id=" + frmLogin.id; // where the applicant_id = to the id the user that logged in (in the login.cs);


                        //if the images have not been updated then the current images will be sent to this query
                        //create a bitmap to set the image back to the default image
                        Bitmap bitmap1 = new Bitmap(pictureBox1.BackgroundImage);
                        byte[] imageContent = imageToBytes(bitmap1, System.Drawing.Imaging.ImageFormat.Jpeg); // convert all image to jpeg (small size)
                        command.Parameters.AddWithValue("1x1_picture", OleDbType.Binary).Value = imageContent; //insert to database as byte

                        Bitmap bitmap2 = new Bitmap(pictureBox2.BackgroundImage); //hiddenpicturebox
                        byte[] diplomaContent = imageToBytes(bitmap2, System.Drawing.Imaging.ImageFormat.Jpeg); // convert all image to jpeg (small size)
                        command.Parameters.AddWithValue("1x1_picture", OleDbType.Binary).Value = diplomaContent; //insert to database as byte

                        Bitmap bitmap3 = new Bitmap(pictureBox3.BackgroundImage); //hidden picturebox
                        byte[] TORContent = imageToBytes(bitmap3, System.Drawing.Imaging.ImageFormat.Jpeg); // convert all image to jpeg (small size)
                        command.Parameters.AddWithValue("1x1_picture", OleDbType.Binary).Value = TORContent; //insert to database as byte

                        command.Parameters.AddWithValue("diplomaContent", OleDbType.Binary).Value = diplomaContent;
                        command.Parameters.AddWithValue("imageContent", OleDbType.Binary).Value = imageContent;
                        command.Parameters.AddWithValue("TORContent", OleDbType.Binary).Value = TORContent;


                        //STATUS = PENDING, ACCEPTED, RETURNED, FOLLOW UP, REJECTED
                        command.ExecuteNonQuery();
                        MessageBox.Show("Your form has been updated successfully." + Environment.NewLine + "Please wait for the admin to review your application.");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error " + error);
                    }
                    finally
                    {
                        Program.connection.Close();
                    }
                }
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

        private void textBoxMotherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxMotherWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

      
        //end of accept letters only

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
          
            else
            {
                return true;
            }
        }
    }
}
