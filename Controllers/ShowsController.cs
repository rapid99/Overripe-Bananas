using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OverripeBananas.Models;

namespace OverripeBananas.Controllers
{
    public class ShowsController : Controller
    {
        private readonly OverripeBananasContext _context;

        public ShowsController(OverripeBananasContext context)
        {
            _context = context;    
        }

        // GET: Shows
        public async Task<IActionResult> Index(string searchString, string showGenre, string showRating)
        {
            //// using LINQ to get a list of genres
            IQueryable<string> genreQuery = from m in _context.Show
                                            orderby m.Genre
                                            select m.Genre;

            var shows = from m in _context.Show
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                shows = shows.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(showGenre))
            {
                shows = shows.Where(z => z.Genre == showGenre);
            }
            if (!String.IsNullOrEmpty(showRating))
            {
                shows = shows.Where(y => y.Rating == showRating);
            }


            var showGenreVM = new ShowGenreViewModel();
            showGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            showGenreVM.shows = await shows.ToListAsync();


            return View(showGenreVM);
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .SingleOrDefaultAsync(m => m.ID == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Rating,Description")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show.SingleOrDefaultAsync(m => m.ID == id);
            if (show == null)
            {
                return NotFound();
            }
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Genre,Rating,Description")] Show show)
        {
            if (id != show.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .SingleOrDefaultAsync(m => m.ID == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Show.SingleOrDefaultAsync(m => m.ID == id);
            _context.Show.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.ID == id);
        }
    }
}
