using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computerizedRegistrationSystem
{
    public partial class frmAdmission : Form
    {
        public frmAdmission()
        {
            InitializeComponent();
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            //generate barangays automatically for comboboxBrgy
            string[] barangays = new string[905];
            for (int i = 0; i < 905; i++)
            {
                barangays[i] = (i + 1).ToString();
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
                comboBoxCity.Items.Clear();
                comboBoxCity.Items.Add("TONDO 1 (WEST)");
            }
            else if (comboBoxDistrict.Text == "2")
            {
                comboBoxCity.Items.Clear();
                comboBoxCity.Items.Add("TONDO 2 (EAST)");
            }
            else if (comboBoxDistrict.Text == "3")
            {
                comboBoxCity.Items.Clear();
                string[] CITIES = { "BINONDO", "QUIAPO", "SAN NICOLAS", "SANTA CRUZ" };
                comboBoxCity.Items.AddRange(CITIES);
            }
            else if (comboBoxDistrict.Text == "4")
            {
                comboBoxCity.Items.Clear();
                comboBoxCity.Items.Add("SAMPALOC");
            }
            else if (comboBoxDistrict.Text == "5")
            {
                comboBoxCity.Items.Clear();
                string[] CITIES = { "ERMITA", "INTRAMUROS", "MALATE", "PORT AREA", "SAN ANDRES", "SOUTH PACO" };
                comboBoxCity.Items.AddRange(CITIES);
            }
            else if (comboBoxDistrict.Text == "6")
            {
                comboBoxCity.Items.Clear();
                string[] CITIES = { "NORTH PACO", "PANDACAN", "SAN MIGUEL", "SANTA ANA", "SANTA MESA" };
                comboBoxCity.Items.AddRange(CITIES);
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
        //father's number accept only numbers
        private void textBoxFatherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //mother's number accept only numbers
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = "Before submitting, have you reviewed your information?";
            string title = "Submit the Form?";
            SendKeys.Send("{Tab}");
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
         

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if (result == DialogResult.No)
            {

            }
            else if (result == DialogResult.Yes)
            {
               
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
                string filePath = open.FileName;
                //get the filename only
                string fileName = System.IO.Path.GetFileName(filePath);
                lblUploadImage.Text = fileName;
                btnUploadImage.Text = "Change Image";
            }
        }

        private void btnUploadDiploma_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "PDF Files(*.pdf)|*.pdf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                // pictureBox1.Image = new Bitmap(open.FileName);
                // pdf full file path  
                string filePath = open.FileName;
                //get the filename only
                string fileName = System.IO.Path.GetFileName(filePath);
                lblUploadDiploma.Text = fileName;
                btnUploadDiploma.Text = "Change File";
            }
        }
    }
}
