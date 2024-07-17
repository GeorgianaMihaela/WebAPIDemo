using BusinessLogic.Books;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPIsNoDB.Mappers;
using static System.Reflection.Metadata.BlobBuilder;


namespace WebAPIsNoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {

        private BookService bookService = new BookService();
        private BookMapper bookMapper = new BookMapper();

        [HttpGet]
        public List<BookDTO> Get()
        {
            var books = bookService.GetBooks();

            var booksDTO = bookMapper.GetBooksDTOList(books);

            return booksDTO;
        }


        [HttpPost]
        [Consumes("application/json")]
        public BookDTO Post([FromBody] BookDTO book)
        {
            Book newBook = bookMapper.MapBookDTOToBook(book);

            Book insertedBook = bookService.InsertBook(newBook);

            var insertedBookDTO = bookMapper.MapBookToBookDTO(insertedBook);

            return insertedBookDTO;
        }

        [HttpPut]
        [Consumes("application/json")]
        public BookDTO Put([FromBody] BookDTO book)
        {
            var newBook = bookMapper.MapBookDTOToBook(book);

            var updatedBook = bookService.UpdateBook(newBook);

            return book;
        }

        [HttpGet]
        [Route("{isbn}")] // the name I place here in the Route must be exactly the method param
        public BookDTO Get([FromRoute] string isbn)
        {
            Book book = bookService.GetBookByISBN(isbn);

            BookDTO bookDTO = bookMapper.MapBookToBookDTO(book);

            return bookDTO;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("review")]
        public void PostReview([FromBody] BookReviewDTO bookReviewDTO)
        {
            BookReview bookReview = bookMapper.MapBookReviewDTOToBookReview(bookReviewDTO);
                
            bookService.AddBookReview(bookReview);
        }


    }
}
