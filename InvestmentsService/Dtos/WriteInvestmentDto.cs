namespace InvestmentsService.Dtos
{
    public class WriteInvestmentDto
    {
        public required string Name { get; set; }
        public required string Discription { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
