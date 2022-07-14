using Microsoft.AspNetCore.JsonPatch;
using ToDo.Data.Entities;

namespace ToDo.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<Activity>> GetAllActivitiesAsync();

        Task<Activity> GetActivityByIdAsync(int Id);

        Task<Activity> CreateActivityAsync(Activity activity);

        Task<Activity> UpdateActivityAsync(int Id, Activity activity);

        Task<int> DeleteActivityAsync(int Id);

        Task<Activity> PatchActivityAsync(int Id, JsonPatchDocument<Activity> patchDocument);
    }
}