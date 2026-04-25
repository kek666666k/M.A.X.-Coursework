using Microsoft.EntityFrameworkCore;
using TrainingApp.Data;
using TrainingApp.Models;

namespace TrainingApp.Repositories;

/// <summary>
/// Репозиторий для связи тренировок и упражнений
/// </summary>
public class WorkoutExerciseRepository : IWorkoutExerciseRepository
{
    private readonly AppDbContext _context;

    public WorkoutExerciseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkoutExercise>> GetByTrainingIdAsync(int trainingId)
    {
        return await _context.WorkoutExercises
            .Where(we => we.TrainingId == trainingId)
            .ToListAsync();
    }

    public async Task<WorkoutExercise> AddAsync(WorkoutExercise workoutExercise)
    {
        // Определяем порядок: ставим в конец списка
        var maxOrder = await _context.WorkoutExercises
            .Where(we => we.TrainingId == workoutExercise.TrainingId)
            .MaxAsync(we => (int?)we.Order) ?? 0;

        workoutExercise.Order = maxOrder + 1;

        _context.WorkoutExercises.Add(workoutExercise);
        await _context.SaveChangesAsync();
        return workoutExercise;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.WorkoutExercises.FindAsync(id);
        if (entity != null)
        {
            _context.WorkoutExercises.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}