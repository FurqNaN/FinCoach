namespace FinCoachAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsPro { get; set; } = false; // Free veya Pro 
        public decimal MonthlyIncome { get; set; }
    }
}