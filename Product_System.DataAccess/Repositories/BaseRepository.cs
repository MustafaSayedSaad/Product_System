﻿namespace Product_System.DataAccess.Repositories;

public class BaseRepository<T>(ProductDbContext context) : IBaseRepository<T> where T : class
{
    protected ProductDbContext _context = context;
    internal DbSet<T> dbSet = context.Set<T>();
    private static readonly char[] separator = [','];

    public async Task<T> GetByIdAsync(int id) =>
        (await dbSet.FindAsync(id))!;

    public async Task<IEnumerable<TType>> GetSpecificSelectAsync<TType>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TType>> select,
        string includeProperties = null!,
        int? skip = null,
        int? take = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!

        ) where TType : class
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (includeProperties != null)
        {
            query.AsSplitQuery();
            foreach (var includeProperty in includeProperties.Split(separator,
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty).IgnoreQueryFilters();
        }

        if (filter != null)
            query = query.Where(filter);
        if (orderBy != null)
            query = orderBy(query);

        if (skip.HasValue)
            query = query.Skip(skip.Value);
        if (take.HasValue)
            query = query.Take(take.Value);

        return await query.Select(select).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null!,
        Expression<Func<T, IQueryable<T>>> select = null!,
        Expression<Func<T, T>> selector = null!,
        Func<IQueryable<T>,
        IOrderedQueryable<T>> orderBy = null!,
        string includeProperties = null!,
        int? skip = null,
        int? take = null)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (select != null)
            query = (IQueryable<T>)query.Select(select);
        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!
      )
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(separator,
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        return await query.FirstOrDefaultAsync() is not null;
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null!,
        string includeProperties = null!
          , Func<IQueryable<T>,
        IOrderedQueryable<T>> orderBy = null!
        )
    {
        IQueryable<T> query = dbSet.AsSplitQuery().AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(separator,
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);
        if (orderBy != null)
            return (await orderBy(query).FirstOrDefaultAsync())!;

        return (await query.FirstOrDefaultAsync())!;
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
        return entities;
    }

    public T Remove(T entity)
    {
        dbSet.Remove(entity);
        return entity;
    }


    public T Update(T entity)
    {
        dbSet.Update(entity);
        return entity;
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);
        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(separator,
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        return await query.CountAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null!)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        return await query.AnyAsync();
    }

    public void RemoveRange(IEnumerable<T> entities) =>
            dbSet.RemoveRange(entities);

    public void UpdateRange(IEnumerable<T> entities) =>
        dbSet.UpdateRange(entities);
}
