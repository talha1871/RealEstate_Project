namespace RealEstate_2_API.Dtos.EmployeeDtos
{
    public class UpdateEmployeeDto
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
