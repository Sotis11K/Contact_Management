using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Management.Interfaces;
using Contact_Management.Models;
using Contact_Management.Services;
using Moq;

namespace Contact_Management.test
{
    public class ContactManagement_test
    {
        [Fact]
        public void AddToListShould_AddOneCustomerList_ThenReturnTrue()
        {
            // Arrange

            ICustomer customer = new Customer { FirstName = "Ella", LastName = "Kihlgren", Email = "Ella@email.com", PhoneNumber = "0761857355", Address = "Brian gata" };

            var mockFileService = new Mock<IFileService>();

            ICustomerService customerService = new CustomerService(mockFileService.Object);

            // Act
            bool result = customerService.AddToList(customer);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetAllFromListShould_GetAllCustomersInCustomerList_ThenReturnListOfCustomer()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            ICustomerService customersService = new CustomerService(mockFileService.Object);
            ICustomer customer = new Customer { FirstName = "Ella", LastName = "Kihlgren", Email = "Ella@email.com", PhoneNumber = "0761857355", Address = "Brian gata" };
            customersService.AddToList(customer);

            // Act
            IEnumerable<ICustomer> result = customersService.GetAllFromList();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            ICustomer returnedCustomer = result.FirstOrDefault();
            Assert.Equal(1, returnedCustomer.Id);
        }
    }
}
