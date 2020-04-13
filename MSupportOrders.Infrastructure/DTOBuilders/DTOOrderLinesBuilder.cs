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
	public class DTOOrderLinesBuilder
	{

		private DTOOrderlines DTOorderline = new DTOOrderlines();
		private List<DTOOrderlines> orderlinelist = new List<DTOOrderlines>();

		public List<DTOOrderlines> ReadDB(SqlDataReader reader)
		{
			while (reader.Read())
			{
				var DTOorderline = new DTOOrderlines();
				// FILL PROPERTIES					
				DTOorderline.Id = reader.GetInt32(0);
				DTOorderline.OrderId = reader.GetInt32(1);
				DTOorderline.ItemText = reader.GetString(2);
				DTOorderline.Price = reader.GetDecimal(3);
				DTOorderline.Quantity = reader.GetInt32(4);

				DTOorderline.OrderlineTotal = DTOorderline.Quantity * DTOorderline.Price;


				orderlinelist.Add(DTOorderline);
			}

			return orderlinelist;
		}
	}
}
