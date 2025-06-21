using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;
using InvestmentsService.Models;
using InvestmentsService.UseCases;
using Moq;

namespace NPVTests.InvestmentServiceTests
{
    class ReadInvestmentTests
    {
        [Fact]
        public void ReturnInvestmentsTests()
        {
            var investmentObject = new Investment()
            {
                Id = new Guid(),
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var investmentList = new List<Investment>();
            investmentList.Add(investmentObject);

            var ReadInvestmentObject = new ReadInvestmentDto()
            {
                Id = new Guid(),
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };
            var ReadInvestmentList = new List<ReadInvestmentDto>();
            ReadInvestmentList.Add(ReadInvestmentObject);

            var mockedInvestmentRepo = new Mock<IInvestmentRepo>();
            var mockedInvestmentMapper = new Mock<IMapper>();

            mockedInvestmentRepo.Setup(m => m.GetAllInvestments()).Returns(investmentList);
            mockedInvestmentMapper.Setup(m => m.Map<IEnumerable<ReadInvestmentDto>>(It.IsAny<IEnumerable<Investment>>())).Returns(ReadInvestmentList);

            var GetAllInvestments = new GetAllInvestmentsUseCase(mockedInvestmentRepo.Object, mockedInvestmentMapper.Object);

            var results = GetAllInvestments.ExacuteAsync();

            Assert.Equal(investmentList.First().Id, results.First().Id);
        }
    }
}
