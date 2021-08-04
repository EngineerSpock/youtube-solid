namespace SOLID.SRP.Refactored
{
    public class BankGateway : ICanPayViaCreditCard
    {
        public void ChargeCard(TicketDetails ticketDetails, PaymentDetails paymentDetails)
        {
            //charge
        }
    }
}
