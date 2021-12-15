using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
