using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessNew.Data;
using TPS.Core.Models;

namespace TPS.MVC.Controllers
{
    public class FundingCategoriesController : Controller
    {
        private readonly DataContextNew _context;

        public FundingCategoriesController(DataContextNew context)
        {
            _context = context;
        }

        // GET: FundingCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.FundingCategories.ToListAsync());
        }

        // GET: FundingCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundingCategory = await _context.FundingCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fundingCategory == null)
            {
                return NotFound();
            }

            return View(fundingCategory);
        }

        // GET: FundingCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FundingCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FundingCategory fundingCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fundingCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundingCategory);
        }

        // GET: FundingCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundingCategory = await _context.FundingCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (fundingCategory == null)
            {
                return NotFound();
            }
            return View(fundingCategory);
        }

        // POST: FundingCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FundingCategory fundingCategory)
        {
            if (id != fundingCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundingCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundingCategoryExists(fundingCategory.Id))
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
            return View(fundingCategory);
        }

        // GET: FundingCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundingCategory = await _context.FundingCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fundingCategory == null)
            {
                return NotFound();
            }

            return View(fundingCategory);
        }

        // POST: FundingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fundingCategory = await _context.FundingCategories.SingleOrDefaultAsync(m => m.Id == id);
            _context.FundingCategories.Remove(fundingCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundingCategoryExists(int id)
        {
            return _context.FundingCategories.Any(e => e.Id == id);
        }
    }
}
