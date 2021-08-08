using DefineLabs_Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DefineLabs_Library.DAL
{
    public class BookDL:IBook
    {
        string con = ConfigurationManager.ConnectionStrings["DefineLabs"].ConnectionString.ToString();
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>();

            try
            {
                //List<Author> authors = new List<Author>();
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("GETBookList", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            books.Add(new Book
                            {
                                bookID = Convert.ToInt32(reader["BookID"]),
                                bookTitle = (reader["BookTitle"]).ToString(),
                                authorID = Convert.ToInt32(reader["AuthorID"])

                            });

                        }

                    }
                }
            }
            catch (Exception e)
            {

            }
            return books;
        }

        public Book GetBookByID(int id)
        {
            Book book = new Book();

            try
            {
                //List<Author> authors = new List<Author>();
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("GETBookByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@bookID", id);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {


                            book.bookID = Convert.ToInt32(reader["BookID"]);
                            book.bookTitle = (reader["BookTitle"]).ToString();
                            book.authorID = Convert.ToInt32(reader["AuthorID"]);

                           

                        }

                    }
                }
            }
            catch (Exception e)
            {

            }
            return book;
        }
        public bool AddBook(string bookTitle, string AuthorIDs)
        {
            bool IsAdded = false;
            try
            {
                //List<Author> authors = new List<Author>();
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("AddBook", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@bookTitle", bookTitle);
                        cmd.Parameters.AddWithValue("@AuthorID", AuthorIDs);
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();
                        if(count > 0)
                        {
                            IsAdded = true;
                        }


                    }
                }
            }
            catch (Exception e)
            {

            }
            return IsAdded;
        }

        public bool DeleteBook(int id)
        {
            bool IsDeleted = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteBook", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BookID", id);
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            IsDeleted = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
            return IsDeleted;
        }

        public bool UpdateBook(Book book)
        {
            bool IsUpdated = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateBookByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@bookID", book.bookID);
                        cmd.Parameters.AddWithValue("@bookTitle", book.bookTitle);
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            IsUpdated = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return IsUpdated;
        }
    }
}