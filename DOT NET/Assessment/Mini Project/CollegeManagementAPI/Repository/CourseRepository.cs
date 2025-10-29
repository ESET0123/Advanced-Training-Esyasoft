using CollegeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CollegeManagementDbContext _dbcontext;

        public CourseRepository(CollegeManagementDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _dbcontext.Courses.Include(c => c.Students).ToListAsync();
        }

        public async Task AddAsync(Course employee)
        {
            await _dbcontext.Courses.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            //return Ok(t);
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _dbcontext.Courses.Where(n => n.CourseId == id).FirstOrDefaultAsync();

            _dbcontext.Courses.Remove(deleting);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _dbcontext.Courses.Where(n => n.CourseId == id).FirstOrDefaultAsync();
        }

        public async Task<Course?> GetByNameAsync(string name)
        {
            return await _dbcontext.Courses.Where(n => n.CourseName == name).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Course employee)
        {
            var existingCourse = await _dbcontext.Courses.Where(n => n.CourseId == employee.CourseId).FirstOrDefaultAsync();
            existingCourse.CourseId = employee.CourseId;
            existingCourse.CourseCode = employee.CourseCode;
            existingCourse.CourseName = employee.CourseName;
            existingCourse.Department = employee.Department;
            existingCourse.Semester = employee.Semester;

            await _dbcontext.SaveChangesAsync();
        }
    }
}
