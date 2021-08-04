namespace SOLID.SRP.Refactored
{
    public interface ICanPayViaCreditCard
    {
        void ChargeCard(TicketDetails ticketDetails, PaymentDetails paymentDetails);
    }
}
