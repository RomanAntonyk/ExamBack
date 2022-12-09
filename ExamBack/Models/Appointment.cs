namespace ExamBack.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
