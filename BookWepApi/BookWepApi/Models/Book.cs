using System.ComponentModel.DataAnnotations;

namespace BookWepApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string MLA => $"{AuthorLastName}, {AuthorFirstName}. \"{Title}.\" {Publisher}, {Price:C}.";
        public string Chicago => $"{AuthorFirstName} {AuthorLastName}. \"{Title}.\" {Publisher}, {DateTime.Now.Year}.";

    }
}
