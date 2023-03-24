using FordInternHW1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW1.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Staff> StaffRepository { get; }
        void Complete();
    }
}
