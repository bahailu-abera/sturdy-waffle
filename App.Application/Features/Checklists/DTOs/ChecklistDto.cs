using App.Domain.Common;

namespace App.Application.Features.Checklists.DTOs;

public class ChecklistDto: Base, IChecklistDto
{
    public string Title {get; set;} = null!;
    public string Description { get; set; } = null!;
    public int TaskId { get; set; }
    public bool status { get; set; }
}