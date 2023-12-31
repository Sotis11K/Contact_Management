using Contact_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Management.Interfaces;

public interface ICustomerService
{
    bool AddToList(ICustomer customer);
    IEnumerable<ICustomer> GetAllFromList();
}
