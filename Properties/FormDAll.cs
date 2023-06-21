using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompaniesProjectz.Properties
{
    public partial class FormDAll : Form
    {
        public FormDAll()
        {
            InitializeComponent();
        }
        private bool check = true;
        public bool Flag { get { return check; } }
       

        private void button1_Click(object sender, EventArgs e)
        {
            check = false;
            Hide();
            FormConnection frc = new FormConnection();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            check = true;
            Hide();
            FormConnection frc = new FormConnection();
        }

    }
}