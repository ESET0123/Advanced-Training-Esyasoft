using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

        Task<Course?> GetByNameAsync(string name);

        Task AddAsync(Course employee);

        Task UpdateAsync(Course employee);

        Task DeleteAsync(int id);
    }
}
