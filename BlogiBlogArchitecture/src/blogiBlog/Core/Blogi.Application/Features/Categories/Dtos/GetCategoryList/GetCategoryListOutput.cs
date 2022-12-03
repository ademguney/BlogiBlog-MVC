namespace Blogi.Application.Features.Categories.Dtos.GetCategoryList
{
    public class GetCategoryListOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Count { get; set; }
    }
}