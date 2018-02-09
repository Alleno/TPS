using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessOld.Data;
using DataAccessOld.OriginalModels;

namespace TPS.MVC.Controllers
{
    public class CRPsController : Controller
    {
        private readonly DataContextOld _context;

        public CRPsController(DataContextOld context)
        {
            _context = context;
        }

        // GET: CRPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CRPOriginal.ToListAsync());
        }

        // GET: CRPs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRP = await _context.CRPOriginal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cRP == null)
            {
                return NotFound();
            }

            return View(cRP);
        }

        // GET: CRPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CRPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Active,Level")] CRP cRP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cRP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cRP);
        }

        // GET: CRPs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRP = await _context.CRPOriginal.SingleOrDefaultAsync(m => m.Id == id);
            if (cRP == null)
            {
                return NotFound();
            }
            return View(cRP);
        }

        // POST: CRPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Active,Level")] CRP cRP)
        {
            if (id != cRP.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cRP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CRPExists(cRP.Id))
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
            return View(cRP);
        }

        // GET: CRPs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRP = await _context.CRPOriginal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cRP == null)
            {
                return NotFound();
            }

            return View(cRP);
        }

        // POST: CRPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cRP = await _context.CRPOriginal.SingleOrDefaultAsync(m => m.Id == id);
            _context.CRPOriginal.Remove(cRP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CRPExists(string id)
        {
            return _context.CRPOriginal.Any(e => e.Id == id);
        }
    }
}
