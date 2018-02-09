using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.XpressionMapper.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessNew.Data;
using TPS.Core.Models;
using TPS.MVC.Models;

namespace TPS.MVC.Controllers
{
    public class TaskOrdersController : Controller
    {
        private readonly DataContextNew _context;

        public TaskOrdersController(DataContextNew context)
        {
            _context = context;
        }

        // GET: TaskOrders
        public async Task<IActionResult> Index()
        {


            var dataContextNew = _context.TaskOrders
                .Include(t => t.ApprovalStatus)
                .Include(t => t.Sponsor)
                .Include(t => t.Amendments)
                .Include(t => t.Funding)
                .AsNoTracking();
           
            return View(await dataContextNew.ToListAsync());
        }

        // GET: TaskOrders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskOrder = await _context.TaskOrders
                .Include(t => t.AnticipatedAudience)
                .Include(t => t.Funding)
                .Include(t => t.VisibilityLevel)
                .Include(t => t.ApprovalStatus)
                .Include(t => t.Sponsor)
                .Include(t => t.Amendments)
                    .ThenInclude(a => a.Deliverables)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taskOrder == null)
            {
                return NotFound();
            }

            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name");
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name");
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name");
            ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name");
            ViewData["SponsorId"] = new SelectList(_context.Sponsors, "Id", "Name");

            return View(taskOrder);
        }

        // GET: TaskOrders/Create
        public IActionResult Create()
        {
            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name");
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name");
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name");
            ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name");
            ViewData["SponsorId"] = new SelectList(_context.Sponsors, "Id", "Name");
            return View();
        }

        // POST: TaskOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SponsorId,ApprovalStatusId,DateApproval,DatePlacedOnContract,Id,Title,Abstract,Objective,TaskNumber,Status,ProjectNumber,Funding.FundingAmount,Funding.FundingCategoryId,DateSignedBySponsor,DateStart,DateEnd,AnticipatedAudienceId,VisibilityLevelId")] TaskOrder taskOrder)
        {
            
            if (ModelState.IsValid)
            {
                taskOrder.Id = Guid.NewGuid();
                _context.Add(taskOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name", taskOrder.AnticipatedAudienceId);
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name", taskOrder.Funding.FundingCategoryId);
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name", taskOrder.VisibilityLevelId);
            ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name", taskOrder.ApprovalStatusId);
            ViewData["SponsorId"] = new SelectList(_context.Sponsors, "Id", "Name", taskOrder.SponsorId);
            return View(taskOrder);
        }

        // GET: TaskOrders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskOrder = await _context.TaskOrders
                .Include(t => t.Funding)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taskOrder == null)
            {
                return NotFound();
            }
            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name", taskOrder.AnticipatedAudienceId);
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name", taskOrder.Funding.FundingCategoryId);
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name", taskOrder.VisibilityLevelId);
            ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name", taskOrder.ApprovalStatusId);
            ViewData["SponsorId"] = new SelectList(_context.Sponsors, "Id", "Name", taskOrder.SponsorId);
            return View(taskOrder);
        }

        // POST: TaskOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskOrderToUpdate = await _context.TaskOrders
                .Include(t => t.Funding)
                .SingleOrDefaultAsync(t => t.Id == id);
            if (await TryUpdateModelAsync<TaskOrder>(taskOrderToUpdate, 
                "",
                t => t.SponsorId,
                t => t.ApprovalStatusId,
                t => t.DateApproval,
                t => t.DatePlacedOnContract,
                t => t.Title,
                t => t.Abstract,
                t => t.Objective,
                t => t.TaskNumber,
                t => t.ApprovalStatus,
                t => t.ProjectNumber,
                t => t.Funding,
                t => t.DateSignedBySponsor,
                t => t.DateStart,
                t => t.DateEnd,
                t => t.AnticipatedAudienceId,
                t => t.VisibilityLevelId))
            {
                if (taskOrderToUpdate.Funding.FundingCategoryId == null)
                {
                    taskOrderToUpdate.Funding = null;
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes, try again. If the problem" +
                                                 "persists, see your system administrator");
                }
                return RedirectToAction(nameof(Details), id);
            }

  
            ViewData["AnticipatedAudienceId"] = new SelectList(_context.AnticipatedAudiences, "Id", "Name", taskOrderToUpdate.AnticipatedAudienceId);
            ViewData["FundingCategoryId"] = new SelectList(_context.FundingCategories, "Id", "Name", taskOrderToUpdate.Funding.FundingCategoryId);
            ViewData["VisibilityLevelId"] = new SelectList(_context.VisibilityLevels, "Id", "Name", taskOrderToUpdate.VisibilityLevelId);
            ViewData["ApprovalStatusId"] = new SelectList(_context.ApprovalStatuses, "Id", "Name", taskOrderToUpdate.ApprovalStatusId);
            ViewData["SponsorId"] = new SelectList(_context.Sponsors, "Id", "Name", taskOrderToUpdate.SponsorId);
            return View(taskOrderToUpdate);
        }

        // GET: TaskOrders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskOrder = await _context.TaskOrders
                .Include(t => t.AnticipatedAudience)
                .Include(t => t.Funding)
                .Include(t => t.VisibilityLevel)
                .Include(t => t.ApprovalStatus)
                .Include(t => t.Sponsor)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taskOrder == null)
            {
                return NotFound();
            }

            return View(taskOrder);
        }

        // POST: TaskOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var taskOrder = await _context.TaskOrders.SingleOrDefaultAsync(m => m.Id == id);
            _context.TaskOrders.Remove(taskOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskOrderExists(Guid id)
        {
            return _context.TaskOrders.Any(e => e.Id == id);
        }
    }
}
