namespace RealEstate_2_API.Dtos.ProductDtos
{
    public class CreateProductDto
    {
      
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string ProductAddress { get; set; }
        public int ProductCategory { get; set; }

        public int EmployeeID { get; set; }
    }
}
