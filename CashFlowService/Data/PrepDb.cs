using CashFlowService.Models;

namespace CashFlowService.Data
{
    public class PrepDb
    {
        public static void PrepDB(IApplicationBuilder app, bool isDevlopment)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDB(serviceScope.ServiceProvider.GetService<AppDbContext>(), isDevlopment);
            }
        }
        
        private static void SeedDB(AppDbContext dbContext, bool isDevlopment)
        {
            if (!isDevlopment)
            {
                //todo entity frame work migration    
            }

            if (dbContext.Investment.Any())
            {
                Console.WriteLine("Db is already populated");
            }
            else
            {
                Console.WriteLine("Seeding data to the DB");
                AddRanges(dbContext);
            }
        }

        private static void AddRanges(AppDbContext dbContext)
        {
            dbContext.Investment.AddRange(
                new Investment() { Id = new Guid("47e77d94-05db-4b53-90d8-2074bc67204a"), ExternalId = new Guid("5d7cee43-6b5b-4fbd-94f4-364dc0fe5218") },
                new Investment() { Id = new Guid(), ExternalId = new Guid("796dbe00-7687-403a-9715-b128ca7b10df")},
                new Investment() { Id = new Guid(), ExternalId = new Guid("0f7bd25f-60cc-4701-b9bc-9765d631568c")}
            );

            dbContext.Cashflow.AddRange(
                new CashFlow() { InvestmentId = new Guid("47e77d94-05db-4b53-90d8-2074bc67204a") },
                new CashFlow() { InvestmentId = new Guid("47e77d94-05db-4b53-90d8-2074bc67204a") },
                new CashFlow() { InvestmentId = new Guid("47e77d94-05db-4b53-90d8-2074bc67204a") }
            );

            dbContext.SaveChanges();
            Console.WriteLine("Data added");

            var inventories = dbContext.Investment.ToList();
        }
    }
}
