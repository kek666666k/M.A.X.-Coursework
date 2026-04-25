using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Models;

/// <summary>
/// Связующая таблица: упражнение в тренировке с параметрами
/// </summary>
public class WorkoutExercise
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int TrainingId { get; set; }

    [Required]
    public int ExerciseId { get; set; }

    public int Sets { get; set; }

    public int Reps { get; set; }

    public double? WeightKg { get; set; }

    /// <summary>
    /// Примечания к упражнению
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Порядок выполнения упражнения
    /// </summary>
    public int Order { get; set; }

    // Навигационные свойства
    [ForeignKey(nameof(TrainingId))]
    public Training? Training { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }
}