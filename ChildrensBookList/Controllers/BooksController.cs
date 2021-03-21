using System.Collections.Generic;
using ChildrensBookList.Data;
using ChildrensBookList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChildrensBookList.Controllers {

    // Inherits from ControllerBase - won't need the full
    // functionaliry of the Controller parent class

    // api/books
    [Route("api/books")]
    [ApiController]  // provides some default behaviors
    public class BooksController : ControllerBase {
        
        private readonly IChildrensBookListRepo _repository;

        // The constructor receives an instance of the repository implementation
        // by the dependency injection system (registered in Startup.cs)
        public BooksController(IChildrensBookListRepo repo) {

            _repository = repo;
        }

        // The methods in this class will implement all the endpoints offered by the API as ActionResults.
        // The HTTP Verb + URI provides unique path to each endpoint.
        
        // GET api/books
        [HttpGet]  // this decorator sets up this method to repond to GET requets
        public ActionResult <IEnumerable<Book>> GetAllBooks() {
            
            var bookItems = _repository.GetAllBooks();

            return Ok(bookItems);
        }

        // GET api/books/{id}
        [HttpGet("{id}")]  // this decorator sets up this method to repond to GET requets
        public ActionResult <Book> GetBookById(int id) {

            var bookItem = _repository.GetBookById(id);

            return Ok(bookItem);
        }
    }
}