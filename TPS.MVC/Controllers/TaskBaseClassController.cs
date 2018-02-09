using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessNew.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPS.Core.Models;

namespace TPS.MVC.Controllers
{
    public class TaskBaseClassController : Controller
    {
        private readonly DataContextNew _context;

        public TaskBaseClassController(DataContextNew context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
        
        

        public async Task<IEnumerable<LaborCharge>> GetLaborChargesForTask(Guid taskId)
        {
            return await _context.LaborCharges
                .Where(l => l.TaskBaseClassId == taskId).ToListAsync();
        }

        public async Task<IEnumerable<NonLaborCharge>> GetNonLaborChargesFortask(Guid taskId)
        {
            return await _context.NonLaborCharges
                .Where(n => n.TaskBaseClassId == taskId).ToListAsync();
        }

        public async Task<int> UpdateLaborChargesForTask(Guid taskId, IEnumerable<LaborCharge> laborCharges)
        {
            if (User.IsInRole("TaskLeader"))
            {

                foreach (var rec in laborCharges)
                {
                    _context.LaborCharges.Attach(rec);
                    _context.Entry(rec).Property(r => r.EstimatedHours).IsModified = true;

                }
                // TODO: do we need an exception handler here?
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> InsertLaborChargesForTask(Guid taskId, IEnumerable<LaborCharge> laborCharges)
        {
            if (User.IsInRole("TaskLeader"))
            {
                foreach (var rec in laborCharges)
                {
                    rec.Id = Guid.NewGuid();
                    rec.TaskBaseClassId = taskId;
                    rec.ActualHours = null;
                    rec.ChargedAmount = 0;
                    _context.Add(rec);
                }
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
        
        
    }
}