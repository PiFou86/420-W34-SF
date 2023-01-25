
public interface ITransactionBD : IDisposable {
    void Commit();
    void Rollback();
    void BeginTransaction();
}