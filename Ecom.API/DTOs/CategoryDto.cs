namespace Ecom.API.DTOs
{
    public record CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public record UpdateCategoryDto: CategoryDto
    {
        public int Id { get; set; }
    }
}
