using MSupportOrders.DataAccess.Services;
using MSupportOrders.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MSupportOrders.API.Application.Controllers
{
	public class CustomersController : ApiController
	{
		private CustomerService customerservice = new CustomerService();

	
		[HttpGet]
		public async Task<tblCustomer> CustomerByID(int _paramID)
		{
			// get single client	
			return await customerservice.GetBy(_paramID).ConfigureAwait(false);
		}


		[HttpGet]
		public async Task<List<tblCustomer>> CustomersAll()
		{
			return await customerservice.GetAll().ConfigureAwait(false);
		}
	}
}