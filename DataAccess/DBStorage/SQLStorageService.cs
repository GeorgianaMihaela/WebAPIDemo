using DataAccess.DBStorage;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DBStorage
{
    public class SQLStorageService
    {
        private SqlConnection sqlConn = SQLConnectionService.GetService().Connection;
        public List<SQLBook> GetAllBooks()
        {
            List<SQLBook> books = new List<SQLBook>();
            string query = $"SELECT * FROM Books";

            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SQLBook book = new SQLBook();
                    book.Title = reader.GetString(1);
                    book.Author = reader.GetString(2);
                    book.ISBN = reader.GetString(3);
                    book.PublishedDate = reader.GetDateTime(4).ToString();
                    book.ReviewScore = (float)reader.GetDouble(5);

                    books.Add(book);
                }
                reader.Close();
            }
            return books; 

        }

        public void InsertBook(SQLBook sqlBook)
        {

            string query = $"INSERT INTO Books(title, author, isbn, publisheddate, reviewscore)" +
                $" VALUES (@title, @author, @isbn, @publisheddate, @reviewscore)";

            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@title", sqlBook.Title);
            sqlparams[1] = new SqlParameter("@author", sqlBook.Author);
            sqlparams[2] = new SqlParameter("@isbn", sqlBook.ISBN);
            sqlparams[3] = new SqlParameter("@publisheddate", sqlBook.PublishedDate);
            sqlparams[4] = new SqlParameter("@reviewscore", sqlBook.ReviewScore);

            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {
                command.Parameters.AddRange(sqlparams); // adds all the params at once 
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string value = reader.GetString(0);
                }
                reader.Close();
            }

        }
    }
}
