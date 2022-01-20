using AutoMapper;
using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Interfaces.Commands;
using MessageQueue.Domain.Interfaces.Queries;
using MessageQueue.Domain.OutputModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MessageQueue.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveQueueController : ControllerBase
    {
        private readonly Lazy<IGetActiveQueuesQuery> _getActiveQueuesQuery;
        private readonly Lazy<ICreateActiveQueueCommand> _createActiveQueueCommand;
        private readonly Lazy<IMapper> _mapper;

        public ActiveQueueController(
            Lazy<IGetActiveQueuesQuery> getActiveQueuesQuery,
            Lazy<ICreateActiveQueueCommand> createActiveQueueCommand,
            Lazy<IMapper> mapper)
        {
            _getActiveQueuesQuery = getActiveQueuesQuery;
            _createActiveQueueCommand = createActiveQueueCommand;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ActiveQueueOutputModel[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(OperationId = "ActiveQueues")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var queryResult = await _getActiveQueuesQuery.Value.ExecuteAsync(HttpContext.User, cancellationToken);
            if (!queryResult.IsSuccess)
            {
                return BadRequest(_mapper.Value.Map<ErrorResultOutputModel>(queryResult));
            }

            return Ok(queryResult.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OkOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(OperationId = "CreateActiveQueue")]
        public async Task<IActionResult> Create(CreateActiveQueueInputModel createActiveQueueInputModel, CancellationToken cancellationToken)
        {
            var commandResult = await _createActiveQueueCommand.Value.ExecuteAsync(createActiveQueueInputModel, HttpContext.User, cancellationToken);
            return Ok(commandResult.Value);
        }
    }
}
