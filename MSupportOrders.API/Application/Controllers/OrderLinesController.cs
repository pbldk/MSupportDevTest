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
	public class OrderLinesController : ApiController
	{

		private OrderLinesService orderLinesService = new OrderLinesService();


		[HttpGet]
		public async Task<List<DTOOrderlines>> OrderlinesByOrderID()
		{
			return await orderLinesService.GetBy(4).ConfigureAwait(false); ;
		}



	}
}
