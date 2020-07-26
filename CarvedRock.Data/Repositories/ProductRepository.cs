using CarvedRock.Data;
using CarvedRock.Data.Abstraction;
using CarvedRock.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CarvedRock.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
