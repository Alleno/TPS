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
    public class DeliverablesController : Controller
    {
        private readonly DataContextNew _context;

        public DeliverablesController(DataContextNew context)
        {
            _context = context;
        }

        // GET: Deliverables
        public async Task<IActionResult> Index()
        {
            var dataContextNew = _context.Deliverables.Include(d => d.Contract).Include(d => d.Format).Include(d => d.ProductType).Include(d => d.Publication).Include(d => d.TaskBaseClass);
            return View(await dataContextNew.ToListAsync());
        }

        // GET: Deliverables/Details/5
        public async Task<IActionResult> Details(Guid? id, string reRoute)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverable = await _context.Deliverables
                .Include(d => d.Contract)
                .Include(d => d.Format)
                .Include(d => d.ProductType)
                .Include(d => d.Publication)
                .Include(d => d.TaskBaseClass)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deliverable == null)
            {
                return NotFound();
            }

            ViewData["ReRoute"] = reRoute;

            return View(deliverable);
        }

        // GET: Deliverables/Create
        public IActionResult Create(Guid? contractId)
        {
            // Needs to pass contract id when creating a deliverable, because
            // they are only created from the window of an existing contract
            var viewModel = new Deliverable {ContractId = contractId};
            ViewData["FormatId"] = new SelectList(_context.Formats, "Id", "Name");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            return View(viewModel);
        }

        // POST: Deliverables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ProductTypeId,Description,CurrentStatus,FormatId,Formal,DateEstimatedDue,DateDelivered,PublicationId,ContractId,TaskBaseClassId")] Deliverable deliverable, string reRoute = null)
        {
            if (ModelState.IsValid)
            {
                deliverable.Id = Guid.NewGuid();
                _context.Add(deliverable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), "Deliverables", new {id = deliverable.Id, reRoute });
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Abstract", deliverable.ContractId);
            ViewData["FormatId"] = new SelectList(_context.Formats, "Id", "Id", deliverable.FormatId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", deliverable.ProductTypeId);
            ViewData["PublicationId"] = new SelectList(_context.Publications, "DeliverableId", "DeliverableId", deliverable.PublicationId);
            ViewData["TaskBaseClassId"] = new SelectList(_context.TasksBase, "Id", "Discriminator", deliverable.TaskBaseClassId);
            return View(deliverable);
        }

        // GET: Deliverables/Edit/5
        public async Task<IActionResult> Edit(Guid? id, string reRoute)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverable = await _context.Deliverables.SingleOrDefaultAsync(m => m.Id == id);
            if (deliverable == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Abstract", deliverable.ContractId);
            ViewData["FormatId"] = new SelectList(_context.Formats, "Id", "Id", deliverable.FormatId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", deliverable.ProductTypeId);
            ViewData["PublicationId"] = new SelectList(_context.Publications, "DeliverableId", "DeliverableId", deliverable.PublicationId);
            ViewData["TaskBaseClassId"] = new SelectList(_context.TasksBase, "Id", "Discriminator", deliverable.TaskBaseClassId);
            return View(deliverable);
        }

        // POST: Deliverables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductTypeId,Description,CurrentStatus,FormatId,Formal,DateEstimatedDue,DateDelivered,PublicationId,ContractId,TaskBaseClassId")] Deliverable deliverable)
        {
            if (id != deliverable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliverable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliverableExists(deliverable.Id))
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
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Title", deliverable.ContractId);
            ViewData["FormatId"] = new SelectList(_context.Formats, "Id", "Name", deliverable.FormatId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", deliverable.ProductTypeId);
            ViewData["PublicationId"] = new SelectList(_context.Publications, "DeliverableId", "DeliverableId", deliverable.PublicationId);
            var relevantTasks = new List<TaskBaseClass> {_context.Tasks.Find()};
            //ViewData["TaskBaseClassId"] = new SelectList(_context.Tasks.Select(t => t.), "Id", "Title", deliverable.TaskBaseClassId);
            return View(deliverable);
        }

        // GET: Deliverables/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverable = await _context.Deliverables
                .Include(d => d.Contract)
                .Include(d => d.Format)
                .Include(d => d.ProductType)
                .Include(d => d.Publication)
                .Include(d => d.TaskBaseClass)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (deliverable == null)
            {
                return NotFound();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: Deliverables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deliverable = await _context.Deliverables.SingleOrDefaultAsync(m => m.Id == id);
            _context.Deliverables.Remove(deliverable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliverableExists(Guid id)
        {
            return _context.Deliverables.Any(e => e.Id == id);
        }
    }
}
