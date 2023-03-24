using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW1.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int entityId);
        void Put(TEntity entity);
        void Post(TEntity entity);
        void Delete(int id);
    }
}
