using System.Runtime.InteropServices.JavaScript;

namespace Domain.Entities;

public class Salary
{
    public int Id { get; set; }
    public int EmploteeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int Amount { get; set; }
}