using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieRent.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+\s[a-zA-Z]+$", ErrorMessage = "Name should only contain letters")]
        public string Name { get; set; }
        [Display(Name = "Is Subscribed to Newsletter")]
        public bool IsSubcribedToNewsLetter { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DOB { get; set; }
        [Required, Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public virtual MembershipType Membership { get; set; }
    }
}