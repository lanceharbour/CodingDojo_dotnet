using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Ammount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User User { get; set; }

    }
}