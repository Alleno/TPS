using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessNew.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPS.Core.Models;

namespace TPS.MVC.Controllers
{
    public class AmendmentsController : Controller
    {
        private readonly DataContextNew _context;

        public AmendmentsController(DataContextNew context)
        {
            _context = context;
        }
        // GET: Amendments
        public async Task<ActionResult> Index()
        {
            var amendmentsList = _context.Amendments
                .Include(a => a.TaskOrder)
                .Include(a => a.Funding)
                .AsNoTracking();

            return View(await amendmentsList.ToListAsync());
        }

        // GET: Amendments/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var amendment = await _context.Amendments
                .Include(t => t.AnticipatedAudience)
                .Include(t => t.Funding)
                .Include(t => t.VisibilityLevel)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name", amendment.AnticipatedAudienceId);
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name", amendment.VisibilityLevelId);
            ViewData["Parent Task"] = amendment.TaskOrder.Title;
            return View();
        }

        // GET: Amendments/Create
        public ActionResult Create(Guid taskOrderId, string reRoute = null)
        {
            var viewModel = new Amendment {TaskOrderId = taskOrderId};
            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name");
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name");
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name");
            ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name");
            ViewData["ReRoute"] = reRoute;
            return View(viewModel);
        }

        // POST: Amendments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Amendment amendment, string reRoute)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    amendment.Id = Guid.NewGuid();
                    _context.Add(amendment);
                    _context.SaveChangesAsync();
                }
                // TODO: Add insert logic here
                ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name", amendment.AnticipatedAudienceId);
                ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name", amendment.Funding.FundingCategoryId);
                ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name", amendment.VisibilityLevelId);
                ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name");

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch
            {
                return View();
            }
        }

        // GET: Amendments/Edit/5
        public async Task<IActionResult> Edit(Guid? id, string reRoute = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amendment = await _context.Amendments
                .Include(a => a.TaskOrder)
                .Include(a => a.Funding)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (amendment == null)
            {
                return NotFound();
            }

            ViewData["ApprovalStatus"] = new SelectList(_context.ApprovalStatuses, "Id", "Name", amendment.ApprovalStatusId);
            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name", amendment.AnticipatedAudienceId);
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name", amendment.VisibilityLevelId);
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name", amendment.Funding.FundingCategoryId);
            ViewData["Parent Task"] = amendment.TaskOrder.Title;
            return View(amendment);
        }

        // POST: Amendments/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Amendment amendment)
        {

            var amendmentToUpdate = await _context.Amendments
                    .Include(a => a.Funding)
                    .SingleOrDefaultAsync(a => a.Id == amendment.Id);
            
            if (ModelState.IsValid)
            {
                try
                {
                    await TryUpdateModelAsync<Amendment>(
                        amendmentToUpdate,
                        "",
                        s => s.Title, s => s.Abstract, s => s.Objective, s => s.ApprovalStatusId, s => s.Funding,
                        s => s.DateSignedBySponsor, s => s.DateStart, s => s.DateEnd, s => s.AnticipatedAudienceId,
                        s => s.VisibilityLevelId);
                    
                    if (amendmentToUpdate.Funding.FundingCategoryId == null)
                    {
                        amendmentToUpdate.Funding = null;
                    }

                    await _context.SaveChangesAsync();
                    return Redirect(Request.Headers["Referer"].ToString());

                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }

            ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name");
            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name", amendmentToUpdate.AnticipatedAudienceId);
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name", amendmentToUpdate.VisibilityLevelId);
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name", amendment.Funding.FundingCategoryId);
            ViewData["Parent Task"] = amendmentToUpdate.TaskOrder.Title;
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // GET: Amendments/Delete/5
        public ActionResult Delete(int id, string reRoute)
        {
            return View();
        }

        // POST: Amendments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, string reRoute)
        {
            try
            {
                // TODO: Add delete logic here

                return Redirect(reRoute);
            }
            catch
            {
                return View("Error");
            }
        }

        private bool AmendmentExists(Guid id)
        {
            return _context.Amendments.Any(e => e.Id == id);
        }
    }
}