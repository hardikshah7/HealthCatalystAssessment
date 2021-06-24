using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthCatalystAssessment.Data
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}