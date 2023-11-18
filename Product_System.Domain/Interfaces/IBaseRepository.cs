﻿namespace Product_System.Domain.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<TType>> GetSpecificSelectAsync<TType>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TType>> select,
        string includeProperties = null!,
        int? skip = null,
        int? take = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!
        ) where TType : class;

    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null!, Expression<Func<T, IQueryable<T>>> select = null!,
     Expression<Func<T, T>> selector = null!,
     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
     string includeProperties = null!,
     int? skip = null,
     int? take = null);

    Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!);

    Task<T> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>> filter = null!,
        string includeProperties = null!,
          Func<IQueryable<T>,
        IOrderedQueryable<T>> orderBy = null!
    );

    Task<T> AddAsync(T entity);

    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    T Remove(T entity);
    T Update(T entity);
    Task<int> CountAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null!);
    void RemoveRange(IEnumerable<T> entities);
    void UpdateRange(IEnumerable<T> entities);
}