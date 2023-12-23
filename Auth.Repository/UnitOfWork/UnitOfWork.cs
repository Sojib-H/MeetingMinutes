using Auth.Repository.Model.Entity;
using Auth.Repository.Repository;

namespace Auth.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBContext _context { get; set; }
        public UnitOfWork(DBContext context)
        {
            this._context = context;
        }

		private IRepository<Corporate_Customer_Tbl> _Corporate_Customer_Tbl_Info;
        public IRepository<Corporate_Customer_Tbl> Corporate_Customer_Tbl_Info
		{
            get
            {
                if (this._Corporate_Customer_Tbl_Info == null)
                {
                    this._Corporate_Customer_Tbl_Info = new GenericRepository<Corporate_Customer_Tbl>(_context);
                }
                return _Corporate_Customer_Tbl_Info;
            }
        }

		private IRepository<Individual_Customer_Tbl> _Individual_Customer_Tbl_Info;
		public IRepository<Individual_Customer_Tbl> Individual_Customer_Tbl_Info
		{
			get
			{
				if (this._Individual_Customer_Tbl_Info == null)
				{
					this._Individual_Customer_Tbl_Info = new GenericRepository<Individual_Customer_Tbl>(_context);
				}
				return _Individual_Customer_Tbl_Info;
			}
		}

		private IRepository<Meeting_Minutes_Details_Tbl> _Meeting_Minutes_Details_Tbl_Info;
		public IRepository<Meeting_Minutes_Details_Tbl> Meeting_Minutes_Details_Tbl_Info
		{
			get
			{
				if (this._Meeting_Minutes_Details_Tbl_Info == null)
				{
					this._Meeting_Minutes_Details_Tbl_Info = new GenericRepository<Meeting_Minutes_Details_Tbl>(_context);
				}
				return _Meeting_Minutes_Details_Tbl_Info;
			}
		}

		private IRepository<Meeting_Minutes_Master_Tbl> _Meeting_Minutes_Master_Tbl_Info;
		public IRepository<Meeting_Minutes_Master_Tbl> Meeting_Minutes_Master_Tbl_Info
		{
			get
			{
				if (this._Meeting_Minutes_Master_Tbl_Info == null)
				{
					this._Meeting_Minutes_Master_Tbl_Info = new GenericRepository<Meeting_Minutes_Master_Tbl>(_context);
				}
				return _Meeting_Minutes_Master_Tbl_Info;
			}
		}

		private IRepository<Product_Service_Tbl> _Product_Service_Tbl_Info;
		public IRepository<Product_Service_Tbl> Product_Service_Tbl_Info
		{
			get
			{
				if (this._Product_Service_Tbl_Info == null)
				{
					this._Product_Service_Tbl_Info = new GenericRepository<Product_Service_Tbl>(_context);
				}
				return _Product_Service_Tbl_Info;
			}
		}
	}
}
