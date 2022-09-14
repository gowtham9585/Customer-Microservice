using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Microservice.Service
{
    public interface ICustomerService<Customer>
    {
        bool Add(Customer item);
        Customer Get(int id);
        IEnumerable<Customer> GetAll();
    }
}
