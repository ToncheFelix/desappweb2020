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
    public class FilmTitlesProducersController : Controller
    {
        private readonly DVDContext _context;

        public FilmTitlesProducersController(DVDContext context)
        {
            _context = context;
        }

        // GET: FilmTitlesProducers
        public async Task<IActionResult> Index(string searchString)
        {
            var filmTitlesProducers = from s in _context.FilmTitlesProducers.Include(f => f.FilmTitle).Include(f => f.Producer) select s;
            if (!string.IsNullOrEmpty(searchString)){
                filmTitlesProducers = filmTitlesProducers.Where(c=>c.Producer.ProducerName.Contains(searchString)
                || c.FilmTitle.FilmTitles.Contains(searchString));
            }
            //var dVDContext = _context.FilmTitlesProducers.Include(f => f.FilmTitle).Include(f => f.Producer);
            return View(await filmTitlesProducers.ToListAsync());
        }

        // GET: FilmTitlesProducers/Details/5
        public async Task<IActionResult> Details(int? id, int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitlesProducer = await _context.FilmTitlesProducers
                .Include(f => f.FilmTitle)
                .Include(f => f.Producer)
                .FirstOrDefaultAsync(m => m.ProducerID == id && m.FilmTitleID == id2);
            if (filmTitlesProducer == null)
            {
                return NotFound();
            }

            return View(filmTitlesProducer);
        }

        // GET: FilmTitlesProducers/Create
        public IActionResult Create()
        {
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmTitles");
            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ProducerName");
            return View();
        }

        // POST: FilmTitlesProducers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProducerID,FilmTitleID")] FilmTitlesProducer filmTitlesProducer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmTitlesProducer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmTitles", filmTitlesProducer.FilmTitleID);
            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ProducerName", filmTitlesProducer.ProducerID);
            return View(filmTitlesProducer);
        }

        // GET: FilmTitlesProducers/Edit/5
        public async Task<IActionResult> Edit(int? id,int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitlesProducer = await _context.FilmTitlesProducers.FindAsync(id,id2);
            if (filmTitlesProducer == null)
            {
                return NotFound();
            }
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmAdditionalInfo", filmTitlesProducer.FilmTitleID);
            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ContactEmailAddress", filmTitlesProducer.ProducerID);
            return View(filmTitlesProducer);
        }

        // POST: FilmTitlesProducers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProducerID,FilmTitleID")] FilmTitlesProducer filmTitlesProducer)
        {
            if (id != filmTitlesProducer.ProducerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmTitlesProducer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmTitlesProducerExists(filmTitlesProducer.ProducerID))
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
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmAdditionalInfo", filmTitlesProducer.FilmTitleID);
            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ContactEmailAddress", filmTitlesProducer.ProducerID);
            return View(filmTitlesProducer);
        }

        // GET: FilmTitlesProducers/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitlesProducer = await _context.FilmTitlesProducers
                .Include(f => f.FilmTitle)
                .Include(f => f.Producer)
                .FirstOrDefaultAsync(m => m.ProducerID == id && m.FilmTitleID == id2);
            if (filmTitlesProducer == null)
            {
                return NotFound();
            }

            return View(filmTitlesProducer);
        }

        // POST: FilmTitlesProducers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProducerID, int FilmTitleID)
        {
            var filmTitlesProducer = await _context.FilmTitlesProducers.FindAsync(ProducerID,FilmTitleID);
            _context.FilmTitlesProducers.Remove(filmTitlesProducer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmTitlesProducerExists(int id)
        {
            return _context.FilmTitlesProducers.Any(e => e.ProducerID == id);
        }
    }
}
