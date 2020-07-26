using CarvedRock.Data.Abstraction;
using CarvedRock.Models;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(IRepository<Product> productRepository)
        {
            Field<ListGraphType<GraphQL.Types.ProductType>>(
                "products",
                resolve: context => productRepository.GetAllAsync()
            );

            Field<GraphQL.Types.ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                        { Name = "id" }),
                resolve: context =>
                    {
                        var id = context.GetArgument<int>("id");
                        return productRepository.GetAsync(id);
                    }
                );
        }
    }
}
