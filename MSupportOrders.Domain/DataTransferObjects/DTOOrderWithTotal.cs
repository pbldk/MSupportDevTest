using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Domain.DataTransferObjects
{
	public class DTOOrderWithTotal
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? Deleted { get; set; }
		public Decimal OrderTotal { get; set; }

	}
}
