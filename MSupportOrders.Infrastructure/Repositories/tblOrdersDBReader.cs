using MSupportOrders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Infrastructure.Repositories
{
	public class tblOrdersDBReader
	{

		private tblOrders order = new tblOrders();
		private List<tblOrders> orderslist = new List<tblOrders>();

		public List<tblOrders> ReadDB(SqlDataReader reader)
		{
			while (reader.Read())
			{
				var order = new tblOrders();
				// FILL PROPERTIES					

				order.Id = reader.GetInt32(0);
				order.CustomerId = reader.GetInt32(1);
				order.CreateDate = reader.GetDateTime(2);
				orderslist.Add(order);
			}

			return orderslist;
		}
	}
}
