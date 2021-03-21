namespace ChildrensBookList.Dtos {

    // This DTO will remove the Age and Grade information
    // from the data offered to the consumer
    
    public class BookReadDto {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Illustrator { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }
    }
}