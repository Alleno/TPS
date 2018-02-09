using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TPS.Core.Models;

namespace TPS.Core.Interfaces
{
    // Taken from https://codereview.stackexchange.com/questions/27598/following-repository-pattern-properly

    interface IRepository<T>
    {
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);



        void Insert(T entity);
        void Delete(T entity);
        void InsertMany(IEnumerable<T> entities);
        void DeleteMany(IEnumerable<T> entities);
        
    }

    interface IEditableRepository<T> : IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
    }


    public interface IDataService
    {
        // Tasks, subtasks, and CRPs
        Task<TaskBaseClass> GetTaskBaseClass(Guid id);
        Task<Models.Task> GetTask(Guid id);
        Task<SubTask> GetSubTask(Guid id);
        Task<CRP> GetCRP(Guid id);

        Task<bool> AddTask(Models.Task task);
        Task<bool> AddSubTask(SubTask subtask);
        Task<bool> AddCRP(CRP crp);

        Task<bool> UpdateTask(Models.Task task);
        Task<bool> UpdateSubTask(SubTask subtask);
        Task<bool> UpdateCRP(CRP crp);

        Task<bool> DeleteTask(Guid id);
        Task<bool> DeleteSubTask(Guid taskId);
        Task<bool> DeleteCRP(Guid id);

        // Contracts (Amendments and Task Orders)
        Task<TaskOrder> GetTaskOrder(Guid id);
        Task<Amendment> GetAmendment(Guid id);

        Task<bool> AddTaskOrder(TaskOrder taskOrder);
        Task<bool> AddAmendment(Amendment amendment);

        Task<bool> DeleteTaskOrder(Guid id);
        Task<bool> DeleteAmendment(Guid id);

        //Deliverables
        Task<bool> AddDeliverable(Deliverable deliverable);
        Task<bool> UpdateDeliverable(Deliverable deliverable);
        Task<bool> DeleteDeliverable(Guid id);

        //Publications


        //Labor Charges
        Task<int> AddLaborCharges(IEnumerable<LaborCharge> laborCharges);
        Task<int> AddNonLaborCharges(IEnumerable<NonLaborCharge> nonLaborCharges);

        Task<int> UpdateLaborCharges(IEnumerable<LaborCharge> laborCharges);
        Task<int> UpdateNonLaborCharges(IEnumerable<NonLaborCharge> nonLaborCharges);

        Task<int> DeleteLaborCharges(IEnumerable<Guid> ids);
        Task<int> DeleteNonLaborCharges(IEnumerable<Guid> ids);



    }
}
