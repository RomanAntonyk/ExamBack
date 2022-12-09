namespace ExamBack.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string OwnerFirstName { get; set; } = null!;
        public string OwnerLastName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Diagnosis { get; set; } = null!;
    }
}
