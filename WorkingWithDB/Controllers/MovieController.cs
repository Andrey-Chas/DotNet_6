using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkingWithDB.Data;
using WorkingWithDB.Models;

namespace WorkingWithDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly WorkingWithDBContext appDbContext;

        public MovieController(WorkingWithDBContext context)
        {
            appDbContext = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
              return appDbContext.Movie != null ? 
                          View(await appDbContext.Movie.ToListAsync()) :
                          Problem("Entity set 'WorkingWithDBContext.Movie'  is null.");
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || appDbContext.Movie == null)
            {
                return NotFound();
            }

            var movie = await appDbContext.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                appDbContext.Add(movie);
                await appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || appDbContext.Movie == null)
            {
                return NotFound();
            }

            var movie = await appDbContext.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    appDbContext.Update(movie);
                    await appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || appDbContext.Movie == null)
            {
                return NotFound();
            }

            var movie = await appDbContext.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (appDbContext.Movie == null)
            {
                return Problem("Entity set 'WorkingWithDBContext.Movie'  is null.");
            }
            var movie = await appDbContext.Movie.FindAsync(id);
            if (movie != null)
            {
                appDbContext.Movie.Remove(movie);
            }
            
            await appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (appDbContext.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
