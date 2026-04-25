using Microsoft.EntityFrameworkCore;
using TrainingApp.Data;
using TrainingApp.Models;

namespace TrainingApp.Repositories;

/// <summary>
/// Репозиторий упражнений
/// </summary>
public class ExerciseRepository : IExerciseRepository
{
    private readonly AppDbContext _context;

    public ExerciseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await _context.Exercises.ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    public async Task<Exercise> AddAsync(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task UpdateAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise != null)
        {
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Exercises.AnyAsync(e => e.Id == id);
    }
}