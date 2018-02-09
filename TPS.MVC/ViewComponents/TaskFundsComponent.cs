using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DataAccessNew.Data;
using Microsoft.AspNetCore.Mvc;
using TPS.Core.Interfaces;
using TPS.MVC.Models;

namespace TPS.MVC.ViewComponents
{
    public class TaskFundsViewComponent : ViewComponent
    {
        private readonly IBusinessLogicService _businessLogicService;

        public TaskFundsViewComponent(IBusinessLogicService businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(Guid taskId)
        {
            return View(await _businessLogicService.GenerateTaskFundsTimeSeries(taskId));
        }
    }
}
