using MSupportOrders.Domain.DataTransferObjects;
using MSupportOrders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Infrastructure.Repositories
{
	public class DTOOrderWithOrderLinesBuilder
	{

		private DTOOrderWithOrderLines _DTOOrderWithOrderLines;

		public DTOOrderWithOrderLines Build(tblCustomer paramCustomer, tblOrders paramOrder, List<DTOOrderlines> paramOrderlines)
		{

			// build total order amount
			Decimal ordertotal = 0;
			foreach (var item in paramOrderlines)
			{
				ordertotal += item.OrderlineTotal;
			}

			//build output
			_DTOOrderWithOrderLines = new DTOOrderWithOrderLines
			{
				CreateDate = paramOrder.CreateDate,
				CustomerId = paramOrder.CustomerId,
				Id = paramOrder.Id,
				DTOOrderlines = paramOrderlines,
				OrderTotal = ordertotal,
				customer = paramCustomer
			};
			return _DTOOrderWithOrderLines;
		}


	}
}
