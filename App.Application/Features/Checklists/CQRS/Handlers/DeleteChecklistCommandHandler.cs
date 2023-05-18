using App.Application.Contracts.Persistence;
using App.Application.Responses;
using AutoMapper;
using MediatR;

namespace App.Application.Features.Checklists.CQRS;


public class DeleteChecklistCommandHandler: IRequestHandler<DeleteChecklistCommand, BaseResponse<Nullable<int>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteChecklistCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<Nullable<int>>> Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
    {
        BaseResponse<Nullable<int>> response;
        
        var existingChecklist = await _unitOfWork.ChecklistRepository.Get(request.ChecklistId);

        if (existingChecklist == null)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                ErrorMessage = "ChecklistNotFound"
            };

            return response;
        }

        await _unitOfWork.ChecklistRepository.Delete(existingChecklist);
        var databaseResponse = await _unitOfWork.Save();

        if (databaseResponse == 0)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                ErrorMessage = "ServerExceptionError"
            };

            return response;
        }

        response = new BaseResponse<Nullable<int>>()
        {
            Success = true,
            Message = "Checklist deleted successfully"
        };

        return response;
    }
}