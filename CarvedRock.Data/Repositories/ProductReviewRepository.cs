using CarvedRock.Data.Abstraction;
using CarvedRock.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<ProductReview> GetAsync(int id)
        {
            return await this._dbContext.ProductsReviews.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductReview>> GetAllAsync()
        {
            return await this._dbContext.ProductsReviews.ToListAsync();
        }

        public async Task<ILookup<int, ProductReview>> GetForProducts(IEnumerable<int> productIds, CancellationToken arg2)
        {
            var reviews = await this._dbContext
                .ProductsReviews
                .Where(pr => productIds.Contains(pr.ProductId))
                .ToListAsync();

            return reviews.ToLookup(r => r.ProductId);
        }
    }
}
