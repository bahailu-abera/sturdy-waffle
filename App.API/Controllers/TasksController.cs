using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Features.Tasks.CQRS.Commands;
using App.Application.Features.Tasks.CQRS.Queries;
using App.Application.Features.Tasks.DTOs;
using App.Application.Responses;

namespace App.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserTaskList(int userId)
    {
        var query = new GetUserTaskListQuery { UserId = userId };
        var response = await _mediator.Send(query);

        if (!response.Success)
            return StatusCode(500, response);

        return Ok(response);
    }


    [HttpPost]
    public async Task<ActionResult<BaseResponse<Nullable<int>>>> CreateTask(CreateTaskDto createDto)
    {
        var command = new CreateTaskCommand { TaskDto = createDto };

        var response = await _mediator.Send(command);

        if (!response.Success)
            return StatusCode(500, response);
        
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseResponse<Nullable<int>>>> UpdateTask(int id, CreateTaskDto updateDto)
    {
        var command = new UpdateTaskCommand { TaskId = id, TaskDto = updateDto };

        var response = await _mediator.Send(command);

        if (!response.Success)
            return StatusCode(500, response);
        
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponse<Nullable<int>>>> DeleteTask(int id)
    {
        var command = new DeleteTaskCommand { TaskId = id };

        var response = await _mediator.Send(command);

        if (!response.Success)
            return StatusCode(500, response);
        
        return Ok(response);
    }
}