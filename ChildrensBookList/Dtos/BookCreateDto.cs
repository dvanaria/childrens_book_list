using System.ComponentModel.DataAnnotations;

namespace ChildrensBookList.Dtos {

    public class BookCreateDto {

        // don't allow consumer to supply Id
        // Primary key is handled by the DB

        // add Required annotations to give more feedback
        // to consumer if bad request is made (with incomplete data)

        [Required]        
        [MaxLength(256)]
        public string Title { get; set; }

        [Required]        
        [MaxLength(256)]
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