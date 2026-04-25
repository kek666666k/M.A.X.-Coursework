using TrainingApp.Models;

namespace TrainingApp.Repositories;

/// <summary>
/// Интерфейс репозитория для связи тренировок и упражнений
/// </summary>
public interface IWorkoutExerciseRepository
{
    Task<IEnumerable<WorkoutExercise>> GetByTrainingIdAsync(int trainingId);
    Task<WorkoutExercise> AddAsync(WorkoutExercise workoutExercise);
    Task DeleteAsync(int id);
}