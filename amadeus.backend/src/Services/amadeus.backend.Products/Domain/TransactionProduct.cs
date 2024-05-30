namespace Domain
{
    public class TransactionProduct : BaseEntity
    {
        public string User { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public uint FinalStockQuantity { get; set; }
        
    }
}
