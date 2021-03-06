using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokéBase.Models;

namespace PokéBase.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly PokemonContext _context;

        public PokemonsController(PokemonContext context)
        {
            _context = context;
        }

        // GET: Pokemons
        public async Task<IActionResult> Index()
        {
            return View(await _context.pokemonSet.ToListAsync());
        }

        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.pokemonSet
                .FirstOrDefaultAsync(m => m.pokeID == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // GET: Pokemons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pokeID,dexNum,name,originalTrainer")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                if (_context.trainerSet.AsNoTracking().FirstOrDefault(x => x.trainerID == pokemon.originalTrainer) == null)
                {
                    ViewData["Log"] = "This trainer does not exist";
                }
                else
                {
                    _context.Add(pokemon);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(pokemon);
        }

        // GET: Pokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.pokemonSet.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pokeID,dexNum,name,originalTrainer")] Pokemon pokemon)
        {
            if (id != pokemon.pokeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.trainerSet.AsNoTracking().FirstOrDefault(x => x.trainerID == pokemon.originalTrainer) == null)
                {
                    ViewData["Log"] = "This trainer does not exist";
                }
                else
                {
                    try
                    {
                        _context.Update(pokemon);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PokemonExists(pokemon.pokeID))
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
            }
            return View(pokemon);
        }

        // GET: Pokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.pokemonSet
                .FirstOrDefaultAsync(m => m.pokeID == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemon = await _context.pokemonSet.FindAsync(id);
            _context.pokemonSet.Remove(pokemon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return _context.pokemonSet.Any(e => e.pokeID == id);
        }
    }
}
