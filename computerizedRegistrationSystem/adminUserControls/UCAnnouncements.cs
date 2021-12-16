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


namespace computerizedRegistrationSystem.adminUserControls
{
    public partial class UCAnnouncements : UserControl
    {
        public UCAnnouncements()
        {
            InitializeComponent();
        }
        //save
        private void button1_Click(object sender, EventArgs e)
        {
            //preview it on the right side
            lblTitle1.Text = textBox1.Text;
            lblDetails1.Text = textBox2.Text;
            lblTitle2.Text = textBox3.Text;
            lblDetails2.Text = textBox4.Text;
            lblTitle3.Text = textBox5.Text;
            lblDetails3.Text = textBox6.Text;
            lblTitle4.Text = textBox7.Text;
            lblDetails4.Text = textBox8.Text;
            lblTitle5.Text = textBox9.Text;
            lblDetails5.Text = textBox10.Text;


            //save it on database
            Program.connection.Open(); //open connection to database

            OleDbCommand command = new OleDbCommand();//create command
            command.Connection = Program.connection;//give command the connection string
            try
            {
                command.CommandText = "UPDATE announcementsTable SET title1 = '" + textBox1.Text + "' ,details1='" + textBox2.Text + "',title2='" + textBox3.Text + "',details2='" + textBox4.Text + "',title3='" + textBox5.Text + "'," +
                    "details3='" + textBox6.Text + "',title4='" + textBox7.Text + "',details4='" + textBox8.Text + "',title5='" + textBox9.Text + "',details5='" + textBox10.Text + "' WHERE id=6"; 
                   
                 int okay = command.ExecuteNonQuery();

                if (okay > 0)//success

                {
                    MessageBox.Show("Announcements have been updated.");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("An error occured"+ error);
            }
            finally
            {
                Program.connection.Close();
            }
        }

        private void UCAnnouncements_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            //open connection
            try
            {

                OleDbCommand command = new OleDbCommand();//create command
                command.Connection = connection;//give command the connection string
                command.CommandText = "SELECT * FROM announcementsTable";
                OleDbDataReader reader = command.ExecuteReader(); // execute

                while (reader.Read())//read 
                {
                    //textboxes
                    textBox1.Text = reader["title1"].ToString();
                    textBox3.Text = reader["title2"].ToString();
                    textBox5.Text = reader["title3"].ToString();
                    textBox7.Text = reader["title4"].ToString();
                    textBox9.Text = reader["title5"].ToString();
                    textBox2.Text = reader["details1"].ToString();
                    textBox4.Text = reader["details2"].ToString();
                    textBox6.Text = reader["details3"].ToString();
                    textBox8.Text = reader["details4"].ToString();
                    textBox10.Text = reader["details5"].ToString();

                    //labels on the right side
                    lblTitle1.Text = reader["title1"].ToString();
                    lblTitle2.Text = reader["title2"].ToString();
                    lblTitle3.Text = reader["title3"].ToString();
                    lblTitle4.Text = reader["title4"].ToString();
                    lblTitle5.Text = reader["title5"].ToString();
                    lblDetails1.Text = reader["details1"].ToString();
                    lblDetails2.Text = reader["details2"].ToString();
                    lblDetails3.Text = reader["details3"].ToString();
                    lblDetails4.Text = reader["details4"].ToString();
                    lblDetails5.Text = reader["details5"].ToString();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
