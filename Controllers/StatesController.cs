using Microsoft.AspNetCore.Mvc;
using WebApi_Jueves_2024II.DAL.Entities;
using WebApi_Jueves_2024II.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2024II.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByCountry/{countryId}")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountryIdAsync(Guid countryId)
        {
            var states = await _stateService.GetStatesByCountryIdAsync(countryId);
            if (states == null || !states.Any()) return NotFound();
            return Ok(states);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);
            if (state == null) return NotFound();
            return Ok(state);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) return NotFound();
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", state.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Update")]
        [Route("Update")]
        public async Task<ActionResult<State>> UpdateStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.UpdateStateAsync(state);
                if (editedState == null) return NotFound();
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", state.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedState = await _stateService.DeleteStateAsync(id);
            if (deletedState == null) return NotFound();
            return Ok(deletedState);
        }
    }
}
