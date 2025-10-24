namespace CollegeApp.Data.Repository
{
    public interface ICollegeRepo<T>
    {
        Task<List<T>> GetAll();

        Task<T> getbyidAsync(int id);

        Task<T> getbynameAsync(string Name);
        Task<T> create(T dbRecord);

        Task<T> UpdateAsync(T dbRecord);

        Task<bool> deletestudentAsync(int id);
    }
}
