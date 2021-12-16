using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace computerizedRegistrationSystem.adminUserControls
{
    public partial class UCmanage_students : UserControl
    {
        private string selectedCourse;
        public static string selectedStudentID = "";
        public static bool fromManageStudents;

        public UCmanage_students()
        {
            InitializeComponent();
        }

        private void UCmanage_students_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        //reload table
        private void LoadTable()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT student_id, first_name, middle_name, last_name,college,course,email,contact_no,gender,town,date_admitted,status FROM studentsTable " +
                    "WHERE status='ACCEPTED'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command); // will help to fill the data
                DataTable dt = new DataTable(); //fill this with the values from adapter
                adapter.Fill(dt);
                dataGridViewApplications.DataSource = dt;
                //reaname datagridview headers
                dataGridViewApplications.Columns[0].HeaderText = "Student ID";
                dataGridViewApplications.Columns[1].HeaderText = "First Name";
                dataGridViewApplications.Columns[2].HeaderText = "Middle Name";
                dataGridViewApplications.Columns[3].HeaderText = "Last Name";
                dataGridViewApplications.Columns[4].HeaderText = "College";
                dataGridViewApplications.Columns[5].HeaderText = "Course";
                dataGridViewApplications.Columns[6].HeaderText = "Email";
                dataGridViewApplications.Columns[7].HeaderText = "Contact #";
                dataGridViewApplications.Columns[8].HeaderText = "Gender";
                dataGridViewApplications.Columns[9].HeaderText = "Town";
                dataGridViewApplications.Columns[10].HeaderText = "Date Admitted";
                dataGridViewApplications.Columns[11].HeaderText = "Status";

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

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            LoadTable();
        }
        //load the table where college is equal to the college selected
        private void comboBoxCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT student_id, first_name, middle_name, last_name,college,course,email,contact_no,gender,town,date_admitted,status FROM studentsTable " +
                    "WHERE college='" + comboBoxCollege.SelectedItem + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command); // will help to fill the data
                DataTable dt = new DataTable(); //fill this with the values from adapter
                adapter.Fill(dt);
                dataGridViewApplications.DataSource = dt;
                //reaname datagridview headers
                dataGridViewApplications.Columns[0].HeaderText = "Student ID";
                dataGridViewApplications.Columns[1].HeaderText = "First Name";
                dataGridViewApplications.Columns[2].HeaderText = "Middle Name";
                dataGridViewApplications.Columns[3].HeaderText = "Last Name";
                dataGridViewApplications.Columns[4].HeaderText = "College";
                dataGridViewApplications.Columns[5].HeaderText = "Course";
                dataGridViewApplications.Columns[6].HeaderText = "Email";
                dataGridViewApplications.Columns[7].HeaderText = "Contact #";
                dataGridViewApplications.Columns[8].HeaderText = "Gender";
                dataGridViewApplications.Columns[9].HeaderText = "Town";
                dataGridViewApplications.Columns[10].HeaderText = "Date Admitted";
                dataGridViewApplications.Columns[11].HeaderText = "Status";

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
        //load the table where course is equeal to the course selected
        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCourse.SelectedIndex == 0)
            {
                selectedCourse = comboBoxCourse.Text;
            }
            else if (comboBoxCourse.SelectedIndex == 1)
            {
                selectedCourse = comboBoxCourse.Text;
            }
            else if (comboBoxCourse.SelectedIndex == 2)
            {

                selectedCourse = comboBoxCourse.Text;
            }
            else if (comboBoxCourse.SelectedIndex == 3)
            {
                selectedCourse = comboBoxCourse.Text;
            }
            else if (comboBoxCourse.SelectedIndex == 4)
            {
                selectedCourse = comboBoxCourse.Text;
            }
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT student_id, first_name, middle_name, last_name,college,course,email,contact_no,gender,town,date_admitted,status FROM studentsTable " +
                    "WHERE course='" + selectedCourse + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command); // will help to fill the data
                DataTable dt = new DataTable(); //fill this with the values from adapter
                adapter.Fill(dt);
                dataGridViewApplications.DataSource = dt;
                //reaname datagridview headers
                dataGridViewApplications.Columns[0].HeaderText = "Student ID";
                dataGridViewApplications.Columns[1].HeaderText = "First Name";
                dataGridViewApplications.Columns[2].HeaderText = "Middle Name";
                dataGridViewApplications.Columns[3].HeaderText = "Last Name";
                dataGridViewApplications.Columns[4].HeaderText = "College";
                dataGridViewApplications.Columns[5].HeaderText = "Course";
                dataGridViewApplications.Columns[6].HeaderText = "Email";
                dataGridViewApplications.Columns[7].HeaderText = "Contact #";
                dataGridViewApplications.Columns[8].HeaderText = "Gender";
                dataGridViewApplications.Columns[9].HeaderText = "Town";
                dataGridViewApplications.Columns[10].HeaderText = "Date Admitted";
                dataGridViewApplications.Columns[11].HeaderText = "Status";

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

        private void button4_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedStudentID == "")
            {
                MessageBox.Show("Choose an applicant first. (Reload the table)");
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_drop>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_drop>().First().Close();

                adminOtherForms.admin_drop admin_drop = new adminOtherForms.admin_drop();
                admin_drop.Show();
            }
        }

        private void dataGridViewApplications_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridViewApplications.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                selectedStudentID = row.Cells[0].Value.ToString(); //applicant id column

            }
        }
        //view info
        private void button1_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedStudentID == "")
            {
                string title = "View students's information";
                MessageBox.Show("Choose a student first. (Reload the table)", title);
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_view_students_info>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_view_students_info>().First().Close();

                adminOtherForms.admin_view_students_info viewInfo = new adminOtherForms.admin_view_students_info();
                viewInfo.Show();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedStudentID == "")
            {
                string title = "View Diploma";
                MessageBox.Show("Choose a student first. (Reload the table)", title);
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_view_student_diploma>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_view_student_diploma>().First().Close();

                adminOtherForms.admin_view_student_diploma admin_view_student_diploma = new adminOtherForms.admin_view_student_diploma();
                admin_view_student_diploma.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //check first if an applicant is selected
            if (selectedStudentID == "")
            {
                string title = "View Transcript of Records";
                MessageBox.Show("Choose a student first. (Reload the table)", title);
            }
            else
            {
                //check if the form is already open, close if a form is already open
                if (Application.OpenForms.OfType<adminOtherForms.admin_view_student_tor>().Count() == 1)
                    Application.OpenForms.OfType<adminOtherForms.admin_view_student_tor>().First().Close();

                adminOtherForms.admin_view_student_tor admin_view_student_tor = new adminOtherForms.admin_view_student_tor();
                admin_view_student_tor.Show();
            }
        }
        //view dropped students
        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            try
            {
                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT student_id, first_name, middle_name, last_name,college,course,email,contact_no,gender,town,date_admitted,status FROM studentsTable " +
                    "WHERE status='DROPPED'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command); // will help to fill the data
                DataTable dt = new DataTable(); //fill this with the values from adapter
                adapter.Fill(dt);
                dataGridViewApplications.DataSource = dt;
                //reaname datagridview headers
                dataGridViewApplications.Columns[0].HeaderText = "Student ID";
                dataGridViewApplications.Columns[1].HeaderText = "First Name";
                dataGridViewApplications.Columns[2].HeaderText = "Middle Name";
                dataGridViewApplications.Columns[3].HeaderText = "Last Name";
                dataGridViewApplications.Columns[4].HeaderText = "College";
                dataGridViewApplications.Columns[5].HeaderText = "Course";
                dataGridViewApplications.Columns[6].HeaderText = "Email";
                dataGridViewApplications.Columns[7].HeaderText = "Contact #";
                dataGridViewApplications.Columns[8].HeaderText = "Gender";
                dataGridViewApplications.Columns[9].HeaderText = "Town";
                dataGridViewApplications.Columns[10].HeaderText = "Date Admitted";
                dataGridViewApplications.Columns[11].HeaderText = "Status";

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
}

