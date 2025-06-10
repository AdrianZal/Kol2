using WebAPI.DTOs;

namespace WebAPI.Services;

public interface IDbService
{
    Task<PlayerMatchesDto> GetOrderById(int playerId);
    Task FulfillOrder(int orderId, FulfillOrderDto dto);
}
