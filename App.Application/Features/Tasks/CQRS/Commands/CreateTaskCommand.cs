using App.Application.Features.Tasks.DTOs;
using App.Application.Responses;
using MediatR;

namespace App.Application.Features.Tasks.CQRS.Commands
{
    public class CreateTaskCommand : IRequest<BaseResponse<Nullable<int>>>
    {
        public CreateTaskDto TaskDto { get; set; } = null!;
    }
}
