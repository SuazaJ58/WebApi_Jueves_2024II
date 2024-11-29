using Microsoft.EntityFrameworkCore;
using WebApi_Jueves_2024II.DAL.Entities;
using WebApi_Jueves_2024II.DAL;
using WebApi_Jueves_2024II.Domain.Interfaces;

namespace WebApi_Jueves_2024II.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId)
        {
            try
            {
                return await _context.States.Where(s => s.CountryId == countryId).ToListAsync();
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                return await _context.States.FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<State> UpdateStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await GetStateByIdAsync(id);
                if (state == null) { return null; }
                _context.States.Remove(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

    }
}
