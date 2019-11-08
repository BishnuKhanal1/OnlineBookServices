using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookServices.Models
{
    public class MembershipType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [DataType(DataType.Currency)]
        [Required]
        public decimal SignUpFee { get; set; }

        [DisplayName("Rental Rate - Monthly")]
        [Required]
        public decimal ChargeRateOneMonth { get; set; }

        [Required]
        public decimal ChargeRateSixMonth { get; set; }

        [DisplayName("Selling Price (%)")]
        [Required]
        public decimal SellingPrice { get; set; }

    }
}