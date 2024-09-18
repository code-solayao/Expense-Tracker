using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Expense> expenses = _context.Expenses.ToList();

            double totalSum = expenses.Sum(expense => expense.Value);
            ViewBag.Expenses = totalSum.ToString();

            return View(expenses);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Expense? expense = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            return View(expense);
        }

        public IActionResult UpdateExpense(Expense expense)
        {
            _context.Expenses.Update(expense);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Expense? expense = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
