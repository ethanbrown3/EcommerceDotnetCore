using System;

namespace FinalProject4790.Models.Domain
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string LocationId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}