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
    public class FilmCertificatesController : Controller
    {
        private readonly DVDContext _context;

        public FilmCertificatesController(DVDContext context)
        {
            _context = context;
        }

        // GET: FilmCertificates
        public async Task<IActionResult> Index(string searchString)
        {
            var filmCertificates = from s in _context.FilmCertificates select s;
            if (!string.IsNullOrEmpty(searchString)){
                filmCertificates = filmCertificates.Where(c=>c.Certificate.Contains(searchString));
            }
            return View(await filmCertificates.ToListAsync());
        }

        // GET: FilmCertificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmCertificate = await _context.FilmCertificates
                .FirstOrDefaultAsync(m => m.CertificateID == id);
            if (filmCertificate == null)
            {
                return NotFound();
            }

            return View(filmCertificate);
        }

        // GET: FilmCertificates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificateID,Certificate")] FilmCertificate filmCertificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmCertificate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmCertificate);
        }

        // GET: FilmCertificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmCertificate = await _context.FilmCertificates.FindAsync(id);
            if (filmCertificate == null)
            {
                return NotFound();
            }
            return View(filmCertificate);
        }

        // POST: FilmCertificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificateID,Certificate")] FilmCertificate filmCertificate)
        {
            if (id != filmCertificate.CertificateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmCertificate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmCertificateExists(filmCertificate.CertificateID))
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
            return View(filmCertificate);
        }

        // GET: FilmCertificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmCertificate = await _context.FilmCertificates
                .FirstOrDefaultAsync(m => m.CertificateID == id);
            if (filmCertificate == null)
            {
                return NotFound();
            }

            return View(filmCertificate);
        }

        // POST: FilmCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmCertificate = await _context.FilmCertificates.FindAsync(id);
            _context.FilmCertificates.Remove(filmCertificate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmCertificateExists(int id)
        {
            return _context.FilmCertificates.Any(e => e.CertificateID == id);
        }
    }
}
