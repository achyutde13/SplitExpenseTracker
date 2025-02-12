using System.ComponentModel.DataAnnotations;

namespace SplitExpenseTracker.Data.Models
{
    public class Expense
    {
        [Key]
        public int Expense_Id { get; set; }
        [Required(ErrorMessage = "Expense name is Required!")]
        [StringLength(100, ErrorMessage = "Expense name cannot exceed 100 characters!")]
        public string ExpenseName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Amount is Required!")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero!")]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Paid by is Required!")]
        public int PaidById { get; set; }
        public Member PaidBy { get; set; } = null!;
    }
}
