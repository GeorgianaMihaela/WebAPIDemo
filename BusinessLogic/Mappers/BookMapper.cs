﻿using BusinessLogic.Books;
using BusinessLogic.DBStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public class BookMapper
    {
        public SQLBook MapBookToSQLBook(Book book)
        {
            return new SQLBook
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate,
                ReviewScore = float.Parse(book.ReviewScore)
            };
        }

        public Book MapSqlBookToBook(SQLBook sqlBook)
        {
            return new Book
            {
                Title = sqlBook.Title,
                Author = sqlBook.Author,
                ISBN = sqlBook.ISBN,
                PublishedDate = sqlBook.PublishedDate,
                ReviewScore = sqlBook.ReviewScore.ToString()

            }; 
        }

        public List<Book> MapListSqlBookToListBook(List<SQLBook> sqlBooks)
        {
            List<Book> bookList = new List<Book>();

            foreach (SQLBook sqlBook in sqlBooks)
            {
                bookList.Add(MapSqlBookToBook(sqlBook)); 
            }

            return bookList;
        }
    }
}
