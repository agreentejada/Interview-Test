using Book.Library.Data;
using Book.Library.Data.Entities;
using Newtonsoft.Json;

namespace Book.Library.Api.Utils
{
    public class JsonFileHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        public JsonFileHelper(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
        }

        // No need to make a method async if you're going to wait on it in another function call.
        public void SeedDatabase()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data/books.json");
            var json = File.ReadAllText(filePath);

            var seedData = JsonConvert.DeserializeObject<List<BookEntity>>(json);

            _context.Books.AddRange(seedData);
            _context.SaveChanges();
        }

    }
}
