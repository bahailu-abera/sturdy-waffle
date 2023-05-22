using App.Application.Features.Tasks.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Contracts.Persistence;
using App.Application.Responses;

namespace App.Application.Features.Tasks.CQRS.Handlers;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, BaseResponse<Nullable<int>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<Nullable<int>>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
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

        await _unitOfWork.TaskRepository.Delete(existingTask);
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
                Message = "Task Deleted"
        };

       return response;
    }
}