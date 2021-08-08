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
    public class AuthorDL:IAuthor
    {
        string con = ConfigurationManager.ConnectionStrings["DefineLabs"].ConnectionString.ToString();
        public List<Author> GetAuthorList()
        {
            List<Author> authors = new List<Author>();

            try
            {
                //List<Author> authors = new List<Author>();
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAuthorList", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            authors.Add(new Author
                            {
                                authorId = Convert.ToInt32(reader["AuthorID"]),
                                firstName = (reader["FirstName"]).ToString(),
                                lastName = (reader["LastName"]).ToString(),
                                dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"])
                            });

                        }

                    }
                }
            }
            catch (Exception e)
            {

            }
            return authors;
        }

        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();

            try
            {
                //List<Author> authors = new List<Author>();
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAuthors", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            authors.Add(new Author
                            {
                                authorId = Convert.ToInt32(reader["AuthorID"]),
                                firstName = (reader["AuthorName"]).ToString()

                            });

                        }

                    }
                }
            }
            catch (Exception e)
            {

            }
            return authors;
        }

        public Author GetListByAuthorID(int id)
        {

            Author author = new Author();
            author.books = new List<Book>();
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("GETAuthorBookByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@authorId", id);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                author.authorId = Convert.ToInt32(reader["AuthorID"]);
                                author.firstName = reader["FirstName"].ToString();
                                author.lastName = reader["LastName"].ToString();
                                author.dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                author.books.Add(new Book()
                                {
                                    bookID = Convert.ToInt32(reader["BookID"]),
                                    bookTitle = reader["BookTitle"].ToString()

                                });
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
            return author;
        }


        public bool DeleteAuthor(int id)
        {

            bool isDeleted = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteAuthorByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@authorID", id);
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            isDeleted = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return isDeleted;
        }

        public bool AddAuthor(Author author)
        {
            List<Author> authors = new List<Author>();
            bool IsAdded = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("AddAuthor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstName", author.firstName);
                        cmd.Parameters.AddWithValue("@lastName", author.lastName);
                        cmd.Parameters.AddWithValue("@dateOfBirth", author.dateOfBirth);
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();

                        if (count > 0)
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


        public bool UpdateAuthor(int id, string firstName, string lastName, DateTime dateOfBirth)
        {

            bool IsUpdated = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateAuthorByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@authorID", id);
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
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