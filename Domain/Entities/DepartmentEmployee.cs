namespace Domain.Entities;

public class DepartmentEmployee
{
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}