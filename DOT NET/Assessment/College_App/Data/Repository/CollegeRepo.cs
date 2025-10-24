using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository
{
    public class CollegeRepo<T> : ICollegeRepo<T> where T : class
    {
        private readonly CollegeDBContext _dbcontext;

        private DbSet<T> _dbSet;
        public CollegeRepo(CollegeDBContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = dbcontext.Set<T>();
        }

        

        public async Task<T> create(T dbRecord)
        {
            _dbSet.Add(dbRecord);
            await _dbcontext.SaveChangesAsync();
            return dbRecord;
        }

        public Task<bool> deletestudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> getbyidAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> getbynameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T dbRecord)
        {
            throw new NotImplementedException();
        }
    }
}
