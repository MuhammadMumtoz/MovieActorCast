namespace Domain.Dtos;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class GetActorDto
{
    public int ActorId { get; set; }
    public string Fullname { get; set; }
    public Gender Gender { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime BirthYear { get; set; }
    public DateTime DeathYear { get; set; }
}