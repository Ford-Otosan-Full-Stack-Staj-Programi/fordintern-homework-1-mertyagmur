using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW1.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext context;
        private DbSet<TEntity> entities;
        public GenericRepository(AppDbContext context) 
        { 
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            entities.Remove(entity);
            
        }

        public List<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public TEntity GetById(int entityId)
        {
            return entities.Find(entityId);
        }


        public void Post(TEntity entity)
        {
            entity.GetType().GetProperty("CreatedBy").SetValue(entity, "Admin");
            entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);
            entities.Add(entity);
        }

        public void Put(TEntity entity)
        {
            entities.Update(entity);
        }
    }
}
