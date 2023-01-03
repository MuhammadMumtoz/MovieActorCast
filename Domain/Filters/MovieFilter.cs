namespace Domain.Filters;

public class MovieFilter: PaginationFilter
{

    public string? Name { get; set; }
    public int? CategoryId { get; set; }
    // public bool? SortAscending { get; set; }
    // public bool? SortDescending { get; set; }

    public MovieFilter():base()
    {
        
    }
    public MovieFilter(int pageNumber, int pageSize) :base(pageNumber,pageSize)
    {
        
    }
}