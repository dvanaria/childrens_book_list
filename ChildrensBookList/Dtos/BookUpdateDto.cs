using System.ComponentModel.DataAnnotations;

namespace ChildrensBookList.Dtos {

    public class BookUpdateDto {

        public string Title { get; set; }

        public string Author { get; set; }

        public string Illustrator { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }
    }
}