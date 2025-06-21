namespace InvestmentsService.Dtos;

public class ReadInvestmentDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Discription { get; set; }
    public decimal DiscountRate { get; set; }
}
