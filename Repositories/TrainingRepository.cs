using Microsoft.EntityFrameworkCore;
using TrainingApp.Data;
using TrainingApp.Models;

namespace TrainingApp.Repositories;

/// <summary>
/// Репозиторий тренировок
/// </summary>
public class TrainingRepository : ITrainingRepository
{
    private readonly AppDbContext _context;

    public TrainingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Training>> GetAllAsync()
    {
        return await _context.Trainings.ToListAsync();
    }

    public async Task<Training?> GetByIdAsync(int id)
    {
        return await _context.Trainings.FindAsync(id);
    }

    public async Task<Training> AddAsync(Training training)
    {
        _context.Trainings.Add(training);
        await _context.SaveChangesAsync();
        return training;
    }

    public async Task UpdateAsync(Training training)
    {
        var existingTraining = await _context.Trainings.FindAsync(training.Id);
        if (existingTraining != null)
        {
            existingTraining.Title = training.Title;
            existingTraining.Date = training.Date;
            existingTraining.DurationMinutes = training.DurationMinutes;
            existingTraining.Description = training.Description;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var training = await _context.Trainings.FindAsync(id);
        if (training != null)
        {
            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Trainings.AnyAsync(t => t.Id == id);
    }
}