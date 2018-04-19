using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject4790.Tests.Models.Domain.Tests
{
    public class CreditTransactionTests
    {
        private CreditTransaction creditTransaction;
        [SetUp]
        public void Setup()
        {
            // Arrange
            creditTransaction = new CreditTransaction();
        }

        [Test]
        public void CreditTransaction_SetGetId()
        {
            creditTransaction.CreditTransactionId = 100;

            Assert.AreEqual(creditTransaction.CreditTransactionId, 100);
        }

        [Test]
        public void CreditTransaction_SetGetStripeChargeId()
        {
            creditTransaction.StripeChargeId = "TestID";

            Assert.AreEqual(creditTransaction.StripeChargeId, "TestID");
        }

        [Test]
        public void CreditTransaction_SetGetCreatedDate()
        {
            var testDateTime = DateTime.Now;
            creditTransaction.Created = testDateTime;

            Assert.AreEqual(creditTransaction.Created, testDateTime);
        }

        [Test]
        public void CreditTransaction_SetGetAmountInCents()
        {
            creditTransaction.AmountInCents = 100;

            Assert.AreEqual(creditTransaction.AmountInCents, 100);
        }

        [Test]
        public void CreditTransaction_SetGetPaid()
        {
            creditTransaction.Paid = true;

            Assert.True(creditTransaction.Paid);
        }

        [Test]
        public void CreditTransaction_SetGetOrder()
        {
            var order = new Order();
            order.OrderId = 1;

            creditTransaction.Order = order;
            creditTransaction.OrderId = order.OrderId;

            Assert.AreEqual(creditTransaction.Order, order);
            Assert.AreEqual(creditTransaction.OrderId, order.OrderId);
        }   

    }
}