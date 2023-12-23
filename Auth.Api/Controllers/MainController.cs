using Auth.Api.Controllers;
using Auth.Repository.Model.Common;
using Auth.Repository.Model.Entity;
using Auth.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Transactions;

namespace AuthApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MainController : BaseController
	{
		DBContext Context = new DBContext();
		public MainController(IUnitOfWork uow, DBContext _context)
		{
			Uow = uow;
			Context = _context;
		}

		[HttpGet("[action]")]
		public dynamic GetAllCorporateCustomer()
		{
			var res = Uow.Corporate_Customer_Tbl_Info.GetAll().Result;
			return res;
		}

		[HttpGet("[action]")]
		public dynamic GetAllIndividualCustomer()
		{
			var res = Uow.Individual_Customer_Tbl_Info.GetAll().Result;
			return res;
		}

		[HttpGet("[action]")]
		public dynamic GetAllProductInfo()
		{
			var res = Uow.Product_Service_Tbl_Info.GetAll().Result;
			return res;
		}

		[HttpGet("[action]")]
		public dynamic GetProductInfoByID(int ID)
		{
			var res = Uow.Product_Service_Tbl_Info.FirstOrDefault(x => x.ProductID == ID).Result;
			return res;
		}

		[HttpPost("[action]")]
		public SessionDataModel SaveData([FromBody] AllData entity)
		{
			SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=SinglePageTask;Integrated Security=True");
			try
			{
				SqlCommand MasterCmd = new SqlCommand("Meeting_Minutes_Master_Save_SP", con);
				con.Open();
				MasterCmd.CommandType = CommandType.StoredProcedure;
				MasterCmd.Parameters.Add(new SqlParameter("@CorporateCustomerID", entity.MasterData.CorporateCustomerID));
				MasterCmd.Parameters.Add(new SqlParameter("@IndividualCustomerID", entity.MasterData.IndividualCustomerID));
				MasterCmd.Parameters.Add(new SqlParameter("@Date", entity.MasterData.Date));
				MasterCmd.Parameters.Add(new SqlParameter("@Time", entity.MasterData.Time));
				MasterCmd.Parameters.Add(new SqlParameter("@MeetingPlace", entity.MasterData.MeetingPlace));
				MasterCmd.Parameters.Add(new SqlParameter("@AttendsFromClient", entity.MasterData.AttendsFromClient));
				MasterCmd.Parameters.Add(new SqlParameter("@AttendsFromHost", entity.MasterData.AttendsFromHost));
				MasterCmd.Parameters.Add(new SqlParameter("@MeetingAgenda", entity.MasterData.MeetingAgenda));
				MasterCmd.Parameters.Add(new SqlParameter("@MeetingDiscussion", entity.MasterData.MeetingDiscussion));
				MasterCmd.Parameters.Add(new SqlParameter("@MeetingDecision", entity.MasterData.MeetingDecision));
				//MasterCmd.ExecuteNonQuery();
				var MasterTableID = MasterCmd.ExecuteScalar();

				foreach (var item in entity.MasterDetailsData)
				{
					item.MasterTableID = Convert.ToInt32(MasterTableID);
					SqlCommand cmd = new SqlCommand("Meeting_Minutes_Details_Save_SP", con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@MasterTableID", item.MasterTableID));
					cmd.Parameters.Add(new SqlParameter("@ProductID", item.ProductID));
					cmd.Parameters.Add(new SqlParameter("@Qnty", item.Qnty));
					cmd.ExecuteNonQuery();
				}
				con.Close();
				//Console.ReadKey();
				return new SessionDataModel()
				{
					MsgCode = "200",
					Msg = "User Save Successfully",
				};
			}
			catch (Exception ex)
			{
				con.Close();
				//Console.ReadKey();
				return new SessionDataModel()
				{
					MsgCode = "500",
					Msg = ex.ToString(),
				};
			}
		}
	}
}
