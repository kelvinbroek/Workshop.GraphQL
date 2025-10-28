using Workshop.GraphQL.Server.Data.Entities;

namespace Workshop.GraphQL.Server.Subscriptions;

[SubscriptionType]
public class DepartmentsSubscriptions
{
    [Subscribe]
    [Topic("DepartmentsTopic")]
    public Department OnDepartmentAdded([EventMessage] Department department)  
    {
        Console.WriteLine($"Department added: {department.Name}");
        return department;
    }
}