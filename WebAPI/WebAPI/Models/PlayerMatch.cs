using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

[Table("Player_Match")]
[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
public class PlayerMatch
{
    [ForeignKey(nameof(Match))]
    public int MatchId { get; set; }
    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }
    public int MVPs { get; set; }
    
    [Column(TypeName = "numeric")]
    [Precision(4, 2)]
    public double Rating { get; set; }
    
    public Match Match { get; set; } = null!;
    public Player Player { get; set; } = null!;
    
}