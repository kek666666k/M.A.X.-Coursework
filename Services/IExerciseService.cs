using TrainingApp.Models;

namespace TrainingApp.Services;

public interface IExerciseService
{
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise?> GetByIdAsync(int id);
    Task<Exercise> AddAsync(Exercise exercise);
    Task UpdateAsync(Exercise exercise);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}