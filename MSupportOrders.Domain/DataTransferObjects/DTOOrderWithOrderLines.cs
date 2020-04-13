using MSupportOrders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Domain.DataTransferObjects
{
	public class DTOOrderWithOrderLines
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? Deleted { get; set; }
		public Decimal OrderTotal { get; set; }

		public tblCustomer customer { get; set; }
		public List<DTOOrderlines> DTOOrderlines { get; set; }
	}
}
