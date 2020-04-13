using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSupportOrders.Domain.Models
{
	public class tblCustomer
	{
  public int Id { get; set; }
  public string Firstname { get; set; }
  public string Lastname { get; set; }
  public string Address1 { get; set; }
  public string Address2 { get; set; }
  public int Zip { get; set; }
  public string City { get; set; }
  public DateTime? Deleted { get; set; }
 }
}
