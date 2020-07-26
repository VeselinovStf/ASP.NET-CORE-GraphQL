using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.Data.Abstraction
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
    }
}
