using MSupportOrders.Domain.DataTransferObjects;
using MSupportOrders.Domain.Models;
using MSupportOrders.Infrastructure;
using MSupportOrders.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MSupportOrders.DataAccess.Services
{
	public class OrderService
	{
		/// <summary>
		///  ORDER SERVICE CLASS
		///
		/// </summary>

		// return variables
		private tblOrders _order = new tblOrders();
		private List<tblOrders> _orderlist = new List<tblOrders>();


		// datatransfer object return variable
		private DTOOrderWithOrderLines _DTOOrderWithOrderLines;
		private DTOOrderWithTotal _DTOOrderWithTotal;
		

		// DB reader from repository
		private tblOrdersDBReader _tblOrdersDBReader = new tblOrdersDBReader();
		private DTOOrderWithOrderLinesBuilder _DTOOrderWithOrderLinesBuilder = new DTOOrderWithOrderLinesBuilder(); private DTOOrderWithTotalsBuilder _DTOOrderWithTotalsBuilder = new DTOOrderWithTotalsBuilder();

		// new copy of dbmanager with connection string from repository
		private DbManager _dbManager = new DbManager();

		// link to other helper services
		private OrderLinesService orderLinesService = new OrderLinesService();
		private CustomerService customerService = new CustomerService();




		/// <summary>
		/// GetBy() returns a list of orders based on a specific customer
		/// </summary>
		/// <param name="paramCustomerId"></param>
		/// <returns>_orderlist</returns>

		public async Task<List<tblOrders>> GetBy(int paramCustomerId)
		{
			// open async connection
			_dbManager.command.CommandText = "select * FROM tblOrders WHERE customerID=@paramCustomerId";
			_dbManager.command.Parameters.Add("paramCustomerId", SqlDbType.Int).Value = paramCustomerId;
			await _dbManager.connection.OpenAsync();
			SqlDataReader reader = await _dbManager.command.ExecuteReaderAsync().ConfigureAwait(false);

			// read from repository
			_orderlist = _tblOrdersDBReader.ReadDB(reader);
			_dbManager.connection.Close();
			return _orderlist;
		}





		/// <summary>
		/// GetAll() returns all orders except deleted from database
		///
		/// _paramTypes setup for use with paging and sorttypes
		/// </summary>
		/// <returns>_orderlist</returns>
		public async Task<List<tblOrders>> GetList(int _paramFrom, int _paramTo)
		{

			// use paging !else massive result
			_dbManager.command.CommandText = "select * from tblOrders WHERE deleted IS NULL ORDER BY CreateDate DESC	OFFSET @_paramFrom ROWS	FETCH NEXT @_paramTo ROWS ONLY";
			_dbManager.command.Parameters.Add("_paramFrom", SqlDbType.Int).Value = _paramFrom;
			_dbManager.command.Parameters.Add("_paramTo", SqlDbType.Int).Value = _paramTo;


			await _dbManager.connection.OpenAsync();
			SqlDataReader reader = await _dbManager.command.ExecuteReaderAsync().ConfigureAwait(false);

			// read from repository
			_orderlist = _tblOrdersDBReader.ReadDB(reader);
			_dbManager.connection.Close();
			return _orderlist;
		}




		/// <summary>
		/// GetWithOrderLines() build a DTOobject list and returns a complete order with orderlines and total amount calculated
		/// </summary>
		/// <param name="paramOrderID"></param>
		/// <returns>_orderlist</returns>
		public async Task<DTOOrderWithOrderLines> GetWithOrderLines(int paramOrderID)
		{
			// open async connection reader order get by order ID
			_dbManager.command.CommandText = "select * FROM tblOrders WHERE id=@paramOrderID";
			_dbManager.command.Parameters.Add("paramOrderID", SqlDbType.Int).Value = paramOrderID;
			await _dbManager.connection.OpenAsync();
			SqlDataReader reader = await _dbManager.command.ExecuteReaderAsync().ConfigureAwait(false);
			_order = _tblOrdersDBReader.ReadDB(reader).FirstOrDefault();
			_dbManager.connection.Close();

			// get lines from services
			var orderlines = await orderLinesService.GetBy(paramOrderID).ConfigureAwait(false);
			var customer = await customerService.GetBy(_order.CustomerId).ConfigureAwait(false);

			// break if customer is deleted
			if (customer.Zip == 1234)
			{
				return null;
			}

			//build output
			_DTOOrderWithOrderLines = _DTOOrderWithOrderLinesBuilder.Build(customer, _order, orderlines);
			return _DTOOrderWithOrderLines;
		}



		/// <summary>
		/// 
		/// GetWithOrderTotals() build a DTOobject list and returns a complete order withOUT orderlines and WITH total amount calculated
		/// </summary>
		/// <param name="paramOrderID"></param>
		/// <returns>_orderlist</returns>
		public async Task<DTOOrderWithTotal> GetWithOrderTotals(int paramOrderID)
		{
			// open async connection reader order get by order ID
			_dbManager.command.CommandText = "select * FROM tblOrders WHERE id=@paramOrderID AND deleted IS NULL";
			_dbManager.command.Parameters.Add("paramOrderID", SqlDbType.Int).Value = paramOrderID;
			await _dbManager.connection.OpenAsync();
			SqlDataReader reader = await _dbManager.command.ExecuteReaderAsync().ConfigureAwait(false);
			_order = _tblOrdersDBReader.ReadDB(reader).FirstOrDefault();
			_dbManager.connection.Close();

			// get lines from services
			var orderlines = await orderLinesService.GetBy(paramOrderID).ConfigureAwait(false);
			var customer = await customerService.GetBy(_order.CustomerId).ConfigureAwait(false);
			// break if customer is deleted
			if (customer.Zip == 1234)
			{
				return null;
			}

			//build output
			_DTOOrderWithTotal = _DTOOrderWithTotalsBuilder.Build(customer, _order, orderlines);
			return _DTOOrderWithTotal;
		}

	}
}