using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;
using Workshop.GraphQL.Server.Data;
using Workshop.GraphQL.Server.Data.Entities;

namespace Workshop.GraphQL.Server.Queries;

[QueryType]
public class EmployeeQueries
{
    public async Task<Employee?> GetEmployeeById(
        int id, 
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Include(e => e.Assignment)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Employee> GetEmployees(
        ApplicationDbContext dbContext)
        => dbContext.Employees
            .Include(e => e.Assignment)
            .Include(e => e.Department);
}