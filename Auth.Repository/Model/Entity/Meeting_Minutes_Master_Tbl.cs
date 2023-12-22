using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository.Model.Entity
{
	public class Meeting_Minutes_Master_Tbl
	{
		[Key]
		public int MasterTableID { get; set; }
		public int CorporateCustomerID { get; set; }
		public int IndividualCustomerID { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Time { get; set; }
		public string MeetingPlace { get; set; }
		public string AttendsFromClient { get; set; }
		public string AttendsFromHost { get; set; }
		public string MeetingAgenda { get; set; }
		public string MeetingDiscussion { get; set; }
		public string MeetingDecision { get; set; }
	}
}
