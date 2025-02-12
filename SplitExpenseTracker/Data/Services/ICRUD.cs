using SplitExpenseTracker.Data.Models;

namespace SplitExpenseTracker.Data.Services
{
    public interface ICRUD
    {
        public List<Member> GetAllMembers();
        public List<Expense> GetAllExpenses();
        public Member GetMemberById(int Id);
        public Expense GetExpenseById(int Id);
    }
}
