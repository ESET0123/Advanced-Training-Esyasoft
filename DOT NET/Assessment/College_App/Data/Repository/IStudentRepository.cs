namespace CollegeApp.Data.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetstudentbyidAsync(int id);
        Task<Student> GetstudentbynameAsync(string Name);
        Task<int> CreatestudentAsync(Student student);
        Task<int> UpdatestudentAsync(Student student1, Student student2);
        Task<bool> DeletestudentAsync(int id);
    }
}
