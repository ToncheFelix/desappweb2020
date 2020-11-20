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
    public class FilmsActorRolsController : Controller
    {
        private readonly DVDContext _context;

        public FilmsActorRolsController(DVDContext context)
        {
            _context = context;
        }

        // GET: FilmsActorRols
        public async Task<IActionResult> Index(string searchString)
        {
            var filmsActorRols = from s in _context.FilmsActorRols.Include(f => f.Actor).Include(f => f.FilmTitle).Include(f => f.RoleType) select s;
            if (!string.IsNullOrEmpty(searchString)){
                filmsActorRols = filmsActorRols.Where(c=>c.CharacterName.Contains(searchString));
            }
            //var dVDContext = _context.FilmsActorRols.Include(f => f.Actor).Include(f => f.FilmTitle).Include(f => f.RoleType);
            return View(await filmsActorRols.ToListAsync());
        }

        // GET: FilmsActorRols/Details/5
        public async Task<IActionResult> Details(int? id, int? id2, int? id3)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmsActorRol = await _context.FilmsActorRols
                .Include(f => f.Actor)
                .Include(f => f.FilmTitle)
                .Include(f => f.RoleType)
                .FirstOrDefaultAsync(m => m.FilmTitleID == id && m.ActorID == id2 && m.RoleTypeID == id3);
            if (filmsActorRol == null)
            {
                return NotFound();
            }

            return View(filmsActorRol);
        }

        // GET: FilmsActorRols/Create
        public IActionResult Create()
        {
            ViewData["ActorID"] = new SelectList(_context.Actors, "ActorID", "ActorFullName");
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmTitles");
            ViewData["RoleTypeID"] = new SelectList(_context.RoleTypes, "RoleTypeID", "RoleTypes");
            return View();
        }

        // POST: FilmsActorRols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmTitleID,ActorID,RoleTypeID,CharacterName,CharacterDescription")] FilmsActorRol filmsActorRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmsActorRol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorID"] = new SelectList(_context.Actors, "ActorID", "ActorFullName", filmsActorRol.ActorID);
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmAdditionalInfo", filmsActorRol.FilmTitleID);
            ViewData["RoleTypeID"] = new SelectList(_context.RoleTypes, "RoleTypeID", "RoleTypes", filmsActorRol.RoleTypeID);
            return View(filmsActorRol);
        }

        // GET: FilmsActorRols/Edit/5
        public async Task<IActionResult> Edit(int? id, int? id2, int? id3)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmsActorRol = await _context.FilmsActorRols.FindAsync(id,id2,id3);
            if (filmsActorRol == null)
            {
                return NotFound();
            }
            ViewData["ActorID"] = new SelectList(_context.Actors, "ActorID", "ActorFullName", filmsActorRol.ActorID);
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmAdditionalInfo", filmsActorRol.FilmTitleID);
            ViewData["RoleTypeID"] = new SelectList(_context.RoleTypes, "RoleTypeID", "RoleTypes", filmsActorRol.RoleTypeID);
            return View(filmsActorRol);
        }

        // POST: FilmsActorRols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmTitleID,ActorID,RoleTypeID,CharacterName,CharacterDescription")] FilmsActorRol filmsActorRol)
        {
            if (id != filmsActorRol.FilmTitleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmsActorRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmsActorRolExists(filmsActorRol.ActorID))
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
            ViewData["ActorID"] = new SelectList(_context.Actors, "ActorID", "ActorFullName", filmsActorRol.ActorID);
            ViewData["FilmTitleID"] = new SelectList(_context.FilmTitles, "FilmTitleID", "FilmAdditionalInfo", filmsActorRol.FilmTitleID);
            ViewData["RoleTypeID"] = new SelectList(_context.RoleTypes, "RoleTypeID", "RoleTypes", filmsActorRol.RoleTypeID);
            return View(filmsActorRol);
        }

        // GET: FilmsActorRols/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2, int? id3)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmsActorRol = await _context.FilmsActorRols
                .Include(f => f.Actor)
                .Include(f => f.FilmTitle)
                .Include(f => f.RoleType)
                .FirstOrDefaultAsync(m => m.FilmTitleID == id && m.ActorID == id2 && m.RoleTypeID == id3);
            if (filmsActorRol == null)
            {
                return NotFound();
            }

            return View(filmsActorRol);
        }

        // POST: FilmsActorRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int FilmTitleID,int ActorID,int RoleTypeID)
        {
            var filmsActorRol = await _context.FilmsActorRols.FindAsync(FilmTitleID,ActorID,RoleTypeID);
            _context.FilmsActorRols.Remove(filmsActorRol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmsActorRolExists(int id)
        {
            return _context.FilmsActorRols.Any(e => e.FilmTitleID == id);
        }
    }
}
