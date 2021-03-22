using System.Collections.Generic;
using AutoMapper;
using ChildrensBookList.Data;
using ChildrensBookList.Dtos;
using ChildrensBookList.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name="GetBookById")]  // this decorator sets up this method to repond to GET requets
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
        
        // POST api/books
        [HttpPost]
        public ActionResult<BookReadDto> CreateBook(BookCreateDto bcd) {

            var bookModel = _mapper.Map<Book>(bcd);
            _repository.CreateBook(bookModel);
            _repository.SaveChanges();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);


            // return Ok(bookReadDto);

            // This will generate an additional header to show the route to access the
            // newly created resource
            return CreatedAtRoute(nameof(GetBookById), new {Id = bookReadDto.Id}, bcd);
        }

        // PUT api/books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, BookUpdateDto bud) {

            // does this resource actually exist?
            var bookModel = _repository.GetBookById(id);

            if(bookModel == null) {

                return NotFound();

            } else {

                _mapper.Map(bud, bookModel);

                _repository.UpdateBook(bookModel);

                _repository.SaveChanges();

                return NoContent();
            }
        }
        
        // PATCH api/books/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialBookUpdate(int id, JsonPatchDocument<BookUpdateDto> patchDoc) {

             // does this resource actually exist?
            var bookModel = _repository.GetBookById(id);

            if(bookModel == null) {

                return NotFound();

            } else {

                var bookToPatch = _mapper.Map<BookUpdateDto>(bookModel); 

                patchDoc.ApplyTo(bookToPatch, ModelState);

                if(!TryValidateModel(bookToPatch)) {

                    return ValidationProblem(ModelState);
                }

                _mapper.Map(bookToPatch, bookModel);

                _repository.UpdateBook(bookModel);

                _repository.SaveChanges();

                return NoContent();
            }          
        }

        // DELETE api/books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id) {
             
            // does this resource actually exist?
            var bookModel = _repository.GetBookById(id);

            if(bookModel == null) {

                return NotFound();

            } else {

                _repository.DeleteBook(bookModel);
                _repository.SaveChanges();

                return NoContent();
            }
        }
    }
}