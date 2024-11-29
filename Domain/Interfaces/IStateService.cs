
using WebApi_Jueves_2024II.DAL.Entities;

namespace WebApi_Jueves_2024II.Domain.Interfaces
{
    public interface IStateService
    {
        //get by id
        Task<State> GetStateByIdAsync(Guid id);

        //get all states by country id
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId);

        //create
        Task<State> CreateStateAsync(State state);

        //update
        Task<State> UpdateStateAsync(State state);

        //delete
        Task<State> DeleteStateAsync(Guid id);

    }
}
