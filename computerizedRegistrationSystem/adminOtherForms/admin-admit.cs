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
        private string student_last_name, student_id; //to be used below in creating an account for students
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

                    //updated values/data of the student
                    command.Parameters.AddWithValue("@application_id", OleDbType.Integer).Value = Convert.ToInt32(id);
                    command.Parameters.AddWithValue("@college", OleDbType.VarChar).Value = college;
                    command.Parameters.AddWithValue("@course", OleDbType.VarChar).Value = course;
                    command.Parameters.AddWithValue("@status", OleDbType.VarChar).Value = "ACCEPTED";
                    command.Parameters.AddWithValue("@date_admitted", OleDbType.Date).Value = DateTime.Today;


                    //if success create an account for that student
                    int dataInserted = command.ExecuteNonQuery();

                    //update status of applicant to ACCEPTED
                    OleDbCommand updateStatus = new OleDbCommand();//create command
                    updateStatus.Connection = connection;
                    updateStatus.CommandText = "UPDATE applicantsTable SET status='ACCEPTED' WHERE applicant_id=" + id;
                    updateStatus.ExecuteNonQuery();

                    //if admission is successful create an account for student
                    if (dataInserted > 0)
                    {
                        DialogResult okay = MessageBox.Show("The applicant was admitted successfully!");

                        if (okay == DialogResult.OK)
                        {
                            // OleDbConnection connection2 = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                            //   connection2.Open();
                            //we will create a  username and password for the student
                            //it must be in this format
                            //username: student_[student_id] or student_21
                            //password: last_name or dela cruz
                           
                            OleDbCommand command2 = new OleDbCommand();//create command
                            OleDbDataReader reader = null;
                            command2.Connection = connection;
                            try
                            {
                                command2.CommandText = "SELECT student_id, last_name FROM studentsTable where application_id=" + id;
                                reader = command2.ExecuteReader();

                                while (reader.Read())
                                {
                                    student_id = reader["student_id"].ToString();
                                    student_last_name = reader["last_name"].ToString(); //to be used in the UPDATE statement below
                                }

                                string username = "student_" + student_id; //to be used in the INSERT statement below
                                string password = student_last_name.ToLower();

                                //new query
                                OleDbCommand command3 = new OleDbCommand();//create command for inserting the temporary account credentials made
                                command3.Connection = connection;
                                command3.CommandText = "UPDATE studentsTable SET [username]='" + username + "', [password]='" + password + "' WHERE application_id=" + id;
                               // MessageBox.Show(command3.CommandText);
                               command3.ExecuteNonQuery(); //execute the insert statement
                                
                               
                                Close();
                            }
                            catch(Exception error)
                            {
                                MessageBox.Show("Error" + error);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occured the form was not submitted.");
                        connection.Close();
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
