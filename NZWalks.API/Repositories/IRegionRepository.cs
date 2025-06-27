using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        //Task<Models.Domain.Region?> GetByIdAsync(Guid id);
        //Task<Models.Domain.Region> AddAsync(Models.Domain.Region region);
        //Task<Models.Domain.Region?> UpdateAsync(Guid id, Models.Domain.Region region);
        //Task<bool> DeleteAsync(Guid id);
    }
}
