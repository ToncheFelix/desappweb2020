using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservacionesHotel.Data;
using ReservacionesHotel.Models;

namespace ReservacionesHotel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly Context _context;

        public RoomsController(Context context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var context = _context.Rooms.Include(r => r.RoomBand).Include(r => r.RoomPrice).Include(r => r.RoomType);
            return View(await context.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.RoomBand)
                .Include(r => r.RoomPrice)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoombandID", "RoombandID");
            ViewData["RoomPriceID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID");
            ViewData["RoomTypeID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomID,RoomTypeID,RoomBandID,RoomPriceID,Floor,AdditionalNotes")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoombandID", "RoombandID", room.RoomBandID);
            ViewData["RoomPriceID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID", room.RoomPriceID);
            ViewData["RoomTypeID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID", room.RoomTypeID);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoombandID", "RoombandID", room.RoomBandID);
            ViewData["RoomPriceID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID", room.RoomPriceID);
            ViewData["RoomTypeID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID", room.RoomTypeID);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomID,RoomTypeID,RoomBandID,RoomPriceID,Floor,AdditionalNotes")] Room room)
        {
            if (id != room.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomID))
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
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoombandID", "RoombandID", room.RoomBandID);
            ViewData["RoomPriceID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID", room.RoomPriceID);
            ViewData["RoomTypeID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID", room.RoomTypeID);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.RoomBand)
                .Include(r => r.RoomPrice)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomID == id);
        }
    }
}
