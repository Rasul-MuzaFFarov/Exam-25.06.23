namespace Domain.Dtos.EmployeeBaseDto;

public class EmployeeBaseDto
{
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Gender { get; set; }
    public DateTime HireDate { get; set; }
}