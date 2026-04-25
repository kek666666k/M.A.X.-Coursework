using TrainingApp.Models;
using TrainingApp.Repositories;

namespace TrainingApp.Services;

/// <summary>
/// Сервис упражнений
/// </summary>
public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _repository;

    public ExerciseService(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Exercise> AddAsync(Exercise exercise)
    {
        return await _repository.AddAsync(exercise);
    }

    public async Task UpdateAsync(Exercise exercise)
    {
        await _repository.UpdateAsync(exercise);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }
}