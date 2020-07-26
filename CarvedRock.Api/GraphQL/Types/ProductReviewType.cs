using CarvedRock.Models;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(p => p.Id);
            Field(p => p.Title).Description("Review Title");
            Field(p => p.Review).Description("Review Content");
        }
    }
}
