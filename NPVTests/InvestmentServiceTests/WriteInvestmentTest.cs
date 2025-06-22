using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;
using InvestmentsService.Models;
using InvestmentsService.SyncDataServices.Http;
using InvestmentsService.UseCases.CreateInvestmentUseCase;
using Moq;

namespace NPVTests.InvestmentServiceTests
{
    public class WriteInvestmentTest
    {
        [Fact]
        public void CreateNewInvestmentTest()
        {
            var writeInvestmentDto = new WriteInvestmentDto()
            {
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };
            var readInvestmentDto = new ReadInvestmentDto()
            {
                Id = new Guid(),
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var investmentObject = new Investment()
            {
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var mockedInvestmentRepo = new Mock<IInvestmentRepo>();
            var mockedInvestmentMapper = new Mock<IMapper>();
            var mockedInvestmentsDataClient = new Mock<IInvestmentsDataClient>();

            mockedInvestmentRepo.Setup(m => m.CreateInvestment(investmentObject));
            mockedInvestmentMapper.Setup(m => m.Map<Investment>(It.IsAny<WriteInvestmentDto>())).Returns(investmentObject);
            mockedInvestmentMapper.Setup(m => m.Map<ReadInvestmentDto>(It.IsAny<Investment>())).Returns(readInvestmentDto);
            mockedInvestmentsDataClient.Setup(m => m.sendInvestmentsToCashFlow(readInvestmentDto));
            var createInvestmentUseCase = new CreateInvestmentUseCase(mockedInvestmentRepo.Object, mockedInvestmentMapper.Object, mockedInvestmentsDataClient.Object);

            var result = createInvestmentUseCase.ExacuteAsync(writeInvestmentDto);

            Assert.Equal(result.Result.Id, readInvestmentDto.Id);
        }
        
        [Fact]
        public void ThrowArgumentNullExceptionOnCreateInvestment_WriteInvestmentDtoIsNullTest()
        {
            
            var readInvestmentDto = new ReadInvestmentDto()
            {
                Id = new Guid(),
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var investmentObject = new Investment()
            {
                Name = "HosingLLM",
                Discription = "New built for rent estate in west dublin",
                DiscountRate = 10.0m
            };

            var mockedInvestmentRepo = new Mock<IInvestmentRepo>();
            var mockedInvestmentMapper = new Mock<IMapper>();
            var mockedInvestmentsDataClient = new Mock<IInvestmentsDataClient>();


            mockedInvestmentRepo.Setup(m => m.CreateInvestment(investmentObject));
            mockedInvestmentMapper.Setup(m => m.Map<Investment>(It.IsAny<WriteInvestmentDto>())).Returns(investmentObject);
            mockedInvestmentMapper.Setup(m => m.Map<ReadInvestmentDto>(It.IsAny<Investment>())).Returns(readInvestmentDto);
            mockedInvestmentsDataClient.Setup(m => m.sendInvestmentsToCashFlow(readInvestmentDto));

            var createInvestmentUseCase = new CreateInvestmentUseCase(mockedInvestmentRepo.Object, mockedInvestmentMapper.Object, mockedInvestmentsDataClient.Object);

           
           var results =createInvestmentUseCase.ExacuteAsync(null);



            Assert.Equal(results.Exception.Message, "One or more errors occurred. (Value cannot be null. (Parameter 'investment'))");
        }
    }
}
