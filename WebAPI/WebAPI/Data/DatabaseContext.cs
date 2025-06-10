using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasData(new List<Player>()
        {
            new Player() { PlayerId = 1, FirstName = "John", LastName = "Doe", BirthDate = DateTime.Parse("2000-05-04")},
            new Player() { PlayerId = 2, FirstName = "Jane", LastName = "Doe", BirthDate = DateTime.Parse("1998-05-04") },
            new Player() { PlayerId = 3, FirstName = "Julie", LastName = "Doe", BirthDate = DateTime.Parse("1998-05-04") },
        });

        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>()
        {
            new Tournament() { TournamentId = 1, Name = "1st", StartDate = DateTime.Parse("2000-05-04"), EndDate = DateTime.Parse("2000-05-07")},
            new Tournament() { TournamentId = 2, Name = "2nd", StartDate = DateTime.Parse("2000-06-04"), EndDate = DateTime.Parse("2000-06-07")},
            new Tournament() { TournamentId = 3, Name = "3rd", StartDate = DateTime.Parse("2000-07-04"), EndDate = DateTime.Parse("2000-07-07")},
        });

        modelBuilder.Entity<Map>().HasData(new List<Map>()
        {
            new Map() { MapId = 1, Name = "Mirage", Type = "5v5" }, 
            new Map() { MapId = 2, Name = "Dust", Type = "5v5" }, 
            new Map() { MapId = 3, Name = "Inferno", Type = "2v2" },
        });

        modelBuilder.Entity<Match>().HasData(new List<Match>()
        {
            new Match() {MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = DateTime.Parse("2000-05-04"), Team1Score = 13, Team2Score = 9, BestRating = 2.25},
            new Match() {MatchId = 2, TournamentId = 2, MapId = 3, MatchDate = DateTime.Parse("2000-06-04"), Team1Score = 13, Team2Score = 9, BestRating = 2.25},
        });

        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>()
        {
            new PlayerMatch() {MatchId = 1, PlayerId = 1, MVPs = 13, Rating = 4.65},
            new PlayerMatch() {MatchId = 1, PlayerId = 2, MVPs = 17, Rating = 4.15},
            new PlayerMatch() {MatchId = 2, PlayerId = 3, MVPs = 15, Rating = 4.55},
        });
    }
}