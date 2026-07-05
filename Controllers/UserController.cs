using Microsoft.AspNetCore.Mvc;
using FinCoachAPI.Models;

namespace FinCoachAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Tarayıcıdan erişirken: api/user olacak
    public class UserController : ControllerBase
    {
        // Test
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Kralım", Email = "furqnan@hotmail.com", IsPro = true, MonthlyIncome = 50000 },
            new User { Id = 2, Name = "Test Kullanıcısı", Email = "test@mail.com", IsPro = false, MonthlyIncome = 15000 }
        };

        // 1. TÜM KULLANICILARI GETİR (GET api/user)
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_users);
        }

        // 2. YENİ KULLANICI EKLE (POST api/user)
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User newUser)
        {
            // Basitçe yeni bir ID atayalım
            newUser.Id = _users.Max(u => u.Id) + 1;
            _users.Add(newUser);

            return Ok(newUser);
        }
    }
}