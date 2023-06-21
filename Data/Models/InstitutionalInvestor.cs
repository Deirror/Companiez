using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesProjectz.Data.Models
{
    public class InstitutionalInvestor
    {
        public InstitutionalInvestor()
        {
            CompaniesInstInvestors = new HashSet<CompaniesInstInvestor>();
            this.InvestorName = null;
            this.Location = null;
            this.ImagePath = null;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvestorId { get; set; }
        public string InvestorName { get; set; }
        public string Location { get; set; }

        public string ImagePath { get; set; }
        public virtual ICollection<CompaniesInstInvestor> CompaniesInstInvestors { get; set; }

        public InstitutionalInvestor(string InvestorName, string Location,string ImagePath)
        {
         
            this.InvestorName = InvestorName;
            this.Location = Location;
            this.ImagePath = ImagePath;
        }

        public override string ToString()
        {
            return $"({InvestorId})-{InvestorName}-{Location}";
        }
    }
}
