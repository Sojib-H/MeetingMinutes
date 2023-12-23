using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository.Model.Entity
{
	public class Product_Service_Tbl
	{
		[Key]
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string Unit { get; set; }
	}
}
