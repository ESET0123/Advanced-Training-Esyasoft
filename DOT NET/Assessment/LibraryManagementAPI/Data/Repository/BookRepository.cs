using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbcontext;

        public BookRepository(LibraryDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbcontext.Books.ToListAsync();
        }

        public async Task<Book> GetbyidAsync(int id)
        {
            return await _dbcontext.Books.Where(n => n.BookId == id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Book newbook)
        {
            await _dbcontext.Books.AddAsync(newbook);
            await _dbcontext.SaveChangesAsync();
            return newbook.BookId;
        }

        public async Task<int> UpdateAsync(Book existingbook, Book newbook)
        {
            existingbook.BookId = newbook.BookId;
            existingbook.Title = newbook.Title;

            await _dbcontext.SaveChangesAsync();
            return 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var deleting = await _dbcontext.Books.Where(n => n.BookId == id).FirstOrDefaultAsync();

            _dbcontext.Books.Remove(deleting);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
