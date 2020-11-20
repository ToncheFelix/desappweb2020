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
    public class FilmTitlesController : Controller
    {
        private readonly DVDContext _context;

        public FilmTitlesController(DVDContext context)
        {
            _context = context;
        }

        // GET: FilmTitles
        public async Task<IActionResult> Index(string searchString)
        {
            var filmTitles = from s in _context.FilmTitles.Include(f => f.FilmCertificate).Include(f => f.FilmGenre) select s;
             if (!string.IsNullOrEmpty(searchString)){
                filmTitles = filmTitles.Where(c=>c.FilmTitles.Contains(searchString));
            }
            //var dVDContext = _context.FilmTitles.Include(f => f.FilmCertificate).Include(f => f.FilmGenre);
            return View(await filmTitles.ToListAsync());
        }
        

        // GET: FilmTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitle = await _context.FilmTitles
                .Include(f => f.FilmCertificate)
                .Include(f => f.FilmGenre)
                .FirstOrDefaultAsync(m => m.FilmTitleID == id);
            if (filmTitle == null)
            {
                return NotFound();
            }

            return View(filmTitle);
        }

        // GET: FilmTitles/Create
        public IActionResult Create()
        {
            ViewData["CertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "Certificate");
            ViewData["GenreID"] = new SelectList(_context.FilmGenres, "GenreID", "Genre");
            return View();
        }

        // POST: FilmTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmTitleID,FilmTitles,FilmStory,FilmReleaseDate,FilmDuration,GenreID,CertificateID,FilmAdditionalInfo")] FilmTitle filmTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "Certificate", filmTitle.CertificateID);
            ViewData["GenreID"] = new SelectList(_context.FilmGenres, "GenreID", "Genre", filmTitle.GenreID);
            return View(filmTitle);
        }

        // GET: FilmTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitle = await _context.FilmTitles.FindAsync(id);
            if (filmTitle == null)
            {
                return NotFound();
            }
            ViewData["CertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "Certificate", filmTitle.CertificateID);
            ViewData["GenreID"] = new SelectList(_context.FilmGenres, "GenreID", "Genre", filmTitle.GenreID);
            return View(filmTitle);
        }

        // POST: FilmTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmTitleID,FilmTitles,FilmStory,FilmReleaseDate,FilmDuration,GenreID,CertificateID,FilmAdditionalInfo")] FilmTitle filmTitle)
        {
            if (id != filmTitle.FilmTitleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmTitleExists(filmTitle.FilmTitleID))
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
            ViewData["CertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "Certificate", filmTitle.CertificateID);
            ViewData["GenreID"] = new SelectList(_context.FilmGenres, "GenreID", "Genre", filmTitle.GenreID);
            return View(filmTitle);
        }

        // GET: FilmTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitle = await _context.FilmTitles
                .Include(f => f.FilmCertificate)
                .Include(f => f.FilmGenre)
                .FirstOrDefaultAsync(m => m.FilmTitleID == id);
            if (filmTitle == null)
            {
                return NotFound();
            }

            return View(filmTitle);
        }

        // POST: FilmTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmTitle = await _context.FilmTitles.FindAsync(id);
            _context.FilmTitles.Remove(filmTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmTitleExists(int id)
        {
            return _context.FilmTitles.Any(e => e.FilmTitleID == id);
        }
    }
}
