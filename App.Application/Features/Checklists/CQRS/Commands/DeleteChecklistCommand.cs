using App.Application.Responses;
using MediatR;

namespace App.Application.Features.Checklists.CQRS.Commands;

public class DeleteChecklistCommand: IRequest<BaseResponse<Nullable<int>>>
{
    public int ChecklistId { get; set; }
}