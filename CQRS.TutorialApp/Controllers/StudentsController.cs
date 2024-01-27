using CQRS.TutorialApp.CQRS.Commands;
using CQRS.TutorialApp.CQRS.Handlers;
using CQRS.TutorialApp.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.TutorialApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneStudent([FromRoute(Name ="id")] int id)
        {
            var queryResult = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(queryResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var queryResult  = await _mediator.Send(new GetStudentsQuery());
            return Ok(queryResult);
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return StatusCode(201, commandResult);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneStudent([FromRoute(Name = "id")] int id)
        {
            var commandResult = await _mediator.Send(new RemoveStudentCommand(id));
            return StatusCode(201,commandResult);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOneStudent(UpdateOneStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
