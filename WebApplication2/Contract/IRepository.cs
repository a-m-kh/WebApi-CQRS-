using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Dto;
using System.Collections.Generic;

namespace WebApplication2.Contract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AddAsync(TEntity te);
        Task<List<TEntity>> GetAsync(TEntity te);
        Task<TEntity> Update(TEntity te);
        Task<TEntity> Delete(TEntity te);
        Task<bool> Search(TEntity te);
    }
}
