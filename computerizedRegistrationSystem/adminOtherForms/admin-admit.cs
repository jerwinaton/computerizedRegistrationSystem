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
    public partial class admin_admit : Form
    {
        public admin_admit()
        {
            InitializeComponent();
        }
        //admit button
        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBoxAdmitCollege.Text == "")
            {
                MessageBox.Show("Select a College first.");
            }
            else if (comboBoxAdmitCourse.Text == "")
            {
                MessageBox.Show("Select a Course first.");
            }
            else
            {
                string college = comboBoxAdmitCollege.Text;
                string course = comboBoxAdmitCourse.Text;
                string id = adminUserControls.UCadmissions.selectedApplicantID; // selected applicant in the datagridview admin form
                //INSERT INTO SELECT COMMAND
                OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                connection.Open();
                try
                {

                    OleDbCommand command = new OleDbCommand();//create command
                    command.Connection = connection;//give command the connection string
                    command.CommandText = "" +
                        //insert
                        "INSERT INTO studentsTable ([application_id],[first_name], [middle_name], [last_name], [gender], [birthdate], " +
                        "[email], [contact_no], [house_no], [street], [district], [barangay], [town], [zip_code], [mothers_name], [mothers_contact_no], " +
                        "[mothers_occupation], [fathers_name], [fathers_contact_no], [fathers_occupation], [last_school_attended], [honors_awards], " +
                        "[1x1_picture_filename], [1x1_picture], [diploma_filename], [diploma], [tor_filename], [tor], [track], [strand], " +
                        "[college], [course],  [status], [date_admitted]) " +
                        //select
                        "SELECT @application_id, st.first_name, st.middle_name, st.last_name, st.gender, st.birthdate, st.email, st.contact_no, st.house_no, " +
                        "st.street, st.district, st.barangay, st.town, st.zip_code, st.mothers_name, st.mothers_contact_no, st.mothers_occupation, " +
                        "st.fathers_name, st.fathers_contact_no, st.fathers_occupation, st.last_school_attended, st.honors_awards, " +
                        //1x1 needs brackets because it starts with a number
                        "st.[1x1_picture_filename], st.[1x1_picture], st.diploma_filename, st.diploma, st.tor_filename, st.tor, " +
                        "st.track, st.strand, @status, @college, @course, @date_admitted " +
                        //from
                        "FROM(SELECT first_name, middle_name, last_name, gender, birthdate, email, contact_no, house_no, " +
                        "street, district, barangay, town, zip_code, mothers_name, mothers_contact_no, mothers_occupation, " +
                        "fathers_name, fathers_contact_no, fathers_occupation, last_school_attended, honors_awards, " +
                        "[1x1_picture_filename], [1x1_picture], diploma_filename, diploma, tor_filename, tor, " +
                        "track, strand " +
                        "FROM applicantsTable WHERE applicant_id=" + id + ") as st";



                    command.Parameters.AddWithValue("@application_id", OleDbType.Integer).Value = Convert.ToInt32(id);
                    command.Parameters.AddWithValue("@college", OleDbType.VarChar).Value = college;
                    command.Parameters.AddWithValue("@course", OleDbType.VarChar).Value = course;
                    command.Parameters.AddWithValue("@status", OleDbType.VarChar).Value = "ACCEPTED";
                    command.Parameters.AddWithValue("@date_admitted", OleDbType.Date).Value = DateTime.Today;


                    command.ExecuteNonQuery();

                    MessageBox.Show("grape!");
                  

                }
                catch (Exception error)
                {
                    MessageBox.Show("An error occured " + error);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        private void admin_admit_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {

                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT * FROM applicantsTable WHERE applicant_id=" + adminUserControls.UCadmissions.selectedApplicantID; // where the applicant_id = to the id the user that logged in (in the login.cs)
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read 
                {
                    labelFullName.Text = reader["first_name"].ToString() + " " + reader["middle_name"].ToString() + " " + reader["last_name"].ToString();
                    labelApplicantID.Text = "applicant_"+reader["applicant_id"].ToString();
                    comboBoxCollege.SelectedItem = reader["college_applied"].ToString();
                    comboBoxCourse1.SelectedItem = reader["course_choice1"].ToString();
                    comboBoxCourse2.SelectedItem = reader["course_choice2"].ToString();

                    pictureBox1x1Image.BackgroundImage = byteArrayToImage((byte[])reader["1x1_picture"]);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured " + error);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
