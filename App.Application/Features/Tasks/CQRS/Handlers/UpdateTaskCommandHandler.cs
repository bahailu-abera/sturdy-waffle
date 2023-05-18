using App.Application.Features.Tasks.CQRS.Commands;
using App.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Contracts.Persistence;
using App.Application.Responses;

namespace App.Application.Features.Tasks.CQRS.Handlers;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, BaseResponse<Nullable<int>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<Nullable<int>>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        BaseResponse<Nullable<int>> response;
        
        var existingTask = await _unitOfWork.TaskRepository.Get(request.TaskId);

        if (existingTask == null)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                Message = "TaskNotFound",
            };

            return response;
        }

        var updatedTask = _mapper.Map(request.TaskDto, existingTask);

        await _unitOfWork.TaskRepository.Update(updatedTask);
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
                Success = true,
                Message = "Task Updated"
        };

       return response;
    }
}