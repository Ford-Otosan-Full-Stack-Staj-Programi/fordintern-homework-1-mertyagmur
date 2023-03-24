using FordInternHW1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private bool disposed;

        public IGenericRepository<Staff> StaffRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            StaffRepository = new GenericRepository<Staff>(context);
        }
        public void Complete()
        {
            context.SaveChanges();
        }

        protected virtual void Clean(bool disposing) 
        { 
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
