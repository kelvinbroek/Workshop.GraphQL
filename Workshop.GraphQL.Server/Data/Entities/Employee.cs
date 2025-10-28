namespace Workshop.GraphQL.Server.Data.Entities;

public class Employee
{
    public int Id {get; set;}
    
    public string Name {get; set;} = null!;

    public string? Address { get; set; }
    public string? Zipcode { get; set; }
    public string? Country { get; set; }
    public string? BirthOfPlace { get; set; }
    public string? Telephonenumber { get; set; }
    public string[]? Hobbies { get; set; }

    [UseFiltering]
    public Assignment? Assignment { get; set; }

    public int? AssignmentId { get; set; }
    
    public int DepartmentId {get; set;}
    
    [UseFiltering]
    public Department Department {get; set;} = null!;
}