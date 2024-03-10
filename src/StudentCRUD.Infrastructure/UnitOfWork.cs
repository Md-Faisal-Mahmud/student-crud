﻿using FirstDemo.Domain;
using FirstDemo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Domain.UnitOfWorks;

namespace StudentCRUD.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        protected IAdoNetUtility AdoNetUtility { get; private set; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            AdoNetUtility = new AdoNetUtility(_dbContext.Database.GetDbConnection());
        }

        public void Dispose() => _dbContext?.Dispose();
        public ValueTask DisposeAsync() => _dbContext.DisposeAsync();
        public void Save() => _dbContext?.SaveChanges();
        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
