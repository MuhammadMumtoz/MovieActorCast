namespace Domain.Dtos;
public class GetCastMovieDto
{
    public int CastId { get; set; }
    public int MovieId { get; set; }
    public string MovieTitle { get; set; }
    public int ActorId { get; set; }
    public string ActorFullname { get; set; }
}