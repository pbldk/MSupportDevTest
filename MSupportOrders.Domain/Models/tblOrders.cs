using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Domain.Models
{
	public class tblOrders
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? Deleted { get; set; }
	}
}
