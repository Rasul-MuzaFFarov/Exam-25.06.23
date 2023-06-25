namespace Domain.Entities;

public class Employee
{
    
    
    
        public Employee(int modelId, string modelFirstName, string modelLastName, int modelGender, DateTime modelHireDate)
        {
            Id = modelId;
            FirstName = modelFirstName;
            LastName = modelLastName;
            HireDate = modelHireDate;
            Gender = modelGender;
        }
    
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Gender { get; set; }
    public DateTime HireDate { get; set; }
}