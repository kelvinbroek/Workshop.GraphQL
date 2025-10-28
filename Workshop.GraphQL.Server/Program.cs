using Microsoft.EntityFrameworkCore;
using Workshop.GraphQL.Server.Data;
using Workshop.GraphQL.Server.Mutations;

var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL()
    .AddTypes();

builder.Services
    .AddGraphQLServer()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    //.ModifyPagingOptions(p => p.MaxPageSize = 10)
    .AddInMemorySubscriptions()
    ;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging());


var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseWebSockets();
app.MapGraphQL();
app.RunWithGraphQLCommands(args);
