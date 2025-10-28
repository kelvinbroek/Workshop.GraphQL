namespace Workshop.GraphQL.Server.Data.Entities;

public class Assignment
{
    public int Id {get; set;}
    
    public string Title {get; set;} = null!;
    
    public ICollection<Employee> Employees {get; set;} = new List<Employee>();
}