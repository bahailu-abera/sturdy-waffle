namespace App.Application.Features.Tasks.DTOs;

public class CreateTaskDto: ITaskDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Status { get; set; }
}