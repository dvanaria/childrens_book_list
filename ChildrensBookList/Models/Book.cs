using System.ComponentModel.DataAnnotations;

namespace ChildrensBookList.Models {

    // decorate any non-nullable fields with data annotations (decoration)

    public class Book {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Illustrator { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Grade { get; set; }
    }
}