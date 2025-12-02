
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
        Purchase
    }
    public class Transaction
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime DateTransaction { get; set; }
        TypeTransaction TypeTransaction { get; set; }

        OperationStatus OperationStatus { get; set; }
        public int amount { get; set; }
        Transaction(int idUser, DateTime dateTransaction, TypeTransaction typeTransaction, OperationStatus operationStatus, int amount)
        {
            IdUser = idUser;
            DateTransaction = dateTransaction;
            TypeTransaction = typeTransaction;
            OperationStatus = operationStatus;
            this.amount = amount;
        }
    }
}
