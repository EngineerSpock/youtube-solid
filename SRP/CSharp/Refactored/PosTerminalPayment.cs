using System;

namespace SOLID.SRP.Refactored
{
    public class PosTerminalPayment : PaymentModel, ICanOperateWithCash
    {
        private readonly Action _onPayChangeToMobilePhone;
        private decimal _cashAccepted;

        public PosTerminalPayment(TicketDetails ticketDetails, Action onPayChangeToMobilePhone) : base(ticketDetails)
        {
            _onPayChangeToMobilePhone = onPayChangeToMobilePhone;
        }

        public override void BuyTicket()
        {
            AcceptCash();
            DispenseChange();
        }

        public void AcceptCash()
        {
            Random r = new Random();
            _cashAccepted = r.Next((int) _ticketDetails.Price, (int) _ticketDetails.Price + 1000);
        }

        public void DispenseChange()
        {
            if (_cashAccepted > _ticketDetails.Price && !TryToDispense())
            {
                _onPayChangeToMobilePhone?.Invoke();
            }
        }

        private bool TryToDispense()
        {
            //issue a command for dispensing
            //now just a stub
            return false;
        }
    }
}
