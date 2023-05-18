using App.Application.Features.Checklists.CQRS.Queries;
using App.Application.Features.Checklists.DTOs;
using App.Application.Responses;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Contracts.Persistence;
namespace App.Application.Features.Checklists.CQRS.Handlers;

public class GetTaskListChecklistQueryHandler : IRequestHandler<GetTaskListChecklistQuery, BaseResponse<List<ChecklistDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetTaskListChecklistQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<List<ChecklistDto>>> Handle(GetTaskListChecklistQuery request, CancellationToken cancellationToken)
    {   
        var Checklists = await _unitOfWork.ChecklistRepository.GetChecklistByTaskId(request.TaskId);
        var checklistDtos = _mapper.Map<List<ChecklistDto>>(Checklists);

        return new BaseResponse<List<ChecklistDto>>()
        {
            Data = _mapper.Map<List<ChecklistDto>>(Checklists),
            Success = true
        };
    }
}