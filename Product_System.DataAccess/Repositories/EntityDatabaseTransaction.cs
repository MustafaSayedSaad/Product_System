﻿namespace Product_System.DataAccess.Repositories;

public class EntityDatabaseTransaction(DbContext context) : IDatabaseTransaction
{
    private readonly IDbContextTransaction _transaction = context.Database.BeginTransaction();

    public void Commit() =>
        _transaction.Commit();

    public void Rollback() =>
        _transaction.Rollback();

    public void Dispose() =>
        _transaction.Dispose();
}
