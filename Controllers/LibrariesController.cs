using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home_Library.Data;
using Home_Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Home_Library.Controllers
{
    [Authorize]
    public class LibrariesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LibrariesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Libraries
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity!.Name!).Result!;

            return View(await _context.Library.Where(lib => lib.UserId == user.Id)
                .ToListAsync());
        }

        // GET: Libraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library
                .FirstOrDefaultAsync(m => m.Id == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // GET: Libraries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Library library)
        {
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity!.Name!).Result!;
            library.UserId = user.Id;

            if (ModelState.IsValid)
            {
                _context.Add(library);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(library);
        }

        // GET: Libraries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Library library)
        {
            if (id != library.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(library);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryExists(library.Id))
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
            return View(library);
        }

        // GET: Libraries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library
                .FirstOrDefaultAsync(m => m.Id == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // POST: Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var library = await _context.Library.FindAsync(id);
            if (library != null)
            {
                _context.Library.Remove(library);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> List(int? id, string Style)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FindAsync(id);

            //var query = from game in _context.Game
            //            where game.Libraries.Any(l=>l.Id==library.Id)
            //            select game;

            var query = _context.Game
                .Where(g => g.Libraries!
                    .Any(library => library.Id == id))
                .ToList();
            //ViewData["gameList"] = query;

            var libraryVM = new LibraryViewModel
            {
                Id = library!.Id,
                Name = library!.Name,
                Description = library?.Description,
                Games = query,
                Style = Style
            };

            return View(libraryVM);
        }

        public async Task<IActionResult> Assign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FindAsync(id);

            var query_all = _context.Game
                .Where(g => g.Libraries!
                    .Any(library => library.Id == id));

            var query = _context.Game
                .Except(query_all)
                .ToList();
            //ViewData["gameList"] = query;

            var libraryVM = new LibraryViewModel
            {
                Id = library!.Id,
                Name = library!.Name,
                Description = library?.Description,
                Games = query
            };

            return View(libraryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(int? id, int[] selectedItemIds)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FindAsync(id);
            foreach (var itemId in selectedItemIds)
            {
                var game = await _context.Game.FindAsync(itemId);
                if (game != null)
                {
                    library!.Games!.Add(game);
                }
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(List), new { id = id });
        }

        public async Task<IActionResult> Unassign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FindAsync(id);

            var query = _context.Game
                .Where(g => g.Libraries!
                    .Any(library => library.Id == id))
                .ToList();
            //ViewData["gameList"] = query;

            var libraryVM = new LibraryViewModel
            {
                Id = library!.Id,
                Name = library!.Name,
                Description = library?.Description,
                Games = query
            };

            return View(libraryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Unassign(int id, int[] selectedItemIds)
        {
            //var library = await _context.Library.FindAsync(libraryId);
            var library = await _context.Library.Include(library => library.Games).SingleOrDefaultAsync(library => library.Id == id);
            foreach (var itemId in selectedItemIds)
            {
                var game = await _context.Game.FindAsync(itemId);
                if (game != null)
                {
                    library!.Games!.Remove(game);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(List), new { id = id });
        }

        private bool LibraryExists(int id)
        {
            return _context.Library.Any(e => e.Id == id);
        }
    }
}
