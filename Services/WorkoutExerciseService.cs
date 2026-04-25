using TrainingApp.Models;
using TrainingApp.Repositories;

namespace TrainingApp.Services;

/// <summary>
/// Сервис для связи тренировок и упражнений
/// </summary>
public class WorkoutExerciseService : IWorkoutExerciseService
{
    private readonly IWorkoutExerciseRepository _repository;

    public WorkoutExerciseService(IWorkoutExerciseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WorkoutExercise>> GetByTrainingIdAsync(int trainingId)
    {
        return await _repository.GetByTrainingIdAsync(trainingId);
    }

    public async Task<WorkoutExercise> AddAsync(WorkoutExercise workoutExercise)
    {
        return await _repository.AddAsync(workoutExercise);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}