using App.Application.Responses;
using MediatR;

namespace App.Application.Features.Tasks.CQRS.Commands
{
    public class DeleteTaskCommand : IRequest<BaseResponse<Nullable<int>>>
    {
        public int TaskId { get; set; }
    }
}
