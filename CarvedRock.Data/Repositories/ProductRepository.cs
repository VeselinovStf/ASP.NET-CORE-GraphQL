using CarvedRock.Data.Abstraction;
using CarvedRock.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace CarvedRock.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await this._dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<ILookup<int, Product>> GetForProducts(IEnumerable<int> arg1, CancellationToken arg2)
        {
            throw new System.NotImplementedException();
        }
    }
}
