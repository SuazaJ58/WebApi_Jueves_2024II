using WebApi_Jueves_2024II.DAL.Entities;


namespace WebApi_Jueves_2024II.Domain.Interfaces
{
    public interface ICountryService
    {
        //get id
        Task<Country> GetCountryByIdAsync(Guid id);
        //get all
        Task<IEnumerable<Country>> GetCountriesAsync();
        //create
        Task<Country> CreateCountryAsync(Country country);
        //update
        Task<Country> UpdateCountryAsync(Country country);
        //delete
        Task<Country> DeleteCountryAsync(Guid id);
    }
}
