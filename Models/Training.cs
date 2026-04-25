
namespace TrainingApp.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public string? Description { get; set; }
    }
}
