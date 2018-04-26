using System;
using System.Collections.Generic;
using FinalProject4790.Models.Domain;
using Stripe;

namespace FinalProject4790.Models.DomainServices
{
    public class MockCreditTransactionRepository : ICreditTransactionRepository
    {
        private List<CreditTransaction> _Transactions;

        public MockCreditTransactionRepository()
        {
            if (_Transactions == null)
            {
                InitializeTransactions();
            }
        }

        private void InitializeTransactions()
        {
	        _Transactions = new List<CreditTransaction>
                {
                    new CreditTransaction {
                        CreditTransactionId = 0,
                        StripeChargeId = "testid",
                        Created = new DateTime(2000, 1, 1, 1, 1, 1),
                        AmountInCents = 100,
                        Paid = true,
                        OrderId = 0
                    }
                };
        }

        public void CreateCreditTransactionFromStripeCharge(StripeCharge stripeCharge, Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}