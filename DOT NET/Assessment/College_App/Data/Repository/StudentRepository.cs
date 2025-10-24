using Microsoft.EntityFrameworkCore;
using static CollegeApp.Data.Repository.StudentRepository;

namespace CollegeApp.Data.Repository
{

    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDBContext _dbcontext;

        public StudentRepository(CollegeDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _dbcontext.Students.ToListAsync();
        }

        public async Task<Student> GetstudentbyidAsync(int id)
        {
            return await _dbcontext.Students.Where(n => n.studentID == id).FirstOrDefaultAsync();
        }

        public async Task<Student> GetstudentbynameAsync(string Name)
        {
            return await _dbcontext.Students.Where(n => n.name == Name).FirstOrDefaultAsync();
        }

        public async Task<int> CreatestudentAsync(Student student)
        {
            await _dbcontext.Students.AddAsync(student);
            await _dbcontext.SaveChangesAsync();
            return student.studentID;
        }
        public async Task<int> UpdatestudentAsync(Student existingStudent, Student student)
        {
            //throw new NotImplementedException();
            
            existingStudent.studentID = student.studentID;
            existingStudent.name = student.name;
            existingStudent.age = student.age;
            existingStudent.email = student.email;

            await _dbcontext.SaveChangesAsync();
            return 1;

        }

        public async Task<bool> DeletestudentAsync(int id)
        {
            
            var deleting = await _dbcontext.Students.Where(n => n.studentID == id).FirstOrDefaultAsync();

            _dbcontext.Students.Remove(deleting);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

      
    }

}
