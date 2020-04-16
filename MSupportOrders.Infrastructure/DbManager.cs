using System;
using System.Collections.Generic;
using System.Configuration;
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

			//Get connection string from web.config file
			//ConnectionString with encrypted transport
			string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;


			connection.ConnectionString = strcon;

			command = new SqlCommand();
			command.Connection = connection;
			command.CommandType = CommandType.Text;



		}
	}
}
