using InvestmentsService.Models;

namespace InvestmentsService.Data
{
    public static class PrepDb
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
                new Investment() { Name = "HosingLLM", Discription = "New built for rent estate in west dublin", DiscountRate = 10.0m },
                new Investment() { Name = "AIR&D", Discription = "LLM tool for avaiation devlopment", DiscountRate = 10.0m },
                new Investment() { Name = "El'af", Discription = "Inperson fantasy experiance", DiscountRate = 10.0m }
                );

            dbContext.SaveChanges();
            Console.WriteLine("Data added");

            var inventories = dbContext.Investment.ToList();
        }
    }
}