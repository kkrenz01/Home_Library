using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home_Library.Data;
using Home_Library.Models;
using Microsoft.AspNetCore.Authorization;
using Home_Library.Data.Migrations;
using NuGet.Packaging.Signing;

namespace Home_Library.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _context.Game.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Developer,Publisher,Platform,ReleaseDate,Cover,CoverFile")] Game game)
        {
            if (ModelState.IsValid)
            {
                if(game.Cover != null)
                {
                    var extension = System.IO.Path.GetExtension(game.Cover.FileName);
                    var coverPath = Path.Combine("/Images/covers/games/", Guid.NewGuid().ToString() + extension);
                    var filePath = "wwwroot" + coverPath;
                    using (var stream = new FileStream(filePath, FileMode.Create)) { await game.Cover.CopyToAsync(stream); }
                    game.CoverPath = coverPath;
                }

                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string? oldCoverPath, Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (game.Cover != null)
                    {
                        var extension = System.IO.Path.GetExtension(game.Cover.FileName);
                        if (oldCoverPath != null) { System.IO.File.Delete("wwwroot" + oldCoverPath); }
                        var coverPath = Path.Combine("/Images/covers/games/", Guid.NewGuid().ToString() + extension);
                        var filePath = "wwwroot" + coverPath;
                        using (var stream = new FileStream(filePath, FileMode.Create)) { await game.Cover.CopyToAsync(stream); }
                        game.CoverPath = coverPath;
                    } else
                    {
                        game.CoverPath = oldCoverPath;
                    }

                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                if(System.IO.File.Exists("wwwroot"+game.Cover)) { System.IO.File.Delete("wwwroot" + game.CoverPath!); }
                _context.Game.Remove(game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //[HttpPoost]
        //public async Task<IActionResult> Upload()
        //{
        //    var path = 

        //}


        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
