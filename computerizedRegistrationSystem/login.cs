using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstCSharpApp
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            { 
                Program.connection.Open(); //open database connection which was defined in
                                            //the program.cs line 18 as a global variable
                MessageBox.Show("connected");
                Program.connection.Close(); //close the connection
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
         }
        
        //login button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //set username and password for example
            string username = "20-22-0859";
            string password = "default";
            //get value of username and password textboxes
            string enteredUsername = textBoxUserName.Text;
            string enteredPassword = textBoxPassword.Text;

            //if username or password is incorrent, open a msgbox and don't login
            if(username != enteredUsername || password != enteredPassword)
            {
                string message = "Username or Password was not found in the Database";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Retry)
                {
                    textBoxUserName.Text = "";
                    textBoxPassword.Text = "";
                }
                else
                {
                //do nothing
                }

            }
            //if username or password is correct, procced to homepage
            else if (username == enteredUsername && password == enteredPassword)
            {
                frmLogin formLogin = new frmLogin();
                frmHome formHome = new frmHome();
                Hide();
                formHome.Show();
            }
        
            

        }
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Hide();
            frmLanding formLanding = new frmLanding();
            formLanding.Show();
        }
    }
}
