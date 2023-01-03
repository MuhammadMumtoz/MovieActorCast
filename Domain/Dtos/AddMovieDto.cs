namespace Domain.Dtos;
public class AddMovieDto{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public DateTime MovieYear { get; set; }
    public int CategoryId { get; set; }
}