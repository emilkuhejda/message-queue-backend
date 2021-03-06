using AutoMapper;
using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Interfaces.Commands;
using MessageQueue.Domain.Interfaces.Queries;
using MessageQueue.Domain.Models;
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
        private readonly Lazy<IGetActiveQueueQuery> _getActiveQueueQuery;
        private readonly Lazy<IGetActiveQueuesQuery> _getActiveQueuesQuery;
        private readonly Lazy<ICreateActiveQueueCommand> _createActiveQueueCommand;
        private readonly Lazy<ICreateMessageCommand> _createMessageCommand;
        private readonly Lazy<IMapper> _mapper;

        public ActiveQueueController(
            Lazy<IGetActiveQueueQuery> getActiveQueueQuery,
            Lazy<IGetActiveQueuesQuery> getActiveQueuesQuery,
            Lazy<ICreateActiveQueueCommand> createActiveQueueCommand,
            Lazy<ICreateMessageCommand> createMessageCommand,
            Lazy<IMapper> mapper)
        {
            _getActiveQueueQuery = getActiveQueueQuery;
            _getActiveQueuesQuery = getActiveQueuesQuery;
            _createActiveQueueCommand = createActiveQueueCommand;
            _mapper = mapper;
            _createMessageCommand = createMessageCommand;
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
            if (!commandResult.IsSuccess)
            {
                return BadRequest(_mapper.Value.Map<ErrorResultOutputModel>(commandResult));
            }

            return Ok(commandResult.Value);
        }

        [HttpPost("{activeQueueId}")]
        [ProducesResponseType(typeof(OkOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(OperationId = "CreateMessage")]
        public async Task<ActionResult> CreateMessage(Guid activeQueueId, CreateMessageInputModel createMessageInputModel, CancellationToken cancellationToken)
        {
            if (!createMessageInputModel.Validate().IsValid)
            {
                return BadRequest();
            }

            var activeQueueQueryResult = await _getActiveQueueQuery.Value.ExecuteAsync(activeQueueId, HttpContext.User, cancellationToken);
            if (!activeQueueQueryResult.IsSuccess || activeQueueQueryResult.Value == null)
            {
                return NotFound(_mapper.Value.Map<ErrorResultOutputModel>(activeQueueQueryResult));
            }

            var message = _mapper.Value.Map<Message>(
                createMessageInputModel,
                opt => opt.AfterMap((_, m) => m.ActiveQueueId = activeQueueQueryResult.Value.Id));

            var commandResult = await _createMessageCommand.Value.ExecuteAsync(message, HttpContext.User, cancellationToken);
            if (!commandResult.IsSuccess)
            {
                return BadRequest(_mapper.Value.Map<ErrorResultOutputModel>(commandResult));
            }

            return Ok(commandResult.Value);
        }
    }
}
