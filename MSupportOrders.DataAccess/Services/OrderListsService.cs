using MSupportOrders.Domain.DataTransferObjects;
using MSupportOrders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.DataAccess.Services
{
public	class OrderListsService
	{
		// return variables
		private tblOrders _order = new tblOrders();

		private DTOOrderWithTotal _DTOOrderWithTotal = new DTOOrderWithTotal();
		private DTOOrderWithOrderLines _DTOOrderWithOrderLines = new DTOOrderWithOrderLines();
		private List<tblOrders> _orderlist = new List<tblOrders>();
		private List<DTOOrderWithOrderLines> _completeorderlist = new List<DTOOrderWithOrderLines>();
		private List<DTOOrderWithTotal> _orderlinelist = new List<DTOOrderWithTotal>();

		// link to other helper services
		private OrderService orderService = new OrderService();

		public async Task<List<DTOOrderWithTotal>> GetWithOrderTotalsList(int _paramFrom, int _paramTo)
		{
			_orderlist = await orderService.GetList(_paramFrom, _paramTo).ConfigureAwait(false);

			foreach (var item in _orderlist)
			{


				// init dependency
				OrderService orderService = new OrderService();
				_DTOOrderWithTotal = new DTOOrderWithTotal();
				_DTOOrderWithTotal = await Task.Run(() => orderService.GetWithOrderTotals(item.Id)).ConfigureAwait(false);

				if (_DTOOrderWithTotal == null)
				{
					// do nothing, customer doesnt exist
				}
				else
				{
					_orderlinelist.Add(_DTOOrderWithTotal);
				}
			};
			return _orderlinelist;
		}
	}
}
