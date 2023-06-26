using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Models;

namespace NetCoreAPI.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> Add(T entity);
        Task<T> GetById(long id);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
