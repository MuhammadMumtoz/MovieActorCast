namespace Domain.Dtos;
using Domain.Entities;
public class AddActorDto{
    public int ActorId { get; set; }
    public string Fullname { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthYear { get; set; }
    public DateTime DeathYear { get; set; }
}