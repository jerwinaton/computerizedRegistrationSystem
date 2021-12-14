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

namespace computerizedRegistrationSystem
{
    public partial class frmAdmission : Form
    {
        private bool TOR = false, diploma = false, picture=false; //declared in the class scope so other methods can use it
        private byte[] diplomaContent,TORContent;
        private frmLanding frmLanding = new frmLanding();
        private string id,last_name; // to be used below in inserting temporary username and password

        public frmAdmission()
        {
            InitializeComponent();
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            //generate barangays automatically for comboboxBrgy
            string[] barangays = new string[906];
            barangays[0] = ""; //set first item to blank
            for (int i = 0; i < 905; i++)
            {
                barangays[i+1] = (i + 1).ToString();
            }
            comboBoxBrgy.DataSource = barangays;

            dateTimePickerBirthDate.Format = DateTimePickerFormat.Custom;
            // Display the date as "12 31 2021".  
            dateTimePickerBirthDate.CustomFormat = "MM dd yyyy";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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
        //back button clicked
        private void iconButton3_Click(object sender, EventArgs e)
        {

            string message = "Are you sure you want to leave this page?";
            string title = "Changes might not be saved";
            SendKeys.Send("{Tab}");
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if (result == DialogResult.No)
            {
                
            }
            else if (result == DialogResult.Yes)
            {
                frmLanding.Show();
                Close();
            }

        }
        //contact # accept only numbers
        private void textBoxStudentContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //zip code accept only numbers
        private void textBoxZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //father's no. accept only numbers
        private void textBoxFatherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //mother's no. accept only numbers
        private void textBoxMotherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        //form closing confirm first thru messagebox
        private void frmAdmission_FormClosing(object sender, FormClosingEventArgs e)
        {
        
            frmLanding.Show();
           
        }
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
            else if (textBoxStudentContactNo.Text == "" || textBoxStudentContactNo.Text=="09***")//check if empty or default
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
        //SUBMIT BUTTON CLICKED
        private void btnSubmit_Click(object sender, EventArgs e)
        {
        
            if (canProceed()) //call the canProceed method which validates the form and returns true or false
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
                        command.CommandText = "INSERT INTO applicantsTable (first_name,middle_name,last_name,gender,birthdate,email,contact_no,house_no,street,district," +
                            "barangay,town,zip_code,mothers_name,mothers_contact_no,mothers_occupation,fathers_name,fathers_contact_no,fathers_occupation,last_school_attended,honors_awards," +
                            "1x1_picture_filename,1x1_picture,diploma_filename,diploma,tor_filename,tor,status,date_applied) " +
                            "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"; //values will be added later, not here!

                        command.Parameters.AddWithValue("first_name",OleDbType.VarChar).Value = textBoxFName.Text.ToUpper();
                        command.Parameters.AddWithValue("middle_name", OleDbType.VarChar).Value = textBoxMName.Text.ToUpper();
                        command.Parameters.AddWithValue("last_name", OleDbType.VarChar).Value = textBoxLName.Text.ToUpper();
                        command.Parameters.AddWithValue("gender", OleDbType.VarChar).Value = comboBoxGender.Text;
                        command.Parameters.AddWithValue("birthdate", OleDbType.Date).Value = dateTimePickerBirthDate.Value.ToShortDateString();
                        command.Parameters.AddWithValue("email", OleDbType.VarChar).Value = textBoxEmail.Text.ToLower();
                        command.Parameters.AddWithValue("contact_no", OleDbType.Integer).Value = textBoxStudentContactNo.Text;
                        command.Parameters.AddWithValue("house_no",OleDbType.VarChar).Value = textBoxHouseNo.Text.ToUpper();
                        command.Parameters.AddWithValue("street", OleDbType.VarChar).Value = textBoxStreet.Text.ToUpper();
                        command.Parameters.AddWithValue("district", OleDbType.VarChar).Value = comboBoxDistrict.Text;
                        command.Parameters.AddWithValue("barangay", OleDbType.VarChar).Value = comboBoxBrgy.Text;
                        command.Parameters.AddWithValue("town", OleDbType.VarChar).Value = comboBoxTown.Text;
                        command.Parameters.AddWithValue("zip_code", OleDbType.VarChar).Value = textBoxZipCode.Text;
                        command.Parameters.AddWithValue("mothers_name", OleDbType.VarChar).Value = textBoxMotherName.Text.ToUpper();
                        command.Parameters.AddWithValue("mothers_contact_no", OleDbType.Integer).Value = textBoxMotherNo.Text;
                        command.Parameters.AddWithValue("mothers_occupation", OleDbType.VarChar).Value = textBoxMotherWork.Text.ToUpper();
                        command.Parameters.AddWithValue("fathers_name", OleDbType.VarChar).Value = textBoxFatherName.Text.ToUpper();
                        command.Parameters.AddWithValue("fathers_contact_no", OleDbType.Integer).Value = textBoxFatherNo.Text;
                        command.Parameters.AddWithValue("fathers_occupation", OleDbType.VarChar).Value = textBoxFatherWork.Text.ToUpper();
                        command.Parameters.AddWithValue("last_school_attended", OleDbType.VarChar).Value = textBoxLastSchool.Text.ToUpper();
                        command.Parameters.AddWithValue("honors_awards", OleDbType.VarChar).Value = textBoxHonors.Text.ToUpper();
                        command.Parameters.AddWithValue("1x1_picture_filename", OleDbType.VarChar).Value = lblUploadImage.Text;
                        //21 commands above

                        //for the image
                        //create a bitmap
                        Bitmap bitmap = new Bitmap(pictureBox1x1Image.BackgroundImage);
                        byte[] pic = imageToBytes(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg); // convert all image to jpeg (small size)
                        command.Parameters.AddWithValue("1x1_picture", OleDbType.Binary).Value = pic; //insert to database as byte

                        command.Parameters.AddWithValue("diploma_filename", OleDbType.VarChar).Value = lblUploadDiploma.Text;
                        command.Parameters.AddWithValue("diploma", OleDbType.Binary).Value = diplomaContent;  //insert to database as byte
                        command.Parameters.AddWithValue("tor_filename", OleDbType.VarChar).Value = lblUploadTOR.Text;
                        command.Parameters.AddWithValue("tor", OleDbType.Binary).Value = TORContent;  //insert to database as byte
                        command.Parameters.AddWithValue("status", OleDbType.VarChar).Value = "PENDING"; //PENDING, ACCEPTED, REJECTED
                        command.Parameters.AddWithValue("date_applied", OleDbType.Date).Value = DateTime.Today;
                        //29 commands/columns
                      
                        int dataInserted = command.ExecuteNonQuery();
                        if (dataInserted > 0)
                        {
                            DialogResult okay = MessageBox.Show("The form was submitted successfully!");
                       
                            if (okay==DialogResult.OK)
                            {
                        
                                //we will create a temporary username and password for the applicant
                                //it must be in this format
                                //username: applicant_[applicant_id] or applicant_2
                                //password: last_name or dela cruz

                                OleDbCommand command2 = new OleDbCommand();//create command
                                OleDbDataReader reader = null;
                                command2.Connection = Program.connection;
                                command2.CommandText= "SELECT applicant_id, last_name FROM applicantsTable where contact_no='" + textBoxStudentContactNo.Text + "' and email='" + textBoxEmail.Text + "' ";
                                reader = command2.ExecuteReader();
                            
                                showTempAccount frmShow = new showTempAccount();
                                Close();
                                while (reader.Read())
                                {
                                    id = reader["applicant_id"].ToString();
                                    last_name = reader["last_name"].ToString(); //to be used in the INSERT statement below
                                }
                                frmShow.usernameText = "applicant_" + id; //set the lblUsername's text of showTempAccount form
                                frmShow.passwordText = last_name.ToLower(); //set the lblPassword's text of showTempAccount form

                                string username_temp = "applicant_" + id; //to be used in the INSERT statement below
                                string password_temp = last_name.ToLower();

                                //new query
                                OleDbCommand command3 = new OleDbCommand();//create command for inserting the temporary account credentials made
                                command3.Connection = Program.connection;
                                command3.CommandText = "UPDATE applicantsTable SET username_temp = '"+ username_temp+"', password_temp='"+ password_temp + "' WHERE applicant_id=" +id;

                                command3.ExecuteNonQuery(); //execute the insert statement
                                frmShow.Show();//show the showTempAccount form
                                
                                Program.connection.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("An error occured the form was not submitted.");
                            Program.connection.Close();
                        }
                    }
                    catch(Exception error)
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
        //method to convert image to byte, so we can save that byte to the database
        private byte[] imageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, format);
                return memoryStream.ToArray();
            }
        }
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            //'SET THIS FOR ONE FILE SELECTION ONLY.
            open.Multiselect = false;
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1x1Image.BackgroundImage = Image.FromFile(open.FileName);
                // image full file path  
                 string filePathImage = open.FileName;
                //get the filename only
                string fileName = Path.GetFileName(filePathImage);
                lblUploadImage.Text = fileName;
                btnUploadImage.Text = "Change Image";
                lblUploadImage.ForeColor = Color.Green; // change color to green if a file has been chosen
                picture = true;// is declared in the class scope so it can be used in btnSubmit_Click method
            }
        }

        private void btnUploadDiploma_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            //'SET THIS FOR ONE FILE SELECTION ONLY.
            open.Multiselect = false;
            // pdf filters  
            open.Filter = "PDF Files(*.pdf)|*.pdf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // pdf full file path  
               string filePathDiploma = open.FileName;
                //get the filename only
                string fileName = Path.GetFileName(filePathDiploma);
                lblUploadDiploma.Text = fileName;
                btnUploadDiploma.Text = "Change File";
                lblUploadDiploma.ForeColor = Color.Green; // change color to green if a file has been chosen
                diploma = true; // is declared in the class scope so it can be used in btnSubmit_Click method

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
            // pdf filters  
            open.Filter = "PDF Files(*.pdf)|*.pdf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // pdf full file path  
               string filePathTOR = open.FileName; 
                //get the filename only
                string fileName = Path.GetFileName(filePathTOR);
                lblUploadTOR.Text = fileName;
                btnUploadTOR.Text = "Change File";
                lblUploadTOR.ForeColor = Color.Green; // change color to green if a file has been chosen
                TOR = true; // is declared in the class scope so it can be used in btnSubmit_Click method

                FileInfo file1 = new FileInfo(filePathTOR);
                TORContent = File.ReadAllBytes(filePathTOR); //read the file and store int byte[]
            }
        }
        //accept only letters
        private void textBoxFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxFatherWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
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
    }
}
