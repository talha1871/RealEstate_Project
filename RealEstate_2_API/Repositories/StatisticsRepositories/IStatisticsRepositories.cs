namespace RealEstate_2_API.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepositories
    {
        public int CategoryCount(); // Yapıldı-3

        public int ActiveCategoryCount(); // Yapıldı-1
        public int PassiveCategoryCount(); // Yapıldı-4

        public int TotalProductCount(); // Yapıldı-5

        public int ApartmentCount(); // Yapıldı-6

        public string EmployeeNameByMaxProductCount(); //Yapıldı-13
        public string CategoryNameByMaxProductCount(); //Yapıldı-11
        public decimal AverageProductPriceByRent(); //Yapıldı-9
        public decimal AverageProductPriceBySale(); //Yapıldı-10

        public string CityNameByMaxProductCount(); //Yapıldı-12

        public int DifferentCityCount(); // Yapıldı-7

        public decimal LastProductPrice(); // Yapıldı-14

        public string TheNewestBuilding();// Yapıldı-15
        public string TheOldestBuilding(); // Yapıldı-16

        public int AverageRoomCount(); // Yapıldı-8

        public int ActiveEmployeeCount(); // Yapıldı-2

    }
}
