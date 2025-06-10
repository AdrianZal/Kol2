using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

[Table("Map")]
public class Map
{
    [Key]
    public int MapId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string Type { get; set; } = null!;


    public ICollection<Match> Matches { get; set; } = null!;
}