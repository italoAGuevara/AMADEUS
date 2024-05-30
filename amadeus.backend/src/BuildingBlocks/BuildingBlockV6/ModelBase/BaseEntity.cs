namespace BuildingBlocks.ModelsBase
{
    public class BaseEntity 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime TmStmp { get; set; } = DateTime.UtcNow;
    }
}
