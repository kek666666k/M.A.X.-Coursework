using TrainingApp.Models;

namespace TrainingApp.Services;

/// <summary>
/// Интерфейс сервиса для связи тренировок и упражнений
/// </summary>
public interface IWorkoutExerciseService
{
    Task<IEnumerable<WorkoutExercise>> GetByTrainingIdAsync(int trainingId);
    Task<WorkoutExercise> AddAsync(WorkoutExercise workoutExercise);
    Task DeleteAsync(int id);
}