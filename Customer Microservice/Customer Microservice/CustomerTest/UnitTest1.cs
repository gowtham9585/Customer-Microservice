using NUnit.Framework;
using Customer_Microservice.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CustomerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValidCustomer_When_CustomerExists()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            CustomerController customer = new CustomerController();
            var Result = customer.CreatedAtAction("getCustomerDetails/{id}", 1);
            Assert.IsNotNull(Result);
        }

        [Test]
        public void IsNotValidCustomer_When_CustomerNotExists()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            CustomerController customer = new CustomerController();
            var Result = customer.CreatedAtAction("getCustomerDetails/{id}", -1);
            Assert.IsEmpty(Result.ContentTypes);
        }
    }
}