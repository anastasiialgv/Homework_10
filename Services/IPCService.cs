using EFCoreCodeFirst.DTOs;

namespace EFCoreCodeFirst.Services;

public interface IPCService
{
    Task<IEnumerable<PCResponseDto>> GetAllPcsAsync();
    Task<PCDetailsResponseDto?> GetPcDetailsByIdAsync(int id);
    Task<bool> DeletePcAsync(int id);
    Task<PCResponseDto> AddPcAsync(CreatePcDto dto); 
    Task UpdatePcAsync(int id, UpdatePcDto dto);
    
}