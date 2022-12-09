using System.Diagnostics.Contracts;
using WebApplicationGraphQL.Database;
using WebApplicationGraphQL.Models;

namespace WebApplicationGraphQL.GraphQl;

public class Queries
{
    public IQueryable<Product> GetProducts([Service(ServiceKind.Synchronized)] ApplicationDbContext dbContext)
    {
        return dbContext.Products;
    }

    public IQueryable<Category> GetCategories([Service(ServiceKind.Synchronized)] ApplicationDbContext dbContext)
    {
        return dbContext.Categories;
    }
}
