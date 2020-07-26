using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Data.Abstraction;
using CarvedRock.Models;
using CarvedRock.Repositories;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(IRepository<Product> productRepository)
        {
            Field<ListGraphType<GraphQL.Types.ProductType>>(
                "products",
                resolve: context =>  productRepository.GetAll()
            );
        }
    }
}
