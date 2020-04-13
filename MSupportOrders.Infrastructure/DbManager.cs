using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Infrastructure
{
	public class DbManager
	{
public		SqlConnection connection;
public 	SqlCommand command;
		public DbManager()
		{
			connection = new SqlConnection();
//			connection.ConnectionString = @"Data Source=XXXXXX;Initial Catalog=XXXXX;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


//Online string with encrypted transport, must be moved to config file
            connection.ConnectionString = @"xxxxxxxxxxxxxxxxxxxxxxxxxxx";

			command = new SqlCommand();
			command.Connection = connection;
			command.CommandType = CommandType.Text;



		}
	}
}
