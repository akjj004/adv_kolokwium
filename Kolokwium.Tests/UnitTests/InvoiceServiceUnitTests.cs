using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Kolokwium.ViewModels.Interfaces;
using Kolokwium.ViewModels.VM;
using Xunit;

namespace Kolokwium.Tests.UnitTests
{
    public class InvoiceServiceUnitTests : BaseUnitTests
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceServiceUnitTests(ApplicationDbContext dbContext, IInvoiceService invoiceService) : base(dbContext)
        {
            _invoiceService = invoiceService;
        }
        [Fact]
        public void GetInvoiceTest()
        {
            var invoice = _invoiceService.GetInvoice(i => i.TotalPrice == 10);
            Assert.NotNull(invoice);
        }

        [Fact]
        public void GetMultipleOrdersTest()
        {
            var invoices = _invoiceService.GetInvoices(i => i.InvoiceId >= 1 && i.InvoiceId <= 2);
            Assert.NotNull(invoices);
            Assert.NotEmpty(invoices);
            Assert.Equal(2, invoices.Count());
        }

        [Fact]

        public void GetAllInvoicesTest()
        {
            var invoices = _invoiceService.GetInvoices();
            Assert.NotNull(invoices);
            Assert.NotEmpty(invoices);
            Assert.Equal(invoices.Count(), invoices.Count());
        }

        [Fact]

        public void AddNewInvoiceTest()
        {
            var newInvoiceVm = new AddOrUpdateInvoiceVm()
            {
                InvoiceId = 3,
                TotalPrice = 70,
                InvoiceDate = new DateTime()
            };
            var createdInvoice = _invoiceService.AddOrUpdateInvoice(newInvoiceVm);
            Assert.NotNull(createdInvoice);
            Assert.Equal(70, createdInvoice.TotalPrice);

        }

        [Fact]

        public void UpdateInvoiceTest()
        {
            var updateInvoiceVm = new AddOrUpdateInvoiceVm()
            {
                InvoiceId = 4,
                TotalPrice = 80,
                InvoiceDate = new DateTime()
            };
            var editedInvoiceVm = _invoiceService.AddOrUpdateInvoice(updateInvoiceVm);
            Assert.NotNull(editedInvoiceVm);
            Assert.Equal(80, editedInvoiceVm.TotalPrice);
        }
    }
}