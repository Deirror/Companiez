using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesProjectz.Data.Models
{
    public class Statistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatsId { get; set; }
        public int IdTsCompany { get; set; }
        [ForeignKey("IdTsCompany")]
        public virtual Company IdTsCompanyNavigation { get; set; }
        public float Alltimelows { get; set; }
        public float Alltimehighs { get; set; }
        public string BuyOrSell { get; set; }


        public Statistic(int IdTsCompany, float Alltimelows, float Alltimehighs, string BuyOrSell)
        {
            this.IdTsCompany = IdTsCompany;
            this.Alltimelows = Alltimelows;
            this.Alltimehighs = Alltimehighs;
            this.BuyOrSell = BuyOrSell;
        }

        public Statistic()
        {
            this.Alltimehighs = 0;
            this.Alltimelows = 0;
            this.BuyOrSell = null;
        }
        public override string ToString()
        {
            return $"({StatsId})-{IdTsCompanyNavigation.TickerSymbol}-{Alltimelows}-{Alltimehighs}-{BuyOrSell}";
        }
    }
}
