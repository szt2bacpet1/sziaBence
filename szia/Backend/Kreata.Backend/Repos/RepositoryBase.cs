﻿using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Flyhigh.Backend.Repos
{
    public abstract class RepositoryBase<TDbContext, TEntity> : IRepositoryBase<TEntity>
       where TDbContext : DbContext
       where TEntity : class, IDbEntity<TEntity>, new()

    {
        private readonly IDbContextFactory<TDbContext> _dbContextFactory;
        private DbSet<TEntity>? _dbSet;
        private readonly DbContext _dbContext;

        public RepositoryBase(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
             TDbContext dbContext = _dbContextFactory.CreateDbContext();
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<ControllerResponse> DeleteAsync(Guid id)
        {
            ControllerResponse response = new ControllerResponse();
            TEntity studentToDelete = await GetById(id);
            if (!studentToDelete.HasId)
            {
                response.AppendNewError($"{id} idével rendelkező entitás nem található!");
                response.AppendNewError("Az entitás törlése nem sikerült!");
            }
            else
            {
                try
                {
                    _dbContext.ChangeTracker.Clear();
                    _dbContext.Entry(studentToDelete).State = EntityState.Deleted;
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    response.AppendNewError(e.Message);
                    response.AppendNewError($"{nameof(RepositoryBase<TDbContext, TEntity>)} osztály, {nameof(DeleteAsync)} metódusban hiba keletkezett");
                    response.AppendNewError($"Az entitás id:{id}");
                    response.AppendNewError($"Az entitás törlése nem sikerült!");
                }
            }
            return response;
        }

            public IQueryable<TEntity> FindAll()
        {
            if (_dbSet is null)
            {
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            }
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            if (_dbSet is null)
            {
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            }
            return _dbSet.Where(expression).AsNoTracking();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            if (_dbSet is null)
            {
                return new TEntity();
            }
            return await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id) ?? new TEntity();
        }


        private async Task<ControllerResponse> CreateAsync(TEntity entity)
        {
            ControllerResponse response = new ControllerResponse();
            if (_dbSet is null)
            {
                response.AppendNewError($"{entity} osztály hozzáadása az adatbázishoz nem sikerült!");
            }
            else
            {
                try
                {
                    _dbSet.Add(entity);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    response.AppendNewError(e.Message);
                    response.AppendNewError($"{nameof(RepositoryBase<TDbContext, TEntity>)} osztály, {nameof(CreateAsync)} metódusban hiba keletkezett");
                    response.AppendNewError($"{entity} osztály hozzáadása az adatbázishoz nem sikerült!");
                }
            }
            return response;
        }

        public async Task<ControllerResponse> UpdateAsync(TEntity entity)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(RepositoryBase<TDbContext, TEntity>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{entity} frissítése nem sikerült!");

            }
            return response;
        }

        Task<ControllerResponse> IRepositoryBase<TEntity>.CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
