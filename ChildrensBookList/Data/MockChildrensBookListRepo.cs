using System.Collections.Generic;
using ChildrensBookList.Models;

// The data in this "mock" repository is hard-coded as a starting point
// to build the rest of the applictaion, as well as a use case for testing

namespace ChildrensBookList.Data {

    public class MockChildrensBookListRepo : IChildrensBookListRepo
    {
        public void CreateBook(Book b)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBook(Book b)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book> {
                new Book{
                    Id=0,
                    Title="Charlotte's Web",
                    Author="E. B. White",
                    Illustrator="Garth Williams",
                    Year=1952,
                    Pages=192,
                    Age=8,
                    Grade=3},
                new Book{
                    Id=1,
                    Title="Mr. Popper's Penguins",
                    Author="Richard and Florence Atwater",
                    Illustrator="Robert Lawson",
                    Year=1938,
                    Pages=139,
                    Age=6,
                    Grade=1},
                new Book{
                    Id=2,
                    Title="The Borrowers",
                    Author="Mary Norton",
                    Illustrator="Beth and Joe Krush",
                    Year=1953,
                    Pages=180,
                    Age=10,
                    Grade=5}
            };

            return books;
        }

        public Book GetBookById(int id)
        {
            return new Book{
                Id=0,
                Title="Charlotte's Web",
                Author="E. B. White",
                Illustrator="Garth Williams",
                Year=1952,
                Pages=192,
                Age=8,
                Grade=3};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBook(Book b)
        {
            throw new System.NotImplementedException();
        }
    }
}