using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Data.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetbyidAsync(int id);
        Task<int> CreateAsync(Book newbook);
        Task<int> UpdateAsync(Book existingbook, Book newbook);
        Task<bool> DeleteAsync(int id);
    }
}
