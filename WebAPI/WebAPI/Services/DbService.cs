using System.Data;
using WebAPI.DTOs;
using WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PlayerMatchesDto> GetOrderById(int playerId)
    {
        var playerMatches = await _context.PlayerMatches
            .Select(e => new PlayerMatchesDto
            {
                PlayerId = e.PlayerId,
                FirstName = e.Player.FirstName,
                LastName = e.Player.LastName,
                BirthDate = e.Player.BirthDate,
                
                Matches = e.Matches.Select(e => new MatchDto()
                {
                    Tournament = e.Match.Tournament.Name,
                    Map = e.Match.Map.Name,
                    Date = e.Match.MatchDate,
                    MVPs = e.MVPs,
                    Rating = e.Rating,
                    Team1Score = e.Match.Team1Score,
                    Team2Score = e.Match.Team2Score,
                }).ToList()
            })
            .FirstOrDefaultAsync(e => e.PlayerId == playerId);

        if (playerMatches is null)
            throw new NotFoundException();

        return playerMatches;

    }

    public async Task FulfillOrder(int orderId, FulfillOrderDto dto)
    {
        // using var transaction = await _context.Database.BeginTransactionAsync();
        //
        // try
        // {
        //     var order = await _context.Orders
        //         .FirstOrDefaultAsync(o => o.MatchId == orderId);
        //
        //     if (order is null)
        //         throw new NotFoundException("Order not found.");
        //
        //     var status = await _context.Statuses.FirstOrDefaultAsync(s => s.Name.Equals(dto.StatusName));
        //     if (status is null)
        //         throw new NotFoundException("Status not found.");
        //
        //     if (order.MatchDate != null)
        //         throw new ConflictException("Order already fulfilled.");
        //
        //     order.StatusId = status.TournamentId;
        //     order.MatchDate = DateTime.Now;
        //
        //     var relatedProducts = _context.ProductOrders.Where(po => po.OrderId == orderId);
        //     _context.ProductOrders.RemoveRange(relatedProducts);
        //
        //     await _context.SaveChangesAsync();
        //     await transaction.CommitAsync();
        // }
        // catch (Exception ex)
        // {
        //     await transaction.RollbackAsync();
        //     throw;
        // }
    }
}