using App.Application.Features.Checklists.CQRS;
using App.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Contracts.Persistence;
using App.Application.Responses;
using App.Application.Features.Checklists.CQRS.Commands;

namespace App.Application.Features.Checklists.CQRS.Handlers;

public class UpdateChecklistCommandHandler : IRequestHandler<UpdateChecklistCommand, BaseResponse<Nullable<int>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateChecklistCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<Nullable<int>>> Handle(UpdateChecklistCommand request, CancellationToken cancellationToken)
    {
        BaseResponse<Nullable<int>> response;
        
        var existingChecklist = await _unitOfWork.ChecklistRepository.Get(request.ChecklistId);

        if (existingChecklist == null)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                Message = "ChecklistNotFound",
            };

            return response;
        }

        var updatedChecklist = _mapper.Map(request.ChecklistDto, existingChecklist);

        await _unitOfWork.ChecklistRepository.Update(updatedChecklist);
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
                Message = "Checklist Updated"
        };

       return response;
    }
}