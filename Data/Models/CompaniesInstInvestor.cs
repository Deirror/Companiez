using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesProjectz.Data.Models
{

    public class CompaniesInstInvestor
    {
        public int IdTsCompany { get; set; }

        [ForeignKey("IdTsCompany")]
        public virtual Company IdTsCompanyNavigation { get; set; }

        public int IdInstinvestorName { get; set; }

        [ForeignKey("IdInstinvestorName")]
        public virtual InstitutionalInvestor IdInstinvestorNavigation { get; set; }


        public CompaniesInstInvestor(int IdTsCompany, int IdInstinvestorName)
        {
            this.IdTsCompany = IdTsCompany;
            this.IdInstinvestorName = IdInstinvestorName;
        }

        public CompaniesInstInvestor()
        {

        }
        public override string ToString()
        {
            return $"{IdTsCompanyNavigation.TickerSymbol}-({IdInstinvestorName})-{IdInstinvestorNavigation.InvestorName}";
        }
    }
}
