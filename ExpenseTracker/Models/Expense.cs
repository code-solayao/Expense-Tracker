using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required] public string? Description { get; set; }
        public double Value { get; set; }

        public Expense() { }
    }
}
