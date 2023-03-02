using Application.Services.Interfaces;
using Domain.MainModule.Core;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SofttekBDContext context;
        protected readonly DbSet<T> entities;

        public BaseRepository(SofttekBDContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            T _entity = await GetById(id);
            entities.Remove(_entity);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
}
