using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPS.Core.Interfaces;
using TPS.Core.Models;
using Task = System.Threading.Tasks.Task;

namespace TPS.Core.Services
{
    class BusinessLogicService : IBusinessLogicService
    {
        private readonly IDataService _dataService;

        public BusinessLogicService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<SortedDictionary<DateTime, decimal>> GenerateTaskFundsTimeSeries(Guid id)
        {
            // GetTaskBaseClass should not include funding, since base class type doesn't
            // include funding amounts, rather the task order does
            var taskBaseClass = await _dataService.GetTaskBaseClass(id);

            if (taskBaseClass.GetType() == typeof(Models.Task))
            {
                var task = (Models.Task) taskBaseClass;
                if (task.TaskOrder.DateStart == null)
                {
                    return new SortedDictionary<DateTime, decimal>();
                }

                var taskOrderId = task.TaskOrderId;

                var taskOrder = await _dataService.GetTaskOrder(taskOrderId);
                
              
                var cashFlows = new SortedDictionary<DateTime, decimal>
                {
                    [(DateTime)task.TaskOrder.DateStart] = task.TaskOrder.FundingAmount
                };
                foreach (var amendment in task.TaskOrder.Amendments.Where(a => a.DateStart != null))
                {
                    cashFlows[(DateTime) amendment.DateStart] = amendment.FundingAmount;
                }

                foreach (var laborCharge in task.LaborCharges)
                {
                    cashFlows[laborCharge.Date] = -laborCharge.ChargedAmount;
                }

                foreach (var nonLaborCharge in task.NonLaborCharges.Where(c => c.ActualDate != null))
                {
                    cashFlows[(DateTime)nonLaborCharge.ActualDate] = -nonLaborCharge.ChargedAmount;
                }

                var total = (decimal)0.0;
                var res = new SortedDictionary<DateTime, decimal>();

                foreach (KeyValuePair<DateTime, decimal> cashFlow in cashFlows)
                {
                    total += cashFlow.Value;
                    res[cashFlow.Key] = total;
                }
                return res;
            }

            else if (taskBaseClass.GetType() == typeof(SubTask))
            {
                
            }
        }

        public SortedDictionary<DateTime, decimal> GenerateTaskFundsTimeSeries(SubTask task)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<DateTime, decimal> GenerateTaskFundsTimeSeries(CRP task)
        {
            throw new NotImplementedException();
        }

        public decimal FundsRemaining(SortedDictionary<DateTime, decimal> taskFundsTimeSeries)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Task> GetTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SubTask> GetSubTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<CRP> GetCRP(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTask(Models.Task task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddSubTask(SubTask subtask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddCRP(CRP crp)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTask(Models.Task task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubTask(SubTask subtask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCRP(CRP crp)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCRP(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
