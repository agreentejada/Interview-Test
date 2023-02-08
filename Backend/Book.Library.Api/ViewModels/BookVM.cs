using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Book.Library.Api.ViewModels
{
    // If we know more about the business requirements for BookVM, we can add additional validation to prevent our database from saving bad data.
    // Unfortunately, since we don't know anything, this VM is a direct copy of the entity.

    public class BookVM
    {
        // Since BookVM is used in POST/PUT operations, this is not required.
        public string? Id { get; set; }

        [MaxLength(200)]
        public string? Author { get; set; }

        [MaxLength(200)]
        public string? Title { get; set; }

        [MaxLength(10)]
        public string? Publish_Date { get; set; }

        [MaxLength(200)]
        public string? Genre { get; set; }

        public double? Price { get; set; }

        public string? Description { get; set; }

    }
}
