using Microsoft.AspNetCore.JsonPatch;
using ToDo.Data.Entities;
using ToDo.Data.UoW;
using ToDo.Services.Exceptions;

namespace ToDo.Services.Impl
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _uow;

        public ToDoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            activity.CreatedAt = DateTime.Now;
            await _uow.ToDoRepository.AddAsync(activity);
            await _uow.CommitAsync();
            return activity;
        }

        public async Task<int> DeleteActivityAsync(int Id)
        {
            var activity = await _uow.ToDoRepository.FirstOrDefaultAsync(x => x.Id == Id);
            if (activity == null)
                throw new EntityNotFoundException("ToDo Item not found");
            _uow.ToDoRepository.Delete(activity);
            return await _uow.CommitAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int Id)
        {
            var activity = await _uow.ToDoRepository.FirstOrDefaultAsync(x => x.Id == Id);
            if (activity == null)
                return null;
            return activity;
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return await _uow.ToDoRepository.GetAllAsync();
        }

        public async Task<Activity> UpdateActivityAsync(int Id, Activity model)
        {
            var activity = await _uow.ToDoRepository.FirstOrDefaultAsync(x => x.Id == Id);
            if (activity == null)
                throw new EntityNotFoundException("Activity");
            activity.Completed = model.Completed;
            activity.Name = model.Name;
            activity.UpdatedAt = DateTime.Now;
            await _uow.ToDoRepository.UpdateAsync(activity, Id);
            await _uow.CommitAsync();
            return activity;
        }

        public async Task<Activity> PatchActivityAsync(int id, JsonPatchDocument<Activity> patchDocument)
        {
            Activity activity = await _uow.ToDoRepository.FirstOrDefaultAsync(a => a.Id == id);
            patchDocument.ApplyTo(activity);

            await _uow.ToDoRepository.UpdateAsync(activity, id);
            await _uow.CommitAsync();
            return activity;
        }
    }
}