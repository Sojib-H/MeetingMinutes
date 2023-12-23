using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository.Model.Entity
{
	public class AllData
	{
		public Meeting_Minutes_Master_Tbl MasterData { get; set; }
		public List<Meeting_Minutes_Details_Tbl> MasterDetailsData { get; set; }
	}
}
