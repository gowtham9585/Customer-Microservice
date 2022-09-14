using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Microservice.Repository
{
     public interface ICustomerRepository<T>
    {
        bool Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
