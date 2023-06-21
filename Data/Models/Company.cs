using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CompaniesProjectz.Data.Models
{
    public class Company
    {
        public Company()
        {
            CompaniesInstInvestors = new HashSet<CompaniesInstInvestor>();
            IndividualInvestors = new HashSet<IndividualInvestor>();
            Owners = new HashSet<Owner>();
            Statistics = new HashSet<Statistic>();

            this.TickerSymbol = null;
            this.CompanyName = null;
            this.MarketCap = null;
            this.AboutTheCompany = null;
            this.WebSite = null;
            this.IconPath = null;
            this.ImagePath = null;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

     
        public string TickerSymbol { get; set; }

        [Required]
        [MaxLength(30)]
        public string CompanyName { get; set; }
        public string MarketCap { get; set; }
        public string AboutTheCompany { get; set; }
        public string WebSite { get; set; }
        public string IconPath { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Statistic> Statistics { get; set; }
        public virtual ICollection<CompaniesInstInvestor> CompaniesInstInvestors { get; set; }
        public virtual ICollection<IndividualInvestor> IndividualInvestors { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }

        public Company(string TickerSymbol,string CompanyName, string MarketCap, string AboutTheCompany, string WebSite, string IconPath, string ImagePath)
        {
            
            this.TickerSymbol = TickerSymbol;
            this.CompanyName = CompanyName;
            this.MarketCap = MarketCap;
            this.AboutTheCompany = AboutTheCompany;
            this.WebSite = WebSite;
            this.IconPath = IconPath;
            this.ImagePath = ImagePath;
        }



        public override string ToString()
        {
            return $"({CompanyId})-{this.TickerSymbol}-{this.CompanyName}-{this.MarketCap}-{this.WebSite}";
        }
    }
}
