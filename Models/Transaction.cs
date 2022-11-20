using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MttBankingApp.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? TransactionReference { get; set; }
        public decimal TransactionAmount { get; set; }
        public TranStatus TransactionStatus { get; set; }
        public bool IsSuccessful => TransactionStatus.Equals(TranStatus.Success);
        public string? TransactionDestinationAccount { get; set; }
        public string? TransactionSourceAccount { get; set; }
        public string? TransactionParticulars { get; set; }
        public TranType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<Transaction> Transactions { get; } = new List<Transaction>();

    }
    public enum TranStatus
    {
        Success,
        Failed,
        Error
    }
    public enum TranType
    {
        Deposit,
        Withdraw,
        Transfer
    }
    


}
