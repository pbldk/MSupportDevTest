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
	public class DTOOrderWithTotalsBuilder
	{

		private DTOOrderWithTotal _DTOOrderWithTotal;

		public DTOOrderWithTotal Build(tblCustomer paramCustomer, tblOrders paramOrder, List<DTOOrderlines> paramOrderlines)
		{

			// build total order amount
			Decimal ordertotal = 0;
			foreach (var item in paramOrderlines)
			{
				ordertotal += item.OrderlineTotal;
			}

			//build output
			_DTOOrderWithTotal = new DTOOrderWithTotal
			{
				CreateDate = paramOrder.CreateDate,
				CustomerId = paramOrder.CustomerId,
				CustomerName = paramCustomer.Firstname + " " + paramCustomer.Lastname,
				Id = paramOrder.Id,
				OrderTotal = ordertotal
			};
			return _DTOOrderWithTotal;
		}


	}
}
