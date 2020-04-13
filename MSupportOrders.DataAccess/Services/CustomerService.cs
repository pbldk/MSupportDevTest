using MSupportOrders.Domain.Models;
using MSupportOrders.Infrastructure;
using MSupportOrders.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MSupportOrders.DataAccess.Services
{
	public class CustomerService
	{
	/// <summary>
	/// CUSTOMER SERVICE CLASS
	/// </summary>
	

	// create local return variables
		private tblCustomer _customer = new tblCustomer();
		private List<tblCustomer> _customerlist = new List<tblCustomer>();

		// DB reader from repository
		private tblCustomerDBReader _tblCustomerDBReader = new tblCustomerDBReader();

		// new copy of dbmanager with connection string from repository
		private DbManager _dbManager = new DbManager();

		public async Task<List<tblCustomer>> GetAll()
		{
			// open async connection, filter out zip=1234 domain model rule for deleted
			_dbManager.command.CommandText = "select * from tblCustomer where not zip=1234";
			await _dbManager.connection.OpenAsync();
			SqlDataReader reader = await _dbManager.command.ExecuteReaderAsync().ConfigureAwait(false);

			// read from repository
			_customerlist = _tblCustomerDBReader.ReadDB(reader);
			_dbManager.connection.Close();
			return _customerlist;
		}

		public async Task<tblCustomer> GetBy(int paramObj)
		{
			// return cold if non existing
			_customer.Firstname = "DOESNT EXIST";

			// open async connection
			_dbManager.command.CommandText = "select * from tblCustomer where Id=@paramObj";
			_dbManager.command.Parameters.Add("paramObj", SqlDbType.Int).Value = paramObj;
			await _dbManager.connection.OpenAsync();
			SqlDataReader reader = await _dbManager.command.ExecuteReaderAsync().ConfigureAwait(false);

			// read from repository, return only first
			_customer = _tblCustomerDBReader.ReadDB(reader).FirstOrDefault();
			_dbManager.connection.Close();
			return _customer;
		}
	}
}

