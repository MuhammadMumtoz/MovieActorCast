namespace Domain.Filters;

public class CategoryFilter: PaginationFilter
{

    public string? Name { get; set; }
    // public bool? SortAscending { get; set; }
    // public bool? SortDescending { get; set; }

    public CategoryFilter():base()
    {
        
    }
    public CategoryFilter(int pageNumber, int pageSize) :base(pageNumber,pageSize)
    {
        
    }
}