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
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityResponseDTO>>> GetAll()
        {
            var activities = await _toDoService.GetAllActivitiesAsync();
            var response = _mapper.Map<IEnumerable<ActivityResponseDTO>>(activities);
            return Ok(response);
        }

        /// <summary>
        /// Create a ToDo item
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityResponseDTO>> GetById(int id)
        {
            var activity = await _toDoService.GetActivityByIdAsync(id);
            var result = _mapper.Map<ActivityResponseDTO>(activity);
            return Ok(result);
        }

        /// <summary>
        /// Delete ToDo item
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityResponseDTO>> Delete(int id)
        {
            await _toDoService.DeleteActivityAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Update Todo item
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityResponseDTO>> Update(int id, ActivityRequestDTO requestModel)
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