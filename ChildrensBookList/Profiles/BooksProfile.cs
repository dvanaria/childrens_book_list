using AutoMapper;
using ChildrensBookList.Dtos;
using ChildrensBookList.Models;

namespace ChildrensBookList.Profiles {

    public class BooksProfile : Profile {

        public BooksProfile() {
        
            // source -> target
            CreateMap<Book, BookReadDto>();    // GET
            CreateMap<BookCreateDto, Book>();  // POST
            CreateMap<BookUpdateDto, Book>();  // PUT
            CreateMap<Book, BookUpdateDto>();  // PATCH
        }
    }
}