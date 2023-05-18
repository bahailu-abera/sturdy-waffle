using App.Application.Features.Checklists.DTOs;
using App.Application.Responses;
using MediatR;

namespace App.Application.Features.Checklists.CQRS;

public class CreateChecklistCommand: IRequest<BaseResponse<Nullable<int>>>
{
    public CreateChecklistDto ChecklistDto { get; set; } = null!;
}