using App.Application.Contracts.Persistence;
using App.Application.Features.Checklists.DTOs;
using App.Application.Responses;
using App.Domain;
using AutoMapper;
using MediatR;

namespace App.Application.Features.Checklists.CQRS;

public class CreateChecklistCommandHandler: IRequestHandler<CreateChecklistCommand, BaseResponse<Nullable<int>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateChecklistCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<Nullable<int>>> Handle(CreateChecklistCommand request, CancellationToken cancellationToken)
    {
        BaseResponse<Nullable<int>> response;

        var checklist = _mapper.Map<Checklist>(request.ChecklistDto);

        var CreatedChecklist = await _unitOfWork.ChecklistRepository.Add(checklist);
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
        
        return new BaseResponse<Nullable<int>>()
        {
            Data = CreatedChecklist.Id,
            Success = true,
            Message = "Checklist created successfully"
        };
    }
}