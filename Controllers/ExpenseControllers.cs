using Microsoft.AspNetCore.Mvc;
using FinCoachAPI.Models;

namespace FinCoachAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Adresimiz: api/expense
    public class ExpenseController : ControllerBase
    {
        private static List<Expense> _expenses = new List<Expense>
        {
            new Expense { Id = 1, UserId = 1, Description = "Borsa Istanbul Hisse Alımı (BIST)", Amount = 15000, Date = DateTime.Now.AddDays(-3), Category = "Yatırım" },
            new Expense { Id = 2, UserId = 1, Description = "Merkezi Ofis Elektrik & İnternet", Amount = 3200, Date = DateTime.Now.AddDays(-1), Category = "Fatura" },
            new Expense { Id = 3, UserId = 2, Description = "Bulut Sunucu Barındırma Hizmeti", Amount = 4500, Date = DateTime.Now, Category = "Altyapı" }
        };

        // 1. TÜM FİNANSAL VERİLERİ RAPORLA (GET api/expense)
        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetAllExpenses()
        {
            return Ok(_expenses);
        }

        // 2. KULLANICI BAZLI FİNANSAL AKIŞI GETİR (GET api/expense/user/1)
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Expense>> GetExpensesByUser(int userId)
        {
            var userExpenses = _expenses.Where(e => e.UserId == userId).ToList();
            return Ok(userExpenses);
        }

        // 3. SİSTEME YENİ FİNANSAL VERİ GİRİŞİ (POST api/expense)
        [HttpPost]
        public ActionResult<Expense> CreateExpense([FromBody] Expense newExpense)
        {
           
            newExpense.Id = _expenses.Max(e => e.Id) + 1;
            newExpense.Date = DateTime.Now;
            _expenses.Add(newExpense);

            return Ok(newExpense);
        }
    }
}