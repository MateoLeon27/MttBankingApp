using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace MttBankingApp.Models
{
    [Table("Banks")]
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; }
       
    }
}
