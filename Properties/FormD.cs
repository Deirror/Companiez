using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CompaniesProjectz.Data.Models;
using CompaniesProjectz.Controllers;

namespace CompaniesProjectz.Properties
{
    public partial class FormD : Form
    {
        public FormD()
        {
            InitializeComponent();
        }

        Controller controller = new Controller();

   
        private void FormD_Load(object sender, EventArgs e)
        {
            
            List<string> symbolslist = new List<string>();
            symbolslist = controller.SymbolInfo();
            foreach(var el in symbolslist)
            {
                comboBox1.Items.Add(el);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string choice = comboBox1.SelectedItem.ToString();
            MessageBox.Show("Successfully deleted!");
            Hide();
            controller.DeleteC(choice);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
