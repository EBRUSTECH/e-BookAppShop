using BookAppTask.Data;
using BookAppTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookAppTask.Controllers
{
    public class UserBooksController : Controller
    {
        private readonly BookAppTaskDbContext _context;

        public UserBooksController(BookAppTaskDbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            var bookAppTaskDbContext = _context.Books.Include(b => b.Category).Include(b => b.Genre).Take(12);
            return View(await bookAppTaskDbContext.ToListAsync());
        }

        // GET: Book/Details/
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
               .Include(b => b.Category)
               .Include(b => b.Genre)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Review/Create
        public IActionResult ReviewBook()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReviewBook(Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", review.BookId);
            return View(review);
        }

        //GET: Book/Search

        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                //If the search string is empty, show all books
                return RedirectToAction(nameof(Index));
            }

            var books = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Genre)
                .Where(b =>
                b.Title.Contains(searchString) ||
                b.Author.Contains(searchString) ||
                b.Publisher.Contains(searchString) ||
                b.ISBN.Contains(searchString))
                .ToListAsync();
            if (books.Count == 0)
            {
                ViewBag.Message =$"No results found for '{searchString}'.";
            }

            return View("Index", books);
        }

    }

}
