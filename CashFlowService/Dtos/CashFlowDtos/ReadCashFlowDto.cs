namespace CashFlowService.Dtos.CashFlowDtos
{
    public class ReadCashFlowDto
    {
        public Guid Id { get; set; }
        public Guid InvestmentId { get; set; }
        public DateTime DateAdded { get; set; }
        public Double Cashflow { get; set; }
    }
}
