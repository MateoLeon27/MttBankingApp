using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MttBankingAPI.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string? AccountNumber { get; private set; }
        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Pin must be 4-digit")]
        public string? Pin { get; private set; }
    }
}
