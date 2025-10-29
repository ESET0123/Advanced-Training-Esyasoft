using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task<Student?> GetByNameAsync(string name);

        Task AddAsync(Student employee);

        Task UpdateAsync(Student employee);

        Task DeleteAsync(int id);
    }
}
