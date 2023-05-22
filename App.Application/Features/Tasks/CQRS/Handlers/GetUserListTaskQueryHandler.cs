using App.Application.Contracts.Persistence;
using App.Application.Features.Tasks.CQRS.Queries;
using App.Application.Features.Tasks.DTOs;
using App.Application.Responses;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Features.Tasks.CQRS.Handlers
{
    public class GetUserTaskListQueryHandler : IRequestHandler<GetUserTaskListQuery, BaseResponse<List<TaskDto>>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetUserTaskListQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<TaskDto>>> Handle(GetUserTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetTaskByUserId(request.UserId);
            var taskDtos = _mapper.Map<List<TaskDto>>(tasks);

            return new BaseResponse<List<TaskDto>>()
            {
                Data = taskDtos,
                Success = true,
                Message = "User tasks retrieved successfully"
            };
        }
    }
}
