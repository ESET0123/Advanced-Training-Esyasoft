using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbcontext;

        public AuthorRepository(LibraryDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbcontext.Authors.ToListAsync();
        }

        public async Task<Author> GetbyidAsync(int id)
        {
            return await _dbcontext.Authors.Where(n => n.AuthorId == id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Author newauthor)
        {
            await _dbcontext.Authors.AddAsync(newauthor);
            await _dbcontext.SaveChangesAsync();
            return newauthor.AuthorId;
        }

        public async Task<int> UpdateAsync(Author existingauthor, Author newauthor)
        {
            existingauthor.AuthorId = newauthor.AuthorId;
            existingauthor.Name = newauthor.Name;
            existingauthor.Country = newauthor.Country;

            await _dbcontext.SaveChangesAsync();
            return 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var deleting = await _dbcontext.Authors.Where(n => n.AuthorId == id).FirstOrDefaultAsync();

            _dbcontext.Authors.Remove(deleting);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
