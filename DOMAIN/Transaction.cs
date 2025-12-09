
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
    public class Payments
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime DateTransaction { get; set; }

        OperationStatus OperationStatus { get; set; }
        Payments(int idUser, DateTime dateTransaction,  OperationStatus operationStatus, int amount)
        {
            IdUser = idUser;
            DateTransaction = dateTransaction;
            OperationStatus = operationStatus;
        }
    }
}
