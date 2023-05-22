namespace App.Application.Features.Tasks.DTOs;

public interface ITaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Status { get; set; }
}