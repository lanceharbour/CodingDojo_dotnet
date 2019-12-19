using System.ComponentModel.DataAnnotations;
namespace BankAccounts
{
    public class AccountViewModel
    {
        public User VMUser { get; set;}
        public Transaction VMTransaction { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "No money in the bank!")]
        public double Balance { get; set; }
    }
}