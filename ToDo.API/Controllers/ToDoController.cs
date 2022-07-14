using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ToDo.Common.DTO.Request;
using ToDo.Common.DTO.Response;
using ToDo.Data.Entities;
using ToDo.Services;
using ToDo.Services.Impl;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/todo")]
    [Produces("application/json")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly IMapper _mapper;

        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger, IToDoService toDoService, IMapper mapper)
        {
            _logger = logger;
            _toDoService = toDoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all ToDo items
        /// </summary>
        /// <returns>A list of todo items</returns>
        /// <response code="200">Returns the the list of todo</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ActivityResponseDTO>>> GetAll()
        {
            var activities = await _toDoService.GetAllActivitiesAsync();
            var response = _mapper.Map<IEnumerable<ActivityResponseDTO>>(activities);
            return Ok(response);
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="item">The RequestDTO</param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActivityResponseDTO>> Create(ActivityRequestDTO item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var activity = _mapper.Map<Activity>(item);
            var result = await _toDoService.CreateActivityAsync(activity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Get ToDo item
        /// </summary>
        /// <param name="id">The item Id</param>
        /// <returns>Return a todo item</returns>
        /// <response code="200">Returns the todo item</response>
        /// <response code="404">If the item doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActivityResponseDTO>> GetById(int id)
        {
            var activity = await _toDoService.GetActivityByIdAsync(id);
            var result = _mapper.Map<ActivityResponseDTO>(activity);
            return Ok(result);
        }

        /// <summary>
        /// Delete ToDo item
        /// </summary>
        /// <param name="id">The item Id</param>
        /// <returns></returns>
        /// <response code="204">No content</response>
        /// <response code="404">If the item doesn't exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _toDoService.DeleteActivityAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Update Todo item
        /// </summary>
        /// <param name="id">The item Id</param>
        /// <param name="requestModel">The Request model</param>
        /// <returns></returns>
        /// <response code="204">No content</response>
        /// <response code="404">If the item doesn't exist</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActivityRequestDTO requestModel)
        {
            var activity = _mapper.Map<Activity>(requestModel);
            await _toDoService.UpdateActivityAsync(id, activity);
            return NoContent();
        }

        /// <summary>
        /// Patch Todo item
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<ActivityResponseDTO>> Patch(int id, [FromBody] JsonPatchDocument<Activity> patchDoc)
        {
            var activity = await _toDoService.PatchActivityAsync(id, patchDoc);
            var responseDTO = _mapper.Map<ActivityResponseDTO>(activity);
            return Ok(responseDTO);
        }
    }
}