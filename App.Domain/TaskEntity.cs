namespace App.Domain;
using App.Domain.Common;

public class TaskEntity: Base
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool status { get; set; }
}