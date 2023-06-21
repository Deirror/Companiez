using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesProjectz.Data.Models
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }
        public string OwnerName { set; get; }
        public int CEO { get; set; }
        [ForeignKey("CEO")]
        public virtual Company CEONavigation { get; set; }

        public Owner(string OwnerName, int CEO)
        {          
            this.OwnerName = OwnerName;
            this.CEO = CEO;
        }

        public Owner()
        {
            this.OwnerName = null;         
        }

        public override string ToString()
        {
            return $"({OwnerId})-{this.OwnerName}-{CEONavigation.TickerSymbol}";
        }
    }
}
