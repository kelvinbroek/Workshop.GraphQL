using Workshop.GraphQL.Server.Data;
using Workshop.GraphQL.Server.Data.Entities;

namespace Workshop.GraphQL.Server.Queries;

[QueryType]
public class DepartmentsQueries
{
    [UseProjection]
    public IQueryable<Department> GetDepartments(ApplicationDbContext context) =>
        context.Departments;
}