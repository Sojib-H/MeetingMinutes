using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository.Model.Entity
{
	public class Meeting_Minutes_Details_Tbl
	{
		[Key]
		public int MasterDetailsID { get; set; }
		public int MasterTableID { get; set; }
		public int ProductID { get; set; }
		public int Qnty { get; set; }
	}
}
