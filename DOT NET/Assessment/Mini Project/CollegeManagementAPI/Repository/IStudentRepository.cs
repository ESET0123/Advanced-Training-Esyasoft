using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task AddAsync(Student employee);

        Task UpdateAsync(Student employee);

        Task DeleteAsync(int id);
    }
}
