using System.Collections.Generic;
using AutoMapper;
using ChildrensBookList.Data;
using ChildrensBookList.Dtos;
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
        private readonly IMapper _mapper;

        // The constructor receives an instance of the repository implementation
        // by the dependency injection system (registered in Startup.cs)
        public BooksController(IChildrensBookListRepo repo, IMapper mapper) {

            _repository = repo;   // link to private instance for Repository interface
            _mapper = mapper;     // link to private instance for DTO mapping
        }

        // The methods in this class will implement all the endpoints offered by the API as ActionResults.
        // The HTTP Verb + URI provides unique path to each endpoint.
        
        // GET api/books
        [HttpGet]  // this decorator sets up this method to repond to GET requets
        public ActionResult <IEnumerable<BookReadDto>> GetAllBooks() {
            
            var bookItems = _repository.GetAllBooks();

            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(bookItems));
        }

        // GET api/books/{id}
        [HttpGet("{id}")]  // this decorator sets up this method to repond to GET requets
        public ActionResult <BookReadDto> GetBookById(int id) {

            var bookItem = _repository.GetBookById(id);

            // need to check: is this a valid id? If not, 
            // the API states it will return a 404 NOT FOUND
            if(bookItem != null) {

                return Ok(_mapper.Map<BookReadDto>(bookItem));

            } else {

                return NotFound();
            }

        }
    }
}