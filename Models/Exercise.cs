using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models;

public class Exercise
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(50)]
    public string? MuscleGroup { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }
}