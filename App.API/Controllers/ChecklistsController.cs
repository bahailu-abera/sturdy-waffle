using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Features.Checklists.CQRS.Commands;
using App.Application.Features.Checklists.CQRS.Queries;
using App.Application.Features.Checklists.DTOs;
using App.Application.Responses;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/checklists")]
    public class ChecklistsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChecklistsController(IMediator mediator)
        {
            _mediator = mediator;
        }

         [HttpGet("{TaskId}")]
        public async Task<IActionResult> GetTaskChecklist(int TaskId)
        {
            var query = new GetTaskListChecklistQuery { TaskId = TaskId };
            var response = await _mediator.Send(query);

            if (!response.Success)
                return StatusCode(500, response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Nullable<int>>>> CreateChecklist(CreateChecklistDto createDto)
        {
            var command = new CreateChecklistCommand { ChecklistDto = createDto };

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Nullable<int>>>> UpdateChecklist(int id, CreateChecklistDto updateDto)
        {
            var command = new UpdateChecklistCommand { ChecklistId = id, ChecklistDto = updateDto };

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Nullable<int>>>> DeleteChecklist(int id)
        {
            var command = new DeleteChecklistCommand { ChecklistId = id };

            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
