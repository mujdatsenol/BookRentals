namespace BookRentals.Domain
{
    public interface IDataContextTransaction : IDisposable
    {
        object TransactionObject { get; }

        void Commit();

        void Rollback();
    }
}
