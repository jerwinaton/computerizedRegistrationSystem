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

namespace computerizedRegistrationSystem
{
    public partial class frmAdmission : Form
    {
        private string filePathImage; //declared in the class scope so other methods can use it
        private string filePathDiploma; //declared in the class scope so other methods can use it
        private string filePathTOR; //declared in the class scope so other methods can use it

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
                Hide();
                frmLanding formLanding = new frmLanding();
                formLanding.Show();
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
            string message = "Are you sure you want to exit the application?";
            string title = "Exit the program";
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
                Application.ExitThread();
            }
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
                string msgbx_message = "Enter your father's contact #.";
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
            else if (filePathImage == "")//check if empty
            {
                string msgbx_message = "Please upload your 1by1 picture.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                return false;
            }
            else if (filePathDiploma == "")//check if empty
            {
                string msgbx_message = "Please upload a PDF copy of your diploma.";
                string msgbx_title = "Submit Failed";
                MessageBox.Show(msgbx_message, msgbx_title);
                return false;
            }
            else if (filePathTOR == "")//check if empty
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
                /*
                textBoxFName
                textBoxMName
                textBoxLName
                comboBoxGender
                dateTimePickerBirthDate
                textBoxEmail
                textBoxStudentContactNo
                comboBoxDistrict
                comboBoxCity
                textBoxHouseNo
                textBoxStreet
                comboBoxBrgy
                textBoxZipCode
                textBoxFatherName
                textBoxFatherWork
                textBoxFatherNo
                textBoxMotherName
                textBoxMotherWork
                textBoxMotherNo
                textBoxLastSchool
                textBoxHonors
                pictureBox1x1Image 
                filePathImage
                filePathDiploma
                username_temp
                password_temp*/

                comboBox1.Items.Add(textBoxFName.Text.ToUpper());
                comboBox1.Items.Add(textBoxMName.Text.ToUpper());
                comboBox1.Items.Add(textBoxLName.Text.ToUpper());
                comboBox1.Items.Add(comboBoxGender.Text);
                comboBox1.Items.Add(dateTimePickerBirthDate.Value.ToString("MM-dd-yyyy"));
                comboBox1.Items.Add(textBoxEmail.Text.ToLower());
                comboBox1.Items.Add(textBoxStudentContactNo.Text);
                comboBox1.Items.Add(comboBoxDistrict.Text);
                comboBox1.Items.Add(comboBoxTown.Text);
                comboBox1.Items.Add(textBoxHouseNo.Text.ToUpper());
                comboBox1.Items.Add(textBoxStreet.Text.ToUpper());
                comboBox1.Items.Add(textBoxZipCode.Text);
                comboBox1.Items.Add(textBoxFatherName.Text.ToUpper());
                comboBox1.Items.Add(textBoxFatherWork.Text.ToUpper());
                comboBox1.Items.Add(textBoxFatherNo.Text);
                comboBox1.Items.Add(textBoxMotherName.Text.ToUpper());
                comboBox1.Items.Add(textBoxMotherWork.Text.ToUpper());
                comboBox1.Items.Add(textBoxMotherNo.Text);
                comboBox1.Items.Add(textBoxLastSchool.Text.ToUpper());
                comboBox1.Items.Add(filePathImage);
                comboBox1.Items.Add(filePathDiploma);
                comboBox1.Items.Add(filePathTOR);

                }
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1x1Image.BackgroundImage = Image.FromFile(open.FileName);
                // image full file path  
                 filePathImage = open.FileName;//filePathImage is declared in the class scope so it can be used in btnSubmit_Click method
                //get the filename only
                string fileName = System.IO.Path.GetFileName(filePathImage);
                lblUploadImage.Text = fileName;
                btnUploadImage.Text = "Change Image";
            }
        }

        private void btnUploadDiploma_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // pdf filters  
            open.Filter = "PDF Files(*.pdf)|*.pdf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // pdf full file path  
                filePathDiploma = open.FileName; //filePathDiploma is declared in the class scope so it can be used in btnSubmit_Click method
                //get the filename only
                string fileName = System.IO.Path.GetFileName(filePathDiploma);
                lblUploadDiploma.Text = fileName;
                btnUploadDiploma.Text = "Change File";
            }
        }

        private void btnUploadTOR_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // pdf filters  
            open.Filter = "PDF Files(*.pdf)|*.pdf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // pdf full file path  
                filePathTOR = open.FileName; //filePathTOR is declared in the class scope so it can be used in btnSubmit_Click method
                //get the filename only
                string fileName = System.IO.Path.GetFileName(filePathDiploma);
                labelUploadTOR.Text = fileName;
                btnUploadTOR.Text = "Change File";
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
