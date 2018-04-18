using FinalProject4790.Models.Domain;
using Stripe;

namespace FinalProject4790.Models.DomainServices
{
    public class CreditTransactionRepository : ICreditTransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        public CreditTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
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