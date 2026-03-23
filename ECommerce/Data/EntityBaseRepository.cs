using ECommerce.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce.Data
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class , IBaseEntity
    {
        private readonly ECommerceDBContext _context;

        private readonly DbSet<T> _entities; 
        public EntityBaseRepository(ECommerceDBContext context)
        {
            _context = context;
            _entities = _context.Set<T>();

        }
        public async Task CreateAsync(T entity)
        {
            await _entities.AddAsync(entity);
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
            var response = await _entities.FirstOrDefaultAsync(x => x.Id == id);

            return response;
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _entities.AsQueryable();

            query = include.Aggregate(query, (current, include) => current.Include(include));

            return await query.FirstOrDefaultAsync( x=> x.Id ==id);
        }

        public async Task<IEnumerable<T>> GettAllAsync()
        => await _entities.ToListAsync();

        public async Task<IEnumerable<T>> GettAllAsync(params Expression<Func<T, object>>[] include)
        {
           
            IQueryable<T> query = _entities.AsQueryable();
            
            query = include.Aggregate(query, (current, inculde) => current.Include(inculde));
            return await query.ToListAsync();



        }

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

           
        }
    }
}
