using CarvedRock.Data.Abstraction;
using CarvedRock.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.Data.Repositories
{
    public class ProductReviewRepository : IRepository<ProductReview>
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductReview> Get(int id)
        {
            return await this._dbContext.ProductsReviews.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IList<ProductReview>> GetAll()
        {
            return await this._dbContext.ProductsReviews.ToListAsync();
        }
    }
}
