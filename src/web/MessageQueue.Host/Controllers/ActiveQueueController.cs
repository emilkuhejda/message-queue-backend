using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Interfaces.Commands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MessageQueue.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveQueueController : ControllerBase
    {
        private readonly Lazy<ICreateActiveQueueCommand> _createActiveQueueCommand;

        public ActiveQueueController(Lazy<ICreateActiveQueueCommand> createActiveQueueCommand)
        {
            _createActiveQueueCommand = createActiveQueueCommand;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(OperationId = "ActiveQueues")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(OperationId = "CreateActiveQueue")]
        public async Task<IActionResult> Create(CreateActiveQueueInputModel createActiveQueueInputModel, CancellationToken cancellationToken)
        {
            var commandResult = await _createActiveQueueCommand.Value.ExecuteAsync(createActiveQueueInputModel, HttpContext.User, cancellationToken);
            return Ok(commandResult.IsSuccess);
        }
    }
}
