using MSupportOrders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Infrastructure.Repositories
{
	public class tblCustomerDBReader
	{

		private tblCustomer customer = new tblCustomer();
		private List<tblCustomer> customerlist = new List<tblCustomer>();

		public List<tblCustomer> ReadDB(SqlDataReader reader)
		{
			while (reader.Read())
			{
				var customer = new tblCustomer();
				// FILL PROPERTIES					
				customer.Id = reader.GetInt32(0);
				customer.Firstname = reader.GetString(1);
				customer.Lastname = reader.GetString(2);
				customer.Address1 = reader.GetString(3);
				customer.Address2 = reader.GetString(4);
				customer.Zip = reader.GetInt32(5);
				customer.City = reader.GetString(6);

				customerlist.Add(customer);
			}

			return customerlist;
		}
	}
}
