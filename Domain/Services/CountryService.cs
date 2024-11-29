using Microsoft.EntityFrameworkCore;
using WebApi_Jueves_2024II.DAL.Entities;
using WebApi_Jueves_2024II.DAL;
using WebApi_Jueves_2024II.Domain.Interfaces;

namespace WebApi_Jueves_2024II.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                return await _context.Countries.ToListAsync();
            }
            catch (DbUpdateException DbUpdateException)
            {

                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }

        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbUpdateException DbUpdateException)
            {

                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }


        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {   
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {

                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {

                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);
                if (country == null) { return null; }
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {

                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

    }
}
