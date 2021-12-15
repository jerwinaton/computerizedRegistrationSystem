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

namespace computerizedRegistrationSystem
{
    public partial class home : UserControl
    {
        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
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
            catch(Exception error)
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
