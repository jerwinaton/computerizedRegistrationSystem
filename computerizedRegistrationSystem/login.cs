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
using System.Drawing.Text;

namespace computerizedRegistrationSystem
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
       
         }
        
        //login button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //get value of username and password textboxes
            string enteredUsername = textBoxUserName.Text;
            string enteredPassword = textBoxPassword.Text;

        
            if (enteredUsername == "")//check if empty
            {
                string message = "Please enter your username.";
                string title = "Login Failed";
                MessageBox.Show(message, title);
                textBoxUserName.Select(); //focus on username textbox
            }
            else if (enteredPassword == "")//check if empty
            {
                string message = "Please enter your password.";
                string title = "Login Failed";
                MessageBox.Show(message, title);
                textBoxPassword.Select(); //focus on password textbox
            }
            else //if username and password is not empty then proceed
            {
          
                try
                {
                    //open database connection which was defined in
                    //the program.cs line 18 as a global variable
                    Program.connection.Open();

                    OleDbCommand command = new OleDbCommand();//create command
                    command.Connection = Program.connection;//give command the connection string

                    string who; //variable which will be used to identify which user is loggin in

                    //to know if the user is an admin, or a teacher, or a student
                    //based on their username

                    //if it is an admin, search in the adminAccounts table
                    if (enteredUsername.Contains("admin"))
                    {
                        who = "admin";
                      command.CommandText = "select * from adminAccounts where username='" + enteredUsername + "' and password='" + enteredPassword + "' ";
                    }
                    //if it is a teacher, search in the teacherAccounts table
                    else if (enteredUsername.Contains("teacher"))
                    {
                        who = "teacher";
                        //code
                    }
                    //else search in the studentsAccounts table
                    else
                    {
                        who = "student";
                        //code
                    }

                    //EXECUTE THE QUERY
                    //AFTER THIS LINE THE commandText value could be selecting to adminAccounts Table,
                    //or teacherAccounts Table, or studentsAccounts Table. 
                    //It depends on the username

                    //use executeReader for select queiries, ExecuteNonQuery for insert, update, delete 
                    //read the data using this
                    OleDbDataReader reader = command.ExecuteReader();
                    int count = 0;

                    while (reader.Read())//continue reading until finished reading all of the data
                    {
                        count = count + 1; //if found increment count
                                           //count++
                    }
                    if (count == 1) //if found
                    {
                        //username and password was found in the database
                        //login
                        frmLogin formLogin = new frmLogin();
                        frmMainAdmin formAdmin = new frmMainAdmin();
                        frmMainStudent formStudent = new frmMainStudent();
                        //frmMainTeacher formTeacher = new frmMainTeacher();

                        Hide();//hide this form

                        //decide what form to open based on who is logging in
                        if (who == "admin")
                        {
                          formAdmin.Show();
                        }
                        else if (who == "teacher")
                        {
                           // frmMainTeacher.Show();
                        }
                        else
                        {
                            formStudent.Show();
                        }
                     
                        Program.connection.Close(); //close the connection
                    }
                    else
                    {
                        //username and password was NOT found in the database
                        //if username or password is incorrent, open a msgbox and don't login
                        string message = "Username or Password was not found in the Database";
                        string title = "Login Failed";
                        MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Retry)
                        {
                            textBoxUserName.Text = "";
                            textBoxPassword.Text = "";
                            textBoxUserName.Select();
                        }
                        Program.connection.Close(); //close the connection
                    }
                    Program.connection.Close(); //close the connection
                }
                catch (Exception error) //show error 
                {
                    MessageBox.Show("Error " + error);
                }

            }//end of else (if username and password is not empty then proceed)


        }//end of login button
        


        //other functions 

        //change forgot password color on Mouse Hover
        private void lnkForgotPassword_MouseHover(object sender, EventArgs e)
        {
            lnkForgotPassword.ForeColor = System.Drawing.Color.FromArgb(215, 170, 47); 
        }
        //change forgot password color on Mouse Leave
        private void lnkForgotPassword_MouseLeave(object sender, EventArgs e)
        {
            lnkForgotPassword.ForeColor = System.Drawing.Color.FromArgb(9, 45, 12);
        }

        //show msgbox on form closing
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to exit the application?";
            string title = "Error";
            SendKeys.Send("{Tab}");
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            //if No is selected cancel form closing event
            if ( result == DialogResult.No)
                {
                e.Cancel = true;
            }else if (result == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            
        }
        //capture 'enter' key pressed event on textbox Username
        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
        //capture 'enter' key pressed event on textbox Password
        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {          
                if (e.KeyCode == Keys.Enter)
                {
                button1_Click(sender, e);
                }
        }
        //back button
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Hide();
            frmLanding formLanding = new frmLanding();
            formLanding.Show();
        }
    }
}
