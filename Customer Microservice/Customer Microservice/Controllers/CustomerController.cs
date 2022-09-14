using Customer_Microservice.Model;
using Customer_Microservice.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
		static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerController));

		private readonly ICustomerService<Customer> _service;

		public CustomerController(ICustomerService<Customer> service)
		{
			_service = service;
		}
		
		[HttpGet("Get")]
		public IActionResult Get()
		{
			try
			{
				_log4net.Info("Get Api Initiated");
				return Ok(_service.GetAll());
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		
		[HttpGet]
		[Route("getCustomerDetails/{id}")]
		public IActionResult getCustomerDetails([FromRoute] int id)
		{
			if (id == 0)
			{
				_log4net.Warn("User has sent some invalid CustomerId");
				return BadRequest();
			}
			Customer listCustomer = new Customer();
			try
			{
				listCustomer = _service.Get(id);
				if (listCustomer == null)
				{
					_log4net.Error("No record found for the user Id :" + id);
					return NotFound();
				}
				else
				{
					_log4net.Info("Customer's Details has been successfully returned");
					return Ok(listCustomer);
				}
			}
			catch (Exception e)
			{
				_log4net.Error("Error occurred while calling get method" + e.Message);
				return new StatusCodeResult(500);
			}
		}

		
		[HttpPost]
		[Route("createCustomer")]
		public IActionResult createCustomer([FromBody] Customer customer)
		{
			ResponseObj responseObj = new ResponseObj();
			if (!ModelState.IsValid)
			{
				_log4net.Info("No Customer has been returned");
				responseObj.isSuccess = false;
				responseObj.resMessage = "User has sent some invalid details";
				responseObj.resObject = null;
				return BadRequest(new { isSuccess = false, resMessage = "User has sent some invalid details" });
			}
			try
			{
				bool result = _service.Add(customer);

				if (result)
				{
					_log4net.Info("Customer has been successfully created");
					CustomerCreationStatus cts = new CustomerCreationStatus();
					cts.Message = "Customer and its account has been successfully created.";
					cts.CustomerId = customer.CustomerId;

					return Ok(new { isSuccess = true, resMessage = "Customer and its account has been successfully created.", resObject = cts });
				}
				else
				{
					responseObj.isSuccess = false;
					responseObj.resMessage = "Couldn't create Customer or Account";
					responseObj.resObject = null;
					return BadRequest(new { isSuccess = false, resMessage = "Couldn't create Customer or Account" });
				}
			}
			catch (Exception e)
			{
				_log4net.Error("Error occurred while calling post method" + e.Message);
				return new StatusCodeResult(500);
			}
		}
	}
}
