using App.Application.Features.Checklists.DTOs;
using App.Application.Responses;
using MediatR;

namespace App.Application.Features.Checklists.CQRS;

public class UpdateChecklistCommand: IRequest<BaseResponse<Nullable<int>>>
{
    public int ChecklistId { get; set; }

    public CreateChecklistDto ChecklistDto { get; set; } = null!;
}