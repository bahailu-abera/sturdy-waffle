using App.Application.Features.Tasks.CQRS.Queries;
using App.Application.Features.Tasks.DTOs;
using App.Application.Responses;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Contracts.Persistence;
namespace App.Application.Features.Tasks.CQRS.Handlers;

public class GetUserTaskListQueryHandler : IRequestHandler<GetUserTaskListQuery, BaseResponse<List<TaskDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetUserTaskListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<List<TaskDto>>> Handle(GetUserTaskListQuery request, CancellationToken cancellationToken)
    {   
        var tasks = await _unitOfWork.TaskRepository.GetTaskByUserId(request.UserId);
        var taskDtos = _mapper.Map<List<TaskDto>>(tasks);

        return new BaseResponse<List<TaskDto>>()
        {
            Data = _mapper.Map<List<TaskDto>>(tasks),
            Success = true
        };
    }
}