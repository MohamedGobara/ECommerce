using ECommerce.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Data
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class , IBaseEntity
    {
        private readonly ECommerceDBContext _context;
        public EntityBaseRepository(ECommerceDBContext context)
        {
            _context = context;

        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await GetByIdAsync(id);
            if (response != null)
            {

                _context.Remove(response);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            return response;
        }

        public async Task<IEnumerable<T>> GettAllAsync()
        => await _context.Set<T>().ToListAsync();

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

           
        }
    }
}
