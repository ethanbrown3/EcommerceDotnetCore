using System;

namespace FinalProject4790.Models.Domain
{
    public class CreditTransaction
    {
        public int CreditTransactionId { get; set; }
        public string StripeChargeId { get; set; }
        public DateTime Created { get; set; }
        public int AmountInCents { get; set; }
        public bool Paid { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}