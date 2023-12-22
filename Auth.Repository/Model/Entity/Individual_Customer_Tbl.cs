using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository.Model.Entity
{
	public class Individual_Customer_Tbl
	{
		[Key]
		public int CustomerID { get; set; }
		public string CustomerName { get; set; }
	}
}
