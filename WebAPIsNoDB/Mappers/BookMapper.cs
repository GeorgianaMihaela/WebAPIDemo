using BusinessLogic.Books;
using WebAPIsNoDB.Controllers;

namespace WebAPIsNoDB.Mappers
{
    public class BookMapper
    {
        public List<BookDTO> GetBooksDTOList(List<Book> books)
        {

            List<BookDTO> booksDTO = new List<BookDTO>();
            foreach (var book in books)
            {
                var bookDTO = new BookDTO()
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author,
                    PublishedDate = book.PublishedDate, 
                    ReviewScore = book.ReviewScore
                };
                booksDTO.Add(bookDTO);
            }
            return booksDTO;
        }

        public Book MapBookDTOToBook(BookDTO book)
        {
            return new BusinessLogic.Books.Book
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                ReviewScore = book.ReviewScore
            };
        }

        public BookDTO MapBookToBookDTO(Book book)
        {
            return new BookDTO
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                ReviewScore = book.ReviewScore
            };
        }

        internal BookReview MapBookReviewDTOToBookReview(BookReviewDTO bookReviewDTO)
        {
            return new BookReview
            {
                ISBN = bookReviewDTO.ISBN,
                ReviewScore = float.Parse(bookReviewDTO.ReviewScore),
                ReviewText = bookReviewDTO.ReviewText
            };
        }
    }
}
