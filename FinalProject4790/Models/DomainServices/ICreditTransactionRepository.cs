using FinalProject4790.Models.Domain;
using Stripe;

namespace FinalProject4790.Models.DomainServices
{
    public interface ICreditTransactionRepository 
    {
        void CreateCreditTransactionFromStripeCharge(StripeCharge stripeCharge, Order order);

    }
}