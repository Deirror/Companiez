using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CompaniesProjectz.Data.Models;
using CompaniesProjectz.Data;
using CompaniesProjectz.Properties;
using System.Linq;




namespace CompaniesProjectz.Controllers
{
    public class Controller
    {
        
       private CompaniesProjectzDbContext context;
  
        public Controller()
        {
           context = new CompaniesProjectzDbContext();
        }
        
        public List<string> InstNamesInfo()
        {
            
                List<string> instinvstnames = new List<string>();

<<<<<<< HEAD
                foreach (var elements in context.InstitutionalInvestors)
                {
                    instinvstnames.Add(elements.InvestorName);
=======
                foreach (var el in context.InstitutionalInvestors)
                {
                    instinvstnames.Add(el.InvestorName);
>>>>>>> 6b236e3ec42601cd7f8fe3ca0169c46cfd47f455
                }

                return instinvstnames;
            
        }

        public List<string> IndvNamesInfo()
        {
           
                List<string> indvinvstnames = new List<string>();

                foreach (var el in context.IndividualInvestors)
                {
                    indvinvstnames.Add(el.InvestorName);
                }
                return indvinvstnames;
            
        }

        public int GetCompanyId(string symbol)
        {
            var row = context.Companies.FirstOrDefault(x => x.TickerSymbol == symbol);
            if (row != null)
            {
                return row.CompanyId;
            }
            else return -1;
        }

        public List<int> GettingIds(int tableid)
        {
            List<int> ids = new List<int>();
            if (tableid==1)
            {
                foreach (var el in context.Companies) ids.Add(el.CompanyId);
            }
            else if (tableid==2)
            {
                foreach (var el in context.Owners) ids.Add(el.OwnerId);
            }
            else if (tableid==3)
            {
                foreach (var el in context.Statistics) ids.Add(el.StatsId); 
            }
            else if (tableid==4)
            {
                foreach (var el in context.IndividualInvestors) ids.Add(el.InvestorId);

            }
            else if (tableid==5)
            {
                foreach (var el in context.InstitutionalInvestors) ids.Add(el.InvestorId);
            }

            return ids;
        }    

        public List<string> SymbolInfo()
        {
           
                List<string> symbols = new List<string>();

                foreach (var el in context.Companies)
                {
                    symbols.Add(el.TickerSymbol);
                }
                return symbols;
            

        }
        public List<object> GetInfoCI()
        {
            List<object> list = new List<object>();
            foreach (var el in context.CompaniesInstInvestors)
            {
                list.Add(el);
            }
            foreach (var el in context.InstitutionalInvestors)
            {
                list.Add(el);
            }
            foreach (var el in context.Companies)
            {
                list.Add(el);
            }

            return list;
        }
        public List<object> ListBoxInfo()
        {
         
                List<object> list = new List<object>();

                foreach (var el in context.Companies)
                {

                    list.Add(el);

                }

                foreach (var el in context.Owners)
                {

                    list.Add(el);

                }

                foreach (var el in context.Statistics)
                {

                    list.Add(el);

                }

                foreach (var el in context.IndividualInvestors)
                {
                    list.Add(el);


                }

                foreach (var el in context.InstitutionalInvestors)
                {
                    list.Add(el);


                }
                foreach (var el in context.CompaniesInstInvestors)
                {
                    list.Add(el);

                }

                return list;
            
        }

        public void Update(object obj,int choice)
        {

                if (obj is Company)
                {
                    Company company = (Company)obj;
                    var row = context.Companies.FirstOrDefault(x => x.CompanyId == choice);
                    if (row != null)
                    {
                        if (!string.IsNullOrEmpty(company.TickerSymbol))
                        {
                            row.TickerSymbol = company.TickerSymbol;

                        }

                        if (!string.IsNullOrEmpty(company.CompanyName)) row.CompanyName = company.CompanyName;

                        if (!string.IsNullOrEmpty(company.MarketCap))
                        {
                            row.MarketCap = company.MarketCap;
                        }


                        if (!string.IsNullOrEmpty(company.AboutTheCompany))
                        {
                            row.AboutTheCompany = company.AboutTheCompany;

                        }

                        if (!string.IsNullOrEmpty(company.WebSite)) row.WebSite = company.WebSite;

                        if (!string.IsNullOrEmpty(company.IconPath)) row.IconPath = company.IconPath;

                        if (!string.IsNullOrEmpty(company.ImagePath)) row.ImagePath = company.ImagePath;

                        context.SaveChanges();
                    }
                    else MessageBox.Show("Invalid Id");

                }
                else if (obj is Owner)
                {
                    Owner owner = (Owner)obj;
                    var row = context.Owners.FirstOrDefault(x => x.OwnerId == choice);
                    if (row != null)
                    {
                        if (!string.IsNullOrEmpty(owner.OwnerName)) row.OwnerName = owner.OwnerName;
                        context.SaveChanges();
                    }
                    else MessageBox.Show("Invalid Id");

                }
                else if (obj is Statistic)
                {
                    Statistic statistic = (Statistic)obj;
                    var row = context.Statistics.FirstOrDefault(x => x.StatsId == choice);
                    if (row != null)
                    {

                        if (statistic.Alltimelows != 0) row.Alltimelows = statistic.Alltimelows;

                        if (statistic.Alltimehighs != 0) row.Alltimehighs = statistic.Alltimehighs;

                        if (statistic.BuyOrSell != null) row.BuyOrSell = statistic.BuyOrSell;

                         context.SaveChanges();
                    }
                    else MessageBox.Show("Invalid Id");

                }
                else if (obj is IndividualInvestor)
                {
                    IndividualInvestor individualinvestor = (IndividualInvestor)obj;
                    var row = context.IndividualInvestors.FirstOrDefault(x => x.InvestorId == choice);
                    if (row != null)
                    {
                        if (individualinvestor.InvestorName != null) row.InvestorName = individualinvestor.InvestorName;

                        if (individualinvestor.SharesInProcents != 0) row.SharesInProcents = individualinvestor.SharesInProcents;

                        if (individualinvestor.ImagePath != null) row.ImagePath = individualinvestor.ImagePath;

                        context.SaveChanges();
                    }
                    else MessageBox.Show("Invalid Id");
                }
                else if (obj is InstitutionalInvestor)
                {
                    InstitutionalInvestor institutionalinvestor = (InstitutionalInvestor)obj;
                    var row = context.InstitutionalInvestors.FirstOrDefault(x => x.InvestorId == choice);
                    if (row != null)
                    {
                        if (institutionalinvestor.Location != null) row.Location = institutionalinvestor.Location;

                        if (institutionalinvestor.ImagePath != null) row.ImagePath = institutionalinvestor.ImagePath;

                        context.SaveChanges();
                    }

                    else MessageBox.Show("Invalid Id");
                }
                else if (obj is CompaniesInstInvestor)
                {
                    CompaniesInstInvestor companiesInstInvestor = (CompaniesInstInvestor)obj;
                    var row = context.CompaniesInstInvestors.FirstOrDefault(x => x.IdTsCompany == choice);
                    if (row != null)
                    {
                        context.Remove(row);
                        context.SaveChanges();
                        context.Add(companiesInstInvestor);
                        //context.SaveChanges();
                    }
                    else MessageBox.Show("Invalid Id");
                }
            
        }

        public void AddC(object obj)
        {

                if (obj is Company)
                {
                    context.Companies.Add((Company)obj);                
                    context.SaveChanges();
                }
                else if (obj is Owner)
                {

                    context.Owners.Add((Owner)obj);
                    context.SaveChanges();
                }
                else if (obj is Statistic)
                {

                    context.Statistics.Add((Statistic)obj);
                    context.SaveChanges();
                }
                else if (obj is IndividualInvestor)
                {

                    context.IndividualInvestors.Add((IndividualInvestor)obj);
                   context.SaveChanges();
                }
                else if (obj is InstitutionalInvestor)
                {

                    context.InstitutionalInvestors.Add((InstitutionalInvestor)obj);
                    context.SaveChanges();
                }
                else if (obj is CompaniesInstInvestor)
                {
                    context.CompaniesInstInvestors.Add((CompaniesInstInvestor)obj);
                   context.SaveChanges();
                }

        }
        public void DeleteInst(int choice)
        {
            foreach (var el in context.InstitutionalInvestors)
            {
                if(el.InvestorId == choice)
                {
                    context.Remove(el);
                }
            }

            foreach (var el in context.CompaniesInstInvestors)
            {
                if (el.IdInstinvestorNavigation.InvestorId== choice)
                {
                    context.Remove(el);
                }

            }
            context.SaveChanges();
        }
        public void DeleteC(string choice)
        {

                foreach (var el in context.Companies)
                {

                    if (el.TickerSymbol == choice)
                    {

                        context.Remove(el);
                    }

                }

                foreach (var el in context.Owners)
                {
                    if (el.CEONavigation.TickerSymbol == choice)
                    {
                        context.Remove(el);

                    }

                }
                foreach (var el in context.Statistics)
                {
                    if (el.IdTsCompanyNavigation.TickerSymbol == choice)
                    {
                        context.Remove(el);

                    }

                }
                foreach (var el in context.IndividualInvestors)
                {
                    if (el.IdTsCompanyNavigation.TickerSymbol == choice)
                    {
                        context.Remove(el);

                    }

                }
                foreach (var el in context.CompaniesInstInvestors)
                {
                    if (el.IdTsCompanyNavigation.TickerSymbol == choice)
                    {
                        context.Remove(el);

                    }

                }
                context.SaveChanges();      
          
        }
        public void TruncateDB()
        {
            
                foreach (var el in context.Companies)
                {
                    context.Remove(el);
                }
                foreach (var el in context.Owners)
                {
                    context.Remove(el);
                }
                foreach (var el in context.Statistics)
                {
                    context.Remove(el);
                }
                foreach (var el in context.IndividualInvestors)
                {
                    context.Remove(el);
                }
                foreach (var el in context.InstitutionalInvestors)
                {
                    context.Remove(el);
                }
                foreach (var el in context.CompaniesInstInvestors)
                {
                    context.Remove(el);
                }

                context.SaveChanges();

            
        }

            public List<object> TapPagesInfo(string choice, byte page)
            {
                
                    List<object> list = new List<object>();

                    if (page == 1)
                    {

                        foreach (var el in context.Companies)
                        {
                            if (el.TickerSymbol == choice)
                            {
                                list.Add(el);
                                break;
                            }

                        }

                        foreach (var el in context.Owners)
                        {

                            if (el.CEONavigation.TickerSymbol == choice)
                            {
                                list.Add(el);
                                break;
                            }

                        }

                        foreach (var el in context.Statistics)
                        {

                            if (el.IdTsCompanyNavigation.TickerSymbol == choice)
                            {
                                list.Add(el);
                                break;
                            }

                        }

                        foreach (var el in context.IndividualInvestors)
                        {
                            if (el.IdTsCompanyNavigation.TickerSymbol == choice)
                            {
                                list.Add(el);
                                break;
                            }


                        }

                        foreach (var el in context.CompaniesInstInvestors)
                        {
                            if (el.IdTsCompanyNavigation.TickerSymbol == choice)
                            {
                                list.Add(el);
                                break;
                            }

                        }
                    }
                    else if (page == 2)
                    {
                        foreach (var el in context.IndividualInvestors)
                        {
                            if (el.InvestorName == choice)
                            {
                                list.Add(el);
                                break;
                            }


                        }
                    }
                    else if (page == 3)
                    {
                        foreach (var el in context.InstitutionalInvestors)
                        {
                            if (el.InvestorName == choice)
                            {
                                list.Add(el);
                                break;
                            }


                        }

                        foreach (var el in context.CompaniesInstInvestors)
                        {
                            if (el.IdInstinvestorNavigation.InvestorName == choice)
                            {
                                list.Add(el);

                            }

                        }
                    }

                    return list;
                
            }
        
    }
}
