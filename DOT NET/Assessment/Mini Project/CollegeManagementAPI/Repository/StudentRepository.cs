using CollegeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeManagementDbContext _dbcontext;

        public StudentRepository(CollegeManagementDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbcontext.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task AddAsync(Student studentnew)
        {
            await _dbcontext.Students.AddAsync(studentnew);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _dbcontext.Students.Where(n => n.StudentId == id).FirstOrDefaultAsync();

            _dbcontext.Students.Remove(deleting);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _dbcontext.Students.Where(n => n.StudentId == id).FirstOrDefaultAsync();
        }

        public async Task<Student?> GetByNameAsync(string name)
        {
            return await _dbcontext.Students.Where(n => n.Name == name).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Student employee)
        {
            var existingStudent = await _dbcontext.Students.Where(n => n.StudentId == employee.StudentId).FirstOrDefaultAsync();

            if (existingStudent == null)
            {
                return;
            }

            existingStudent.RollNumber = employee.RollNumber;
            existingStudent.Name = employee.Name;
            existingStudent.Email = employee.Email;
            existingStudent.Phone = employee.Phone;
            existingStudent.Address = employee.Address;
            existingStudent.DateOfBirth = employee.DateOfBirth;
            existingStudent.Gender = employee.Gender;
            existingStudent.CourseId = employee.CourseId;

            await _dbcontext.SaveChangesAsync();
        }
    }
}
