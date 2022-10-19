using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class CustomerVM
    {
        public int Id { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Display(Name="ID Number")]
        public string IDNumber { get; set; }
        [Display(Name="Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name="Occupation/Job")]
        public string Occupation { get; set; }
        [Display(Name="Phone Number")]
        public int PhoneNumber { get; set; }
        [Display(Name="Email")]
        public string Email { get; set; }
        [Display(Name="Home Address")]
        public string HomeAddress { get; set; }

    }
    
}
