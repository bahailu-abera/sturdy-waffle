using App.Application.Features.Checklists.DTOs;
using App.Application.Responses;
using MediatR;

namespace App.Application.Features.Checklists.CQRS.Queries;

public class GetTaskListChecklistQuery: IRequest<BaseResponse<List<ChecklistDto>>>
{
    public int TaskId { get; set; }
}