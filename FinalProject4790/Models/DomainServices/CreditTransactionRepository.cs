using FinalProject4790.Models.Domain;
using Stripe;

namespace FinalProject4790.Models.DomainServices
{
    public class CreditTransactionRepository : ICreditTransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Repository for CreditTransactions
        /// </summary>
        /// <param name="appDbContext"></param>
        public CreditTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Create a CreditTransaction from a StripCharge and Order.
        /// </summary>
        /// <param name="stripeCharge"></param>
        /// <param name="order"></param>
        public void CreateCreditTransactionFromStripeCharge(StripeCharge stripeCharge, Order order)
        {
            
            var creditTransaction = new CreditTransaction()
            {
                StripeChargeId = stripeCharge.Id,
                Created = stripeCharge.Created,
                AmountInCents = stripeCharge.Amount,
                Paid = stripeCharge.Paid,
                Order = order,
                OrderId = order.OrderId
            };

            _appDbContext.CreditTransactions.Add(creditTransaction);
            
            _appDbContext.SaveChanges();
        }
    }
}