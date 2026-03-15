namespace Ecom.API.DTOs
{
    public record CategoryDto
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
    public record UpdateCategoryDto: CategoryDto
    {
        public int CategoryId { get; set; }
    }
}
