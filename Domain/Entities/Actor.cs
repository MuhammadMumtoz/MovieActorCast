namespace Domain.Entities;
public class Actor{
    public int ActorId { get; set; }
    public string Fullname { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthYear { get; set; }
    public DateTime DeathYear { get; set; }
    public List<Cast> Casts { get; set; }
}

public enum Gender{
    male,
    female
}