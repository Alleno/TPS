using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPS.Core.Models;
using Task = System.Threading.Tasks.Task;

namespace TPS.Core.Interfaces
{
    // This class is mostly for calculating useful quantities after having
    // moved 
    public interface IBusinessLogicService
    {
        //Generate funds remaining for a task, CRP or Project as a time series
        Task<SortedDictionary<DateTime, decimal>> GenerateTaskFundsTimeSeries(Guid id);

        //Funds remaining (to date)
        Task<Decimal> FundsRemaining(Guid id);

        // Tasks, subtasks, and CRPs
        Task<TaskBaseClass> GetTask(Guid id);

        Task<bool> AddTask(Models.Task task);
        Task<bool> AddSubTask(SubTask subtask);
        Task<bool> AddCRP(CRP crp);

        Task<bool> UpdateTask(Models.Task task);
        Task<bool> UpdateSubTask(SubTask subtask);
        Task<bool> UpdateCRP(CRP crp);

        Task<bool> DeleteTask(Guid id);
        Task<bool> DeleteSubTask(Guid taskId);
        Task<bool> DeleteCRP(Guid id);

    }
}