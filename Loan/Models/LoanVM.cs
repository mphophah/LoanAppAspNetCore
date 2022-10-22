using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class LoanVM
    {
        public int Id { get; set; }
        [Display(Name = "Loan Type")]
        [Required]
        public string LoanType { get; set; }
        [Display(Name = "Loan Term")]
        [Required]
        public int LoanTerm { get; set; }
        [Display(Name = "Interest Rate")]
        [Required]
        public decimal InterestRate { get; set; }
        [Display(Name = "Amount")]
        [Required]
        public decimal Amount { get; set; }
       public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
    }

    public class EditLoanVM
    {
        public int Id { get; set; }
        [Display(Name = "Loan Type")]
        [Required]
        public string LoanType { get; set; }
        [Display(Name = "Loan Term")]
        [Required]
        public int LoanTerm { get; set; }
        [Display(Name = "Interest Rate")]
        [Required]
        public decimal InterestRate { get; set; }
        [Display(Name = "Amount")]
        [Required]
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }

}
