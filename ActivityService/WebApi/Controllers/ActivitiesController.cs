using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var result = await _mediator.Send(new GetActivities.Query());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var result = await _mediator.Send(new GetActivity.Query()
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(CreateActivityDto dto)
        {
            await _mediator.Send(new CreateActivity.Command { Dto = dto });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(Guid id, UpdateActivityDto dto)
        {
            dto.Id = id;   
            await _mediator.Send(new UpdateActivity.Command { Dto = dto });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await _mediator.Send(new DeleteActivity.Command { Id = id } );

            return Ok();
        }
    }
}