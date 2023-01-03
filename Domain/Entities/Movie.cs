namespace Domain.Entities;
public class Movie{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public DateTime MovieYear { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<Cast> Casts { get; set; }
}