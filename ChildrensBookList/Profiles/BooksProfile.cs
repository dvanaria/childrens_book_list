using AutoMapper;
using ChildrensBookList.Dtos;
using ChildrensBookList.Models;

namespace ChildrensBookList.Profiles {

    public class BooksProfile : Profile {

        public BooksProfile() {
        
            CreateMap<Book, BookReadDto>();
        }
    }
}