using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public string LoanType { get; set; }
        public int LoanTerm { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
    
}
