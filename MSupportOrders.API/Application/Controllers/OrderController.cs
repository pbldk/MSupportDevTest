
using MSupportOrders.DataAccess.Services;
using MSupportOrders.Domain.DataTransferObjects;
using MSupportOrders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MSupportOrders.API.Application.Controllers
{
	public class OrderController : ApiController
	{

		private OrderService orderService = new OrderService();
		private OrderListsService orderListsService = new OrderListsService();

		[HttpGet]
		public async Task<List<tblOrders>> OrdersByCustomerID(int _paramID)
		{
			// get orderlines
			return await orderService.GetBy(_paramID).ConfigureAwait(false); ;
		}




		[HttpGet]
		public async Task<List<tblOrders>> OrdersList(int _paramFrom, int _paramTo)
		{
			return await orderService.GetList(_paramFrom, _paramTo).ConfigureAwait(false); ;
		}



		[HttpGet]
		public async Task<DTOOrderWithOrderLines> OrderCompleteWithOrderlines(int _paramOrderID)
		{
			return await orderService.GetWithOrderLines(_paramOrderID).ConfigureAwait(false); ;
		}

		[HttpGet]
		public async Task<List<DTOOrderWithTotal>> OrderWithTotalsList(int _paramFrom, int _paramTo)
		{
			return await orderListsService.GetWithOrderTotalsList(_paramFrom, _paramTo).ConfigureAwait(false); ;
		}


	}
}
