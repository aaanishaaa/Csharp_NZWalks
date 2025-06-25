namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public double Length { get; set; }
        public string ? ImageUrl { get; set; } = string.Empty;
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        //Navigation properties
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
