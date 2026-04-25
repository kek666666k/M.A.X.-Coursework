using TrainingApp.Models;

namespace TrainingApp.Repositories;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise?> GetByIdAsync(int id);
    Task<Exercise> AddAsync(Exercise exercise);
    Task UpdateAsync(Exercise exercise);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}