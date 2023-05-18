using App.Application.Features.Tasks.DTOs;
using App.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace App.Application.Features.Tasks.CQRS.Queries;

public class GetUserTaskListQuery : IRequest<BaseResponse<List<TaskDto>>>
{
    public int UserId { get; set; }
}