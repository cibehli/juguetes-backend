using Juguetes.BL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
namespace Juguetes.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly JuguetesContext juguetesContext;
        public GenericRepository(JuguetesContext juguetesContext)
        {
            this.juguetesContext = juguetesContext;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("No se encontro");
            juguetesContext.Set<TEntity>().Remove(entity);
            await juguetesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await juguetesContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await juguetesContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            juguetesContext.Set<TEntity>().Add(entity);
            await juguetesContext.SaveChangesAsync();
            return entity;

        }
        public async Task<TEntity> Update(TEntity entity)
        {
            //juguetesContext.Entry(entity).State = EntityState.Modified;
            juguetesContext.Set<TEntity>().AddOrUpdate(entity);
            await juguetesContext.SaveChangesAsync();
            return entity;
        }
    }
}
