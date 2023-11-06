using Microsoft.EntityFrameworkCore;

namespace NetChallenge.Application.Abstractions.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}
