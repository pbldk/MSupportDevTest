using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Domain.Models
{
	public class tblOrderLines
	{
  public int Id { get; set; }
  public int OrderId { get; set; }
  public string ItemText { get; set; }
  public decimal Price { get; set; }
  public int Quantity { get; set; }
  public DateTime? Deleted { get; set; }
 }
}
