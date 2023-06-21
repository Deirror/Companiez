using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CompaniesProjectz.Data;
using CompaniesProjectz.Data.Models;
using CompaniesProjectz.Controllers;
using System.Linq;
using System.Diagnostics;

namespace CompaniesProjectz.Properties
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        Controller controller = new Controller();
        FormDAll formDAll = new FormDAll();
        FormD formd = new FormD();
        FormDI formdi = new FormDI();
        private string website;
        private int comboid;

//Methods
        public void ClearListBoxes()
        {
            foreach(ListBox listBox in tabPage5.Controls)
            {
                listBox.Items.Clear();
            }
        }

        private void ClearTextBox(TabPage page)
        {
            foreach (Control control in page.Controls)
                if (control is TextBox)
                    (control as TextBox).Clear();
        }

        private void AllTextBoxCallClear()
        {
            ClearTextBox(tabPage6);
            ClearTextBox(tabPage7);
            ClearTextBox(tabPage8);
            ClearTextBox(tabPage9);
            ClearTextBox(tabPage10);
            ClearTextBox(tabPage11);
        }

        private void PrintListBoxInfo(List<object> listcontext)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            foreach (var el in listcontext)
            {
                if (el is Company)
                {
                    listBox1.Items.Add(el.ToString());
                }
                else if (el is Owner)
                {
                    listBox2.Items.Add(el.ToString());
                }
                else if (el is Statistic)
                {
                    listBox3.Items.Add(el.ToString());
                }
                else if (el is IndividualInvestor)
                {
                    listBox4.Items.Add(el.ToString());
                }
                else if (el is InstitutionalInvestor)
                {
                    listBox5.Items.Add(el.ToString());
                }
                else if (el is CompaniesInstInvestor)
                {
                    listBox6.Items.Add(el.ToString());
                }
            }
        }

        private List<object> Gettinglistcontext()
        {
            
            List<object> listcontext = new List<object>();
           return listcontext = controller.ListBoxInfo();
            
          
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            PrintListBoxInfo(Gettinglistcontext());
        }
        //combo control
        private void GettingCompaniesInfoTP()
        {
            
            List<string> symbolslist = new List<string>();
            symbolslist = controller.SymbolInfo();
            foreach (var el in symbolslist)
            {
                comboBox1.Items.Add(el);
            }
            
        }
        private void GettingIndInvInfoTP()
        {
            
            List<string> indvnames = new List<string>();
            indvnames = controller.IndvNamesInfo();
            foreach (var el in indvnames)
            {
                comboBox2.Items.Add(el);
            }
            
        }

        private void GettingInstInvTP()
        {
            
            List<string> instnames = new List<string>();
            instnames = controller.InstNamesInfo();
            foreach (var el in instnames)
            {
                comboBox3.Items.Add(el);
            }
            
        }

        private void ComboBoxIds(ComboBox combo,List<int>ids)
        {
            foreach (var el in ids)
            {
                combo.Items.Add(el);
            }
        }
     
        private void ManageComboIds()
        {
            List<int> ids = controller.GettingIds(1);
            ComboBoxIds(comboBox5,ids);
             ids = controller.GettingIds(2);
            ComboBoxIds(comboBox6, ids);
            ids = controller.GettingIds(3);
            ComboBoxIds(comboBox7, ids);
            ids = controller.GettingIds(4);
            ComboBoxIds(comboBox8, ids);
            ids = controller.GettingIds(5);
            ComboBoxIds(comboBox9, ids);
        }
        private void ComboLabelsVisible(bool enabled)
        {
            label72.Visible = enabled;
            label73.Visible = enabled;
            label74.Visible = enabled;
            label75.Visible = enabled;
            label76.Visible = enabled;
            comboBox5.Visible = enabled;
            comboBox6.Visible = enabled;
            comboBox7.Visible = enabled;
            comboBox8.Visible = enabled;
            comboBox9.Visible = enabled;

        }
        private void ComboIdsClear()
        {
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();

        }

        private int GetTickerSymbolId(string symbol)
        {
            int res = controller.GetCompanyId(symbol);
            return res;

        }
        private void CheckChoice(string choice)
        {
            if (choice == "Add a company")
            {

                tabControl2.Enabled = true;
                label69.Text = "Activated";
                label69.ForeColor = Color.Green;
                label71.Text = "Deactivated";
                label71.ForeColor = Color.DarkRed;
                AllTextBoxCallClear();
                ComboLabelsVisible(false);

            }
            else if (choice == "Update a table")
            {
                ComboIdsClear();
                tabControl2.Enabled = true;
                label71.Text = "Activated";
                label71.ForeColor = Color.Green;
                label69.Text = "Deactivated";
                label69.ForeColor = Color.DarkRed;
                AllTextBoxCallClear();
                ComboLabelsVisible(true);
                ManageComboIds();



            }
            else if (choice == "Delete a company")
            {
                tabControl2.Enabled = false;
                label71.Text = "...";
                label69.Text = "...";
                formd.Show();
            }
            else if (choice == "Delete All")
            {
                tabControl2.Enabled = false;
                label71.Text = "...";
                label69.Text = "...";
                formDAll.Show();                    
            }
            else if(choice =="Delete an institution")
            {
                tabControl2.Enabled = false;
                label71.Text = "...";
                label69.Text = "...";
                formdi.Show();
            }
        }

        public void CheckFlag()
        {
            
            if (!formDAll.Flag)
            {
                controller.TruncateDB();
            }
            
        }

        private string getChoice()
        {
            return comboBox4.SelectedItem.ToString();
        }



//ADDING information
        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckChoice(getChoice());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (getChoice() == "Add a company")
            {
                Company company = new Company(textBox1.Text, textBox2.Text, textBox3.Text, textBox22.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                controller.AddC(company);
                ClearTextBox(tabPage6);
                PrintListBoxInfo(Gettinglistcontext());

            }
            else
            {
                Company company = new Company();
          
                if (!string.IsNullOrEmpty(textBox1.Text)) company.TickerSymbol = textBox1.Text;

                if (!string.IsNullOrEmpty(textBox2.Text)) company.CompanyName = textBox2.Text;
 
                if (!string.IsNullOrEmpty(textBox3.Text)) company.MarketCap = textBox3.Text;

                if (!string.IsNullOrEmpty(textBox22.Text)) company.AboutTheCompany = textBox22.Text;

                if (!string.IsNullOrEmpty(textBox4.Text)) company.WebSite = textBox4.Text;

                if (!string.IsNullOrEmpty(textBox5.Text)) company.IconPath = textBox5.Text;
       
                if (!string.IsNullOrEmpty(textBox6.Text)) company.ImagePath = textBox6.Text;
   
                controller.Update(company, comboid);
                
                PrintListBoxInfo(Gettinglistcontext());
                ClearTextBox(tabPage6);
            }
            

            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            if (getChoice() == "Add a company")
            {
                try
                {
                    Owner owner = new Owner(textBox7.Text, GetTickerSymbolId(textBox8.Text));
                    controller.AddC(owner);
                    ClearTextBox(tabPage7);
                }
                catch(Exception)
                {
                    MessageBox.Show("Invalid Symbol!");
                    ClearTextBox(tabPage7);
                }
            }
            else
            {
                try
                {
                    Owner owner = new Owner();
                    if (!string.IsNullOrEmpty(textBox7.Text)) owner.OwnerName = textBox7.Text;

                    if (!string.IsNullOrEmpty(textBox8.Text)) owner.CEO = GetTickerSymbolId(textBox8.Text);

                    controller.Update(owner, comboid);
                    ClearTextBox(tabPage7);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Symbol!");
                    ClearTextBox(tabPage7);
                }

            }
            
            PrintListBoxInfo(Gettinglistcontext());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (getChoice() == "Add a company")
            {
                try
                {
                    Statistic statistic = new Statistic(GetTickerSymbolId(textBox9.Text), float.Parse(textBox10.Text), float.Parse(textBox11.Text), textBox12.Text);
                    controller.AddC(statistic);
                    ClearTextBox(tabPage8);
                }
              catch(Exception)
                {
                    MessageBox.Show("Invalid Symbol!");
                    ClearTextBox(tabPage8);
                }
            }
            else
            {
                try
                {
                    Statistic statistic = new Statistic();

                    if (!string.IsNullOrEmpty(textBox10.Text)) statistic.Alltimelows = float.Parse(textBox10.Text);

                    if (!string.IsNullOrEmpty(textBox11.Text)) statistic.Alltimehighs = float.Parse(textBox11.Text);

                    if (!string.IsNullOrEmpty(textBox12.Text)) statistic.BuyOrSell = textBox12.Text;
                    controller.Update(statistic, comboid);
                    ClearTextBox(tabPage8);
                }
                catch(Exception)
                {
                    MessageBox.Show("Invalid Symbol!");
                    ClearTextBox(tabPage8);
                }
            }
           
            PrintListBoxInfo(Gettinglistcontext());
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            if (getChoice() == "Add a company")
            {
                try
                {
                    IndividualInvestor individualinvestor = new IndividualInvestor(textBox13.Text, int.Parse(textBox14.Text), textBox15.Text, GetTickerSymbolId(textBox16.Text)); 
                    controller.AddC(individualinvestor);
                    ClearTextBox(tabPage9);
                }
               catch(Exception)
                {
                    MessageBox.Show("Invalid Symbol!");
                    ClearTextBox(tabPage9);
                }
            }
            else
            {
                try
                {
                    IndividualInvestor individualinvestor = new IndividualInvestor();
                

                    if (!string.IsNullOrEmpty(textBox13.Text)) individualinvestor.InvestorName = textBox13.Text;

                    if (!string.IsNullOrEmpty(textBox14.Text)) individualinvestor.SharesInProcents = int.Parse(textBox14.Text);

                    if (!string.IsNullOrEmpty(textBox15.Text)) individualinvestor.ImagePath = textBox15.Text;

                    controller.Update(individualinvestor, comboid);
                    ClearTextBox(tabPage9);
                }
                catch(Exception)
                    {
                    MessageBox.Show("Invalid Symbol!");
                    ClearTextBox(tabPage9);
                }
            }
         
            PrintListBoxInfo(Gettinglistcontext());
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (getChoice() == "Add a company")
            {
                InstitutionalInvestor institutionalInvestor = new InstitutionalInvestor(textBox17.Text, textBox18.Text, textBox19.Text);
                controller.AddC(institutionalInvestor);
                ClearTextBox(tabPage10);
                
            }
            else
            {
                InstitutionalInvestor institutionalInvestor = new InstitutionalInvestor();

                if (!string.IsNullOrEmpty(textBox17.Text)) institutionalInvestor.InvestorName = textBox17.Text;

                if (!string.IsNullOrEmpty(textBox18.Text)) institutionalInvestor.Location = textBox18.Text;

                if (!string.IsNullOrEmpty(textBox19.Text)) institutionalInvestor.ImagePath = textBox19.Text;
                controller.Update(institutionalInvestor, comboid);
                ClearTextBox(tabPage10);
            }
            
            PrintListBoxInfo(Gettinglistcontext());
           
        }
        private void button6_Click_1(object sender, EventArgs e)
        {    
            
            if (getChoice() == "Add a company")
            {
                CompaniesInstInvestor companiesInstInvestor = new CompaniesInstInvestor(GetTickerSymbolId(textBox20.Text), int.Parse(textBox21.Text));
                controller.AddC(companiesInstInvestor);
                ClearTextBox(tabPage11);
            }
            else
            {
                CompaniesInstInvestor companiesInstInvestor = new CompaniesInstInvestor();
                if (!string.IsNullOrEmpty(textBox20.Text)) companiesInstInvestor.IdTsCompany = GetTickerSymbolId(textBox20.Text);

                if (!string.IsNullOrEmpty(textBox21.Text)) companiesInstInvestor.IdInstinvestorName = int.Parse(textBox21.Text);
                controller.Update(companiesInstInvestor, companiesInstInvestor.IdTsCompany);
                ClearTextBox(tabPage11);
            }
           
            PrintListBoxInfo(Gettinglistcontext());        
           
        }
   


        private void button9_Click(object sender, EventArgs e)
        {
            PrintListBoxInfo(Gettinglistcontext());
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {       
            
            string choice = comboBox1.SelectedItem.ToString();
            List<object> list = controller.TapPagesInfo(choice,1);
            foreach(var el in list)
            {
                if(el is Company)
                {
                    Company company = (Company)el;
                    label4.Text = company.CompanyName;
                    label5.Text = company.AboutTheCompany;
                    label7.Text = company.MarketCap;
                    if (!string.IsNullOrEmpty(company.IconPath))
                    {
                        pictureBox2.Image = Image.FromFile($"../Icons/{company.IconPath}");
                    }

                    if (!string.IsNullOrEmpty(company.ImagePath))
                    {
                        pictureBox3.Image = Image.FromFile($"../Images/{company.ImagePath}");
                    }
                    linkLabel1.Text = company.WebSite;
                    this.website = company.WebSite;

                }
                else if(el is Owner)
                {
                    Owner owner = (Owner)el;
                    label9.Text = owner.OwnerName;
                }
                else if(el is IndividualInvestor)
                {
                    IndividualInvestor individualInvestor = (IndividualInvestor)el;
                    label12.Text = individualInvestor.InvestorName;
                }
                else if (el is CompaniesInstInvestor)
                {
                    CompaniesInstInvestor companiesInstInvestor = (CompaniesInstInvestor)el;
                    label13.Text = companiesInstInvestor.IdInstinvestorNavigation.InvestorName;
                }
                else if(el is Statistic)
                {
                    Statistic statistic = (Statistic)el;
                    label17.Text = statistic.BuyOrSell;
                    label18.Text = statistic.Alltimehighs.ToString();
                    label19.Text = statistic.Alltimelows.ToString();
                }
            } 
            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            
            string choice = comboBox2.SelectedItem.ToString();
            List<object> list = controller.TapPagesInfo(choice, 2);   
                    IndividualInvestor individualInvestor = (IndividualInvestor)list[0];
                    label36.Text = individualInvestor.InvestorName;
                    label22.Text = individualInvestor.IdTsCompanyNavigation.CompanyName;
                    label25.Text = individualInvestor.SharesInProcents.ToString();

            if (!string.IsNullOrEmpty(individualInvestor.ImagePath))
            { 
                pictureBox4.Image = Image.FromFile($"../Images/{individualInvestor.ImagePath}");
            }
          
                
            
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            
            string choice = comboBox3.SelectedItem.ToString();
            List<object> list = controller.TapPagesInfo(choice, 3);
            label29.Text = "";
            foreach(var el in list)
            {
                if(el is InstitutionalInvestor)
                {
                    InstitutionalInvestor institutionalInvestor = (InstitutionalInvestor)el;
                    label31.Text = institutionalInvestor.InvestorName;
                    label28.Text = institutionalInvestor.Location;
                    if (!string.IsNullOrEmpty(institutionalInvestor.ImagePath))
                    {
                        pictureBox6.Image = Image.FromFile($"../Images/{institutionalInvestor.ImagePath}");
                    }
          
                }
                else if(el is CompaniesInstInvestor)
                {
                    CompaniesInstInvestor companiesInstInvestor = (CompaniesInstInvestor)el;
                    label29.Text += companiesInstInvestor.IdTsCompanyNavigation.CompanyName+"\n";
                }
            }
            
        }


       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
          Process.Start("explorer", $"https://{website}/");
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            comboid = int.Parse(comboBox5.SelectedItem.ToString());
        }

        private void comboBox7_SelectedValueChanged(object sender, EventArgs e)
        {
            comboid = int.Parse(comboBox7.SelectedItem.ToString());
        }

        private void comboBox6_SelectedValueChanged(object sender, EventArgs e)
        {
            comboid = int.Parse(comboBox6.SelectedItem.ToString());
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            comboid = int.Parse(comboBox8.SelectedItem.ToString());
        }

        private void comboBox9_SelectedValueChanged(object sender, EventArgs e)
        {
            comboid = int.Parse(comboBox9.SelectedItem.ToString());
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            GettingCompaniesInfoTP();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            GettingIndInvInfoTP();
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            GettingInstInvTP();
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            PrintListBoxInfo(Gettinglistcontext());
        }
        //end
    }
}
