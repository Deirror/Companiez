using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesProjectz.Data.Models
{
   public class IndividualInvestor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvestorId { get; set; }
        public string InvestorName { get; set; }
        public int SharesInProcents { get; set; }

        public string ImagePath { get; set; }
        public int IdTsCompany { get; set; }
        [ForeignKey("IdTsCompany")]
        public virtual Company IdTsCompanyNavigation { get; set; }

        public IndividualInvestor(string InvestorName, int SharesInProcents, string ImagePath,int IdTsCompany)
        {         
            this.InvestorName = InvestorName;
            this.SharesInProcents = SharesInProcents;
            this.ImagePath = ImagePath;
            this.IdTsCompany = IdTsCompany;
        }

        public IndividualInvestor()
        {
            this.InvestorName = null;
            this.SharesInProcents = 0;
            this.ImagePath = null;
            
        }
        public override string ToString()
        {
            return $"({InvestorId})-{InvestorName}-{SharesInProcents}-{IdTsCompanyNavigation.TickerSymbol}";
        }
    }
}
