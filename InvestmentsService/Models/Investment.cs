namespace InvestmentsService.Models
{
    public class Investment
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Discription { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
