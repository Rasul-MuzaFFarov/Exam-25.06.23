namespace Domain.Entities;

public class DepartmentManager
{
    public DepartmentManager(int modelDepartmentId, DateTime modelFromDate, DateTime modelToDate, int modelEmployeeId)
    {
        DepartmentId = modelDepartmentId;
        EmployeeId = modelEmployeeId;
        FromDate = modelFromDate;
        ToDate = modelToDate;
    }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}