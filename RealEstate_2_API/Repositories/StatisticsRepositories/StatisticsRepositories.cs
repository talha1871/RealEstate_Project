using Dapper;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.StatisticsRepositories
{
    public class StatisticsRepositories : IStatisticsRepositories
    {

        private readonly Context _context;

        public StatisticsRepositories(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "select Count(*) from Category where CategoryStatus=1";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "select Count(*) from Employee where Status=1";
             using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query = "select Count(*) from ProductTwo where ProductTitle like '%Daire%'";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "select Avg(ProductPrice) from ProductTwo where ProductType = 'Satılık'";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "select Avg(ProductPrice) from ProductTwo where ProductType = 'Kiralık'";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AverageRoomCount()
        {
            string query = "select Avg(RoomCount) from ProductDetails";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "select Count(*) from Category";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select top(1) CategoryName,Count(*) From ProductTwo inner join Category On ProductTwo.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "select Top(1) ProductCity, count(*) as[İlan_Sayısı] from ProductTwo group by ProductCity order by İlan_Sayısı desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }

        }

        public int DifferentCityCount()
        {
            string query = "select Count(Distinct(ProductCity)) from ProductTwo";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "select Name, count(*) as 'product_count' from ProductTwo inner join Employee on ProductTwo.EmployeeID = Employee.EmployeeID\r\ngroup by Name order by product_count desc";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "select top(1) ProductPrice from ProductTwo order by ProductID desc";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "select Count(*) from Category where CategoryStatus=0";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string TheNewestBuilding()
        {
            string query = "select top(1) BuildYear from ProductDetails order by BuildYear desc";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string TheOldestBuilding()
        {
            string query = "select top(1) BuildYear from ProductDetails order by BuildYear asc";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int TotalProductCount()
        {
            string query = "select Count(*) from ProductTwo";
            using (var cnt = _context.CreateConnection())
            {
                var values = cnt.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
