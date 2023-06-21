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
    public partial class FormDI : Form
    {
        public FormDI()
        {
            InitializeComponent();
        }
        Controller controller = new Controller();
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string choice = comboBox1.SelectedItem.ToString();
            MessageBox.Show("Successfully deleted!");
            Hide();
            controller.DeleteInst(int.Parse(choice));
        }

        private void FormDI_Load(object sender, EventArgs e)
        {
            List<object> list = controller.GetInfoCI();
            foreach(var el in list)
            {
                if (el is InstitutionalInvestor)
                {
                   InstitutionalInvestor companiesInstInvestor = (InstitutionalInvestor)el;
                    listBox1.Items.Add(el.ToString());
                    comboBox1.Items.Add(companiesInstInvestor.InvestorId);
                }
            }
        }
    }
}
