using MttBankingApp.Models;

namespace MttBankingAPI.Models
{
    public class InvestmentAccount : Account
    {
        public new InvestmentAccountType AccountType { get; set; }
    }

    public enum InvestmentAccountType
    {
        Individual,
        Corporate,
        None
    }
}
