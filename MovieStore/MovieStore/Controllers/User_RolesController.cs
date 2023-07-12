using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class User_RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public User_RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User_Roles
        public async Task<IActionResult> Index()
        {
              return _context.User_Roles != null ? 
                          View(await _context.User_Roles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.User_Roles'  is null.");
        }

        // GET: User_Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User_Roles == null)
            {
                return NotFound();
            }

            var user_Roles = await _context.User_Roles
                .FirstOrDefaultAsync(m => m.role_id == id);
            if (user_Roles == null)
            {
                return NotFound();
            }

            return View(user_Roles);
        }

        // GET: User_Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("role_id,role_name")] User_Roles user_Roles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_Roles);
        }

        // GET: User_Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User_Roles == null)
            {
                return NotFound();
            }

            var user_Roles = await _context.User_Roles.FindAsync(id);
            if (user_Roles == null)
            {
                return NotFound();
            }
            return View(user_Roles);
        }

        // POST: User_Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("role_id,role_name")] User_Roles user_Roles)
        {
            if (id != user_Roles.role_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_RolesExists(user_Roles.role_id))
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
            return View(user_Roles);
        }

        // GET: User_Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User_Roles == null)
            {
                return NotFound();
            }

            var user_Roles = await _context.User_Roles
                .FirstOrDefaultAsync(m => m.role_id == id);
            if (user_Roles == null)
            {
                return NotFound();
            }

            return View(user_Roles);
        }

        // POST: User_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User_Roles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User_Roles'  is null.");
            }
            var user_Roles = await _context.User_Roles.FindAsync(id);
            if (user_Roles != null)
            {
                _context.User_Roles.Remove(user_Roles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_RolesExists(int id)
        {
          return (_context.User_Roles?.Any(e => e.role_id == id)).GetValueOrDefault();
        }
    }
}
