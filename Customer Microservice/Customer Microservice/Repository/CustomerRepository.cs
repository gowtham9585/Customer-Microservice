using Customer_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Microservice.Repository
{
    public class CustomerRepository : ICustomerRepository<Customer>
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerRepository));

        public static List<Customer> ListCustomer = new List<Customer>()
        {
            new Customer {CustomerId = 1, Name = "Rose", Address = "Thindal Road, Erode",  PANno = "DCRP124HUT" , DOB = Convert.ToDateTime("1998-11-20 01:02:01 AM")},
            new Customer {CustomerId = 2, Name = "Jack", Address = "Demondy Colony, Chenni", PANno = "DCRP23456", DOB = Convert.ToDateTime("1999-11-10 02:02:01 AM")}
        };
        
        public bool Add(Customer item)
        {
            try
            {
                ListCustomer.Add(item);
                _log4net.Info("Customer details has been successfully entered.");
                return true;
            }
            catch (Exception e)
            {
                _log4net.Error("Error" + e.Message);
            }
            return false;
        }
       
        public Customer Get(int id)
        {
            try
            {
                _log4net.Info("Customer details  has been successfully retrieved");
                return ListCustomer.Find(p => p.CustomerId == id);           
            }
            catch (Exception e)
            {
                _log4net.Error("Error " + e.Message);
                throw e;
            }

        }
       
        public IEnumerable<Customer> GetAll()
        {

            _log4net.Info("Customer details is finally recieved.");
            return ListCustomer.ToList();

        }
    }
}
