using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitExpenseTracker.Data.Models
{
    public class DebtSettlement
    {
        [Key]
        public int SettlementId { get; set; }

        [Required]
        public int OwerId { get; set; }
        [ForeignKey("OwerId")]
        public Member Ower { get; set; } = null!;

        [Required]
        public int OwedToId { get; set; }
        [ForeignKey("OwedToId")]
        public Member OwedTo { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        public DateTime SettlementDate { get; set; } = DateTime.Now;
    }
}
