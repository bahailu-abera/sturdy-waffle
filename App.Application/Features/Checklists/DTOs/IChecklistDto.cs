namespace App.Application.Features.Checklists.DTOs;

public interface IChecklistDto
{
    public string Title {get; set;}
    public string Description { get; set; }
    public int TaskId { get; set; }
    public bool status { get; set; }
}