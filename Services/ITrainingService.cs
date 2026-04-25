using TrainingApp.Models;

namespace TrainingApp.Services;

/// <summary>
/// Интерфейс сервиса тренировок
/// </summary>
public interface ITrainingService
{
    Task<IEnumerable<Training>> GetAllAsync();
    Task<Training?> GetByIdAsync(int id);
    Task<Training> AddAsync(Training training);
    Task UpdateAsync(Training training);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}