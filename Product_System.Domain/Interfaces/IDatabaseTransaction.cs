namespace Product_System.Domain.Interfaces;

public interface IDatabaseTransaction : IDisposable
{
    void Commit();
    void Rollback();
}
