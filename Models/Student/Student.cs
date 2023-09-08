namespace CRUD_Asp.Models.Student
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
