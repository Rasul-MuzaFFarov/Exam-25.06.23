namespace Domain.Dtos.ManagerBaseDto;

public class ManagerBaseDto
{
    public int DepartmentId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}