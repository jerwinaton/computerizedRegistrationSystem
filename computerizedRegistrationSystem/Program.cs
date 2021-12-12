using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //for connection of database
using System.Configuration; //so we can use the connection string we set on app.config

namespace computerizedRegistrationSystem

{
    static class Program
    {
        //create database connection
        //we defined it here in program.cs so we can just call it to all of the forms
        //global variable that can be called via program.connection
        public static OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
     
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLanding());
        }
    }

}
