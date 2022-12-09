using Microsoft.EntityFrameworkCore;
using WebApplicationGraphQL.Database;
using WebApplicationGraphQL.GraphQl;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlite("Filename=MyDatabase.db"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var Db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    Db.Database.Migrate();
}

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
