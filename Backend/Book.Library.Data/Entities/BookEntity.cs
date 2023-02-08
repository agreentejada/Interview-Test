using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Library.Data.Entities
{
    [Table("Books")]
    public class BookEntity
    {
        // As the primary key, the Id can't be null. Ignore C# warnings in this case.
        public string Id { get; set; }

        // While the rest of these requirements look like minimal expectations, we can give some leeway that a book
        // MAY NOT have an author, title, publish_date, genre, price, or description.
        // Otherwise, properties should be marked with a [Required] tag.

        // However, this gives a lot more flexibility with how data should be stored. When writing an entity,
        // write the ideal case of data types.

        // Please note that I add MaxLength annotations to entities. It's somewhat useful to estimate the business requirements, but fundamentally
        // the exact length of different properties can be asked in follow-up questions. In any case, SQLite doesn't care about MaxLength.

        [MaxLength(200)]
        public string? Author { get; set; }

        [MaxLength(200)]
        public string? Title { get; set; }

        // ISO8601 2000-10-10 is only 10 characters.
        [MaxLength(10)]
        public string? Publish_Date { get; set; }

        [MaxLength(200)]
        public string? Genre { get; set; }

        public double? Price { get; set; }

        public string? Description { get; set; }

    }
}
