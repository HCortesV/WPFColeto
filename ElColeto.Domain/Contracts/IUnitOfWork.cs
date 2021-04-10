using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ElColeto.Domain.Entities;

namespace ElColeto.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<T> Repositorio<T>() where T:class;
        int Commit();
        Task<int> CommitAsync();
    }

}
