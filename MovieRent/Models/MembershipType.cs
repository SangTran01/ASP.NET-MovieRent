using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRent.Models
{
    public class MembershipType
    {
        [Key]
        public int MembershipTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public short SignUpFee { get; set; }
        [Required]
        public byte DurationInMonths { get; set; }
        [Required]
        public byte DiscountRate { get; set; }
    }
}