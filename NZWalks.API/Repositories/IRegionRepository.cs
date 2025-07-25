﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<bool> DeleteAsync(Guid id);
    }
}
