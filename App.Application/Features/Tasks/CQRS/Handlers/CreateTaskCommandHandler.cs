using App.Application.Contracts.Persistence;
using App.Application.Features.Tasks.CQRS.Commands;
using App.Application.Responses;
using App.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Features.Tasks.CQRS.Handlers;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, BaseResponse<Nullable<int>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<Nullable<int>>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        BaseResponse<Nullable<int>> response;
        
        var taskEntity = _mapper.Map<TaskEntity>(request.TaskDto);
        
        var createdTask = await _unitOfWork.TaskRepository.Add(taskEntity);
        var databaseResponse = await _unitOfWork.Save();

        if (databaseResponse == 0)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                Message = "ServerErrorException",
            };

            return response;
        }
        
        response = new BaseResponse<Nullable<int>>()
        {
                Data = taskEntity.Id,
                Success = true,
                Message = "Task created"
        };

       return response;
    }
}