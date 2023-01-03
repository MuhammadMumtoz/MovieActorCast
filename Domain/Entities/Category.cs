namespace Domain.Entities;
public class Category{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public List<Movie> Movies { get; set; }
}