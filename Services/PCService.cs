using EFCoreCodeFirst.Data;
using EFCoreCodeFirst.DTOs;
using EFCoreCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Services;

public class PCService : IPCService
{
    private readonly AppDbContext _context;

    public PCService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PCResponseDto>> GetAllPcsAsync()
    {
        return await _context.PCs
            .Select(p => new PCResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            }).ToListAsync();
    }

    public async Task<PCDetailsResponseDto?> GetPcDetailsByIdAsync(int id)
    {
        var pc = await _context.PCs
            .Include(p => p.PCComponents)
                .ThenInclude(pc => pc.Component)
                    .ThenInclude(c => c.Manufacturer)
            .Include(p => p.PCComponents)
                .ThenInclude(pc => pc.Component)
                    .ThenInclude(c => c.Type)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null) return null;

        return new PCDetailsResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
            Components = pc.PCComponents.Select(pcc => new PCComponentDto
            {
                Amount = pcc.Amount,
                Component = new ComponentDto
                {
                    Code = pcc.Component.Code,
                    Name = pcc.Component.Name,
                    Description = pcc.Component.Description,
                    Manufacturer = new ManufacturerDto
                    {
                        Id = pcc.Component.Manufacturer.Id,
                        Abbreviation = pcc.Component.Manufacturer.Abbreviation,
                        FullName = pcc.Component.Manufacturer.FullName,
                        FoundationDate = pcc.Component.Manufacturer.FoundationDate
                    },
                    Type = new TypeDto
                    {
                        Id = pcc.Component.Type.Id,
                        Abbreviation = pcc.Component.Type.Abbreviation,
                        Name = pcc.Component.Type.Name
                    }
                }
            })
        };
    }

    public async Task UpdatePcAsync(int id, UpdatePcDto dto)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) throw new KeyNotFoundException(); 

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> DeletePcAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<PCResponseDto> AddPcAsync(CreatePcDto dto)
    {
        var newPc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(newPc);
        await _context.SaveChangesAsync();

        return new PCResponseDto
        {
            Id = newPc.Id,
            Name = newPc.Name,
            Weight = newPc.Weight,
            Warranty = newPc.Warranty,
            CreatedAt = newPc.CreatedAt,
            Stock = newPc.Stock
        };
    }
}