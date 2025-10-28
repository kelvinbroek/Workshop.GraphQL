using HotChocolate.Subscriptions;
using Workshop.GraphQL.Server.Data;

namespace Workshop.GraphQL.Server.Mutations;

[MutationType]
public class DepartmentsMutations
{
    // public async Task<Data.Entities.Department> AddDepartmentAsync(
    //     string name,
    //     ApplicationDbContext context,
    //     CancellationToken cancellationToken = default)
    // {
    //     var department = new Data.Entities.Department
    //     {
    //         Name = name
    //     };
    //
    //     context.Departments.Add(department);
    //     await context.SaveChangesAsync(cancellationToken);
    //
    //     return department;
    // }
    
    public async Task<string> AddDepartmentAsync(
        string name,
        ITopicEventSender eventSender,
        ApplicationDbContext context,
        CancellationToken cancellationToken = default)
    {
        var department = new Data.Entities.Department
        {
            Name = name
        };
    
        context.Departments.Add(department);
        await context.SaveChangesAsync(cancellationToken);
        
        await eventSender.SendAsync("DepartmentsTopic", department);
    
        return $"Department '{name}' added successfully.";
    }
}