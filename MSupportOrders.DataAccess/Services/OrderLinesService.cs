using MSupportOrders.Domain.DataTransferObjects;
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
	public class OrderLinesService
	{
		/// <summary>
		/// ORDERLINES  SERVICE CLASS
		/// 
		/// 
		/// </summary>


		// return local return variables
		private DTOOrderlines _orderLines = new DTOOrderlines();
		private List<DTOOrderlines> _orderLinesList = new List<DTOOrderlines>();

		// DB reader from repository (! DTOBuilder not from model)
		private DTOOrderLinesBuilder _DTOOrderLinesBuilder = new DTOOrderLinesBuilder();

		// new copy of dbmanager with connection string from repository
		private DbManager _dbManager = new DbManager();


		public async Task<List<DTOOrderlines>> GetBy(int paramOrderId)
		{
			// open async connection
			_dbManager.command.CommandText = "select * from tblOrderLines where OrderId=@paramOrderId";
			_dbManager.command.Parameters.Add("paramOrderId", SqlDbType.Int).Value = paramOrderId;
			await _dbManager.connection.OpenAsync();
			SqlDataReader reader = await _dbManager.command.ExecuteReaderAsync().ConfigureAwait(false);

			// read from repository, return all from specific orderID
			_orderLinesList = _DTOOrderLinesBuilder.ReadDB(reader);
			_dbManager.connection.Close();
			return _orderLinesList;
		}
	}
}
