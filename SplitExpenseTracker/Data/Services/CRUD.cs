using SplitExpenseTracker.Data.Models;

namespace SplitExpenseTracker.Data.Services
{
    public class CRUD : ICRUD
    {
        private readonly AppDbContext _db;
        public CRUD(AppDbContext db)
        {
            _db = db;
        }
        public List<Member> GetAllMembers()
        {
            try
            {

                var dbData = _db.Members.ToList();
                if (dbData.Any())
                {
                    return dbData;
                }
                else
                    return new List<Member>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Expense> GetAllExpenses()
        {
            try
            {
                var dbData = _db.Expenses.ToList();
                if (dbData.Any())
                {
                    return dbData;
                }
                else
                    return new List<Expense>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Member GetMemberById(int Id)
        {
            try
            {
                var dbData = _db.Members.FirstOrDefault(x => x.Member_Id == Id);
                if (dbData is not null)
                    return dbData;
                else
                    return new Member();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Expense GetExpenseById(int Id)
        {
            try
            {
                var dbData = _db.Expenses.FirstOrDefault(x => x.Expense_Id == Id);
                if (dbData is not null)
                    return dbData;
                else
                    return new Expense();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
