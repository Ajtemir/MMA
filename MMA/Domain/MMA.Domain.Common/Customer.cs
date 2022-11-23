using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMA.Domain.Common
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        public string Email { get; set; }
        public int? SellerId { get; set; }
        public Seller Seller { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
