using CarvedRock.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarvedRock.Data.Abstraction
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);
        Task<ILookup<int, T>> GetForProducts(IEnumerable<int> arg1, CancellationToken arg2);
    }
}
