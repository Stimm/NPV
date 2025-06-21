using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;
using InvestmentsService.Models;
using InvestmentsService.UseCases;
using InvestmentsService.UseCases.GetInvestmentById;
using Moq;

namespace NPVTests.InvestmentServiceTests
{
    public class ReadInvestmentTests
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
                Id = investmentObject.Id,
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

        [Fact]
        public void ReturnInvestmentTest()
        {
            var investmentObject = new Investment()
            {
                Id = new Guid(),
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var ReadInvestmentObject = new ReadInvestmentDto()
            {
                Id = investmentObject.Id,
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var mockedInvestmentRepo = new Mock<IInvestmentRepo>();
            var mockedInvestmentMapper = new Mock<IMapper>();

            mockedInvestmentRepo.Setup(m => m.GetInvestment(It.IsAny<Guid>())).Returns(investmentObject);
            mockedInvestmentMapper.Setup(m => m.Map<ReadInvestmentDto>(It.IsAny<Investment>())).Returns(ReadInvestmentObject);

            var getInvestmentById = new GetInvestmentById(mockedInvestmentRepo.Object, mockedInvestmentMapper.Object);

            var results = getInvestmentById.ExacuteAsync(investmentObject.Id);

            Assert.Equal(investmentObject.Id, results.Id);
        }

        [Fact]
        public void ReturnNullInvestmentNotFoundTest()
        {
            var investmentObject = new Investment()
            {
                Id = new Guid(),
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var ReadInvestmentObject = new ReadInvestmentDto()
            {
                Id = investmentObject.Id,
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var mockedInvestmentRepo = new Mock<IInvestmentRepo>();
            var mockedInvestmentMapper = new Mock<IMapper>();

            mockedInvestmentRepo.Setup(m => m.GetInvestment(It.IsAny<Guid>()));
            //mockedInvestmentMapper.Setup(m => m.Map<ReadInvestmentDto>(It.IsAny<Investment>())).Returns(ReadInvestmentObject);

            var getInvestmentById = new GetInvestmentById(mockedInvestmentRepo.Object, mockedInvestmentMapper.Object);

            var results = getInvestmentById.ExacuteAsync(investmentObject.Id);

            Assert.Null(results);
        }
    }
}
