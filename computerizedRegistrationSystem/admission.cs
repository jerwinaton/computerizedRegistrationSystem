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

      

      
    }
}
