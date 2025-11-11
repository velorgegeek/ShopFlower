
namespace DOMAIN
{
    enum OperationStatus
    {
        Success,
        Fail,
        Pending,
        Cancellend,
        Refund
    }
    enum TypeTransaction
    {
        Deposit,
        Subscription,
        Purchase
    }
    public class Transaction
    {
        int Id { get; set; }
        int IdUser { get; set; }
        DateTime DateTransaction { get; set; }
        TypeTransaction TypeTransaction { get; set; }

        OperationStatus OperationStatus { get; set; }
        int amount { get; set; }
        Transaction(int id, int idUser, DateTime dateTransaction, TypeTransaction typeTransaction, OperationStatus operationStatus, int amount)
        {
            Id = id;
            IdUser = idUser;
            DateTransaction = dateTransaction;
            TypeTransaction = typeTransaction;
            OperationStatus = operationStatus;
            this.amount = amount;
        }
    }
}
