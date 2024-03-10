namespace StudentCRUD.Domain.Entities
{
    public class Student : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
    }
}