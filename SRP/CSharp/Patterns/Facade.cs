using System;

namespace SOLID.SRP.Patterns
{
    class Problem
    {
        void Purchase()
        {
            int id = 123;
            Customer c = Customer.FindCustomer(id);

            int goodId = 13457;
            Order o = Stock.Find(goodId);
            CreditCardInfo cci = c.GetCreditCardInfo();
            BankGateway gateway = new BankGateway();
            gateway.ChargeCard(cci, o);

            c.AddToStatistics(o);
        }
    }

    class PurchaseFacade
    {
        public void ProcessPurchase(int customerId, int goodId)
        {
            Customer c = Customer.FindCustomer(customerId);
            
            Order o = Stock.Find(goodId);
            CreditCardInfo cci = c.GetCreditCardInfo();
            BankGateway gateway = new BankGateway();
            gateway.ChargeCard(cci, o);


            c.AddToStatistics(o);
        }
    }

    #region Irrelevant
    internal class Stock
    {
        public static Order Find(int goodId)
        {
            return null;
        }
    }

    internal class BankGateway
    {
        public void ChargeCard(CreditCardInfo cci, Order order)
        {
            throw new NotImplementedException();
        }
    }

    internal class Order
    {
    }

    internal class CreditCardInfo
    {
    }

    class Expense
    {
        
    }

    class Customer
    {
        public CreditCardInfo GetCreditCardInfo()
        {
            throw new NotImplementedException();
        }

        public void AddToStatistics(Order order)
        {
            throw new NotImplementedException();
        }

        public static Customer FindCustomer(int id)
        {
            return null;
        }
    }
    #endregion
}
