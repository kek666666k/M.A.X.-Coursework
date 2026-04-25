using TrainingApp.Models;
using TrainingApp.Repositories;

namespace TrainingApp.Services;

/// <summary>
/// Сервис тренировок
/// </summary>
public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _repository;

    public TrainingService(ITrainingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Training>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Training?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Training> AddAsync(Training training)
    {
        return await _repository.AddAsync(training);
    }

    public async Task UpdateAsync(Training training)
    {
        await _repository.UpdateAsync(training);
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