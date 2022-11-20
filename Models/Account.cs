using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MttBankingApp.Models
{
    [Table("CheckingAccounts")]
    public class Account 
    {
        [Key]
        public int Id { get; set; }
        public string? AccountName { get; private set; }
        public string? OwnerFirstName { get; private set; }
        public string? OwnerLastName { get; private set; }
        public int PhoneNumber { get; private set; }
        public string? Email { get; private set; }
        public decimal? AcctBalance { get; private set; }
        public AcctType AccountType { get; set; }
        public string AcctNumber { get; private set; }
        public byte[] Pin { get; private set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public enum AcctType
        {
            Checking,
            Investment
        }

       
        public Account()
        { 
            Random randomAcctNumber = new Random();
            AcctNumber = Convert.ToString((long)randomAcctNumber.NextDouble() * 9_000_000_000L + 1_000_000_000L);

            AccountName = $"{OwnerFirstName} {OwnerLastName}";
        }
    }
}
