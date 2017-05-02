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
    public class EpisodesController : Controller
    {
        private readonly OverripeBananasContext _context;

        public EpisodesController(OverripeBananasContext context)
        {
            _context = context;    
        }

        // GET: Episodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Episodes.ToListAsync());
        }

        // GET: Episodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodes = await _context.Episodes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (episodes == null)
            {
                return NotFound();
            }

            return View(episodes);
        }

        // GET: Episodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Episodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ShowName,Season,EpisodeNumber,EpisodeName,Description,BestCharacter,HumorRating,StoryRating,OverallGrade")] Episodes episodes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(episodes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(episodes);
        }

        // GET: Episodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodes = await _context.Episodes.SingleOrDefaultAsync(m => m.ID == id);
            if (episodes == null)
            {
                return NotFound();
            }
            return View(episodes);
        }

        // POST: Episodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ShowName,Season,EpisodeNumber,EpisodeName,Description,BestCharacter,HumorRating,StoryRating,OverallGrade")] Episodes episodes)
        {
            if (id != episodes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episodes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodesExists(episodes.ID))
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
            return View(episodes);
        }

        // GET: Episodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodes = await _context.Episodes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (episodes == null)
            {
                return NotFound();
            }

            return View(episodes);
        }

        // POST: Episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var episodes = await _context.Episodes.SingleOrDefaultAsync(m => m.ID == id);
            _context.Episodes.Remove(episodes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EpisodesExists(int id)
        {
            return _context.Episodes.Any(e => e.ID == id);
        }
    }
}
