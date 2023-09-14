using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementApp.MVC.Data;

namespace LibraryManagementApp.MVC.Controllers
{
    public class BooksFkController : Controller
    {
        private readonly LibraryManagementDbContext _context;

        public BooksFkController(LibraryManagementDbContext context)
        {
            _context = context;
        }

        // GET: BooksFk
        public async Task<IActionResult> Index()
        {
            var libraryManagementDbContext = _context.BooksFks.Include(b => b.Author);
            return View(await libraryManagementDbContext.ToListAsync());
        }

        // GET: BooksFk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BooksFks == null)
            {
                return NotFound();
            }

            var booksFk = await _context.BooksFks
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booksFk == null)
            {
                return NotFound();
            }

            return View(booksFk);
        }

        // GET: BooksFk/Create
        public IActionResult Create()
        {
            CreateSelectLists();
            return View();
        }

        // POST: BooksFk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OriginalTitle,SeriesTitle,AuthorId,PublishDate,Genre")] BooksFk booksFk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booksFk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CreateSelectLists();
            return View(booksFk);
        }

        // GET: BooksFk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BooksFks == null)
            {
                return NotFound();
            }

            var booksFk = await _context.BooksFks.FindAsync(id);
            if (booksFk == null)
            {
                return NotFound();
            }
            CreateSelectLists();
            return View(booksFk);
        }

        // POST: BooksFk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OriginalTitle,SeriesTitle,AuthorId,PublishDate,Genre")] BooksFk booksFk)
        {
            if (id != booksFk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booksFk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksFkExists(booksFk.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            CreateSelectLists();
            return View(booksFk);
        }

        // GET: BooksFk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BooksFks == null)
            {
                return NotFound();
            }

            var booksFk = await _context.BooksFks
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booksFk == null)
            {
                return NotFound();
            }

            return View(booksFk);
        }

        // POST: BooksFk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BooksFks == null)
            {
                return Problem("Entity set 'LibraryManagementDbContext.BooksFks'  is null.");
            }
            var booksFk = await _context.BooksFks.FindAsync(id);
            if (booksFk != null)
            {
                _context.BooksFks.Remove(booksFk);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksFkExists(int id)
        {
            return (_context.BooksFks?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private void CreateSelectLists()
        {
            var authors = _context.Authors.Select(q => new {
                Fullname = $"{q.FirstName} {q.LastName}", 
                q.Id
            });
            ViewData["AuthorId"] = new SelectList(authors, "Id", "Fullname");
        }
    }
}
