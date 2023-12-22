using Auth.Repository.Model.Entity;
using Auth.Repository.Repository;
namespace Auth.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Corporate_Customer_Tbl> Corporate_Customer_Tbl_Info { get; }
        IRepository<Individual_Customer_Tbl> Individual_Customer_Tbl_Info { get; }
        IRepository<Meeting_Minutes_Details_Tbl> Meeting_Minutes_Details_Tbl_Info { get; }
        IRepository<Meeting_Minutes_Master_Tbl> Meeting_Minutes_Master_Tbl_Info { get; }
        IRepository<Product_Service_Tbl> Product_Service_Tbl_Info { get; }
    }
}
