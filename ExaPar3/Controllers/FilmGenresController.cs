using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DVDCollection.Data;
using DVDCollection.Models;

namespace DVDCollection.Controllers
{
    public class FilmGenresController : Controller
    {
        private readonly DVDContext _context;

        public FilmGenresController(DVDContext context)
        {
            _context = context;
        }

        // GET: FilmGenres
        public async Task<IActionResult> Index(string searchString)
        {
            var filmGenres = from s in _context.FilmGenres select s;
            if (!string.IsNullOrEmpty(searchString)){
                filmGenres = filmGenres.Where(c=>c.Genre.Contains(searchString));
            }
            return View(await filmGenres.ToListAsync());
        }

        // GET: FilmGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGenre = await _context.FilmGenres
                .FirstOrDefaultAsync(m => m.GenreID == id);
            if (filmGenre == null)
            {
                return NotFound();
            }

            return View(filmGenre);
        }

        // GET: FilmGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID,Genre")] FilmGenre filmGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmGenre);
        }

        // GET: FilmGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGenre = await _context.FilmGenres.FindAsync(id);
            if (filmGenre == null)
            {
                return NotFound();
            }
            return View(filmGenre);
        }

        // POST: FilmGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreID,Genre")] FilmGenre filmGenre)
        {
            if (id != filmGenre.GenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmGenreExists(filmGenre.GenreID))
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
            return View(filmGenre);
        }

        // GET: FilmGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGenre = await _context.FilmGenres
                .FirstOrDefaultAsync(m => m.GenreID == id);
            if (filmGenre == null)
            {
                return NotFound();
            }

            return View(filmGenre);
        }

        // POST: FilmGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmGenre = await _context.FilmGenres.FindAsync(id);
            _context.FilmGenres.Remove(filmGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmGenreExists(int id)
        {
            return _context.FilmGenres.Any(e => e.GenreID == id);
        }
    }
}
