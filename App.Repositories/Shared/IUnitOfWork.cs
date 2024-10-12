namespace App.Repositories.Shared
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
