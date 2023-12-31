using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Management.Interfaces;

namespace Contact_Management.Models
{
    public class Customer : ICustomer
    {
        public int Id {get; set;}
        public string FirstName { get; set; } = null!;
        public string LastName {get; set; } = null!;
        public string Email {get; set; } =  null!;
        public string PhoneNumber {get; set; } = null!;
        public string Address {get; set; } =  null!;
    }
}
