namespace Domain.Entities;

public class Department
{
    public Department(int modelId, string modelName)
    {
        Id = modelId;
        Name = modelName;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}