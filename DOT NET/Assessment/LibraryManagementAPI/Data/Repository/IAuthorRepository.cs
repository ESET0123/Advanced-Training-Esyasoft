using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Data.Repository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetbyidAsync(int id);

        Task<int> CreateAsync(Author newauthor);
        Task<int> UpdateAsync(Author existingauthor, Author newauthor);
        Task<bool> DeleteAsync(int id);
    }
}
