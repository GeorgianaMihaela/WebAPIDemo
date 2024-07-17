using BusinessLogic.DBStorage;
using BusinessLogic.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace BusinessLogic.Books
{
    public class BookService
    {
        private SQLStorageService sqlStorageService = new SQLStorageService(); 
        private BookMapper bookMapper = new BookMapper();

        public Book InsertBook(Book book)
        {
            /* if (!System.IO.File.Exists("books.json"))
             {
                 System.IO.File.Create("books.json").Close();
                 System.IO.File.WriteAllText("books.json", "[]");
             }

             // read all the books in the file first 
             var fileContent = System.IO.File.ReadAllText("books.json");
             var books = JsonSerializer.Deserialize<List<Book>>(fileContent);

             for (int i = 0; i < books.Count; i++)
             {
                 if (books[i].ISBN == book.ISBN)
                 {
                     throw new Exception("ISBN must be unique");
                 }
             }

             // add the book which we receive in the POST request 
             books.Add(book);

             // serialize the list of books back and write it to the file 
             var booksString = JsonSerializer.Serialize(books);
             System.IO.File.WriteAllText("books.json", booksString);

             return book; 

             */

            // var books = sqlStorageService.GetAllBooks(); 
            var sqlBook = bookMapper.MapBookToSQLBook(book);

            sqlStorageService.InsertBook(sqlBook);

            return book; 

        }

        public List<Book> GetBooks()
        {
            // var fileContent = System.IO.File.ReadAllText("books.json");
            // var books = JsonSerializer.Deserialize<List<Book>>(fileContent);

            List<SQLBook> sqlBooks = sqlStorageService.GetAllBooks();

            // convert List of sql books to list of books and return it
            return bookMapper.MapListSqlBookToListBook(sqlBooks); 
        }

        public Book UpdateBook(Book updatedBook)
        {
            // old way when the books were written to a file
            // read all the books in the file first 
            var fileContent = System.IO.File.ReadAllText("books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(fileContent);

            var bookToUpdate = books.FirstOrDefault(b => b.ISBN == updatedBook.ISBN);

            if (bookToUpdate == null)
            {
                return null;
            }

            bookToUpdate.ISBN = updatedBook.ISBN;
            bookToUpdate.Title = updatedBook.Title;
            bookToUpdate.Author = updatedBook.Author;
            bookToUpdate.PublishedDate = updatedBook.PublishedDate;

            // serialize the list of books back and write it to the file 
            var booksString = JsonSerializer.Serialize(books);
            System.IO.File.WriteAllText("books.json", booksString);

            return bookToUpdate;
        }

        public Book GetBookByISBN(string isbn)
        {
            // read all the books in the file first 
            var fileContent = System.IO.File.ReadAllText("books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(fileContent);

            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            return book; 

        }

        public void AddBookReview(BookReview bookReview)
        {
            Console.WriteLine(); 
        }
    }
}
