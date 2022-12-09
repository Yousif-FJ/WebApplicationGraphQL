using WebApplicationGraphQL.Database;
using WebApplicationGraphQL.Models;

namespace WebApplicationGraphQL.GraphQl;

public class Mutations
{
    public async Task<Category> AddCategory(
        [Service(ServiceKind.Synchronized)] ApplicationDbContext dbContext, string name)
    {
        var category = new Category { Name = name };
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
        return category;
    }
}
