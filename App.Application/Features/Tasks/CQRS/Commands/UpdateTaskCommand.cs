using App.Application.Features.Tasks.DTOs;
using App.Application.Responses;
using MediatR;

namespace App.Application.Features.Tasks.CQRS.Commands
{
    public class UpdateTaskCommand : IRequest<BaseResponse<Nullable<int>>>
    {
        public int TaskId { get; set; }
        public CreateTaskDto TaskDto { get; set; } = null!;
    }
}
