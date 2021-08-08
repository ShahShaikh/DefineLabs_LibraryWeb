using DefineLabs_Library.DAL;
using DefineLabs_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefineLabs_Library.BAL
{
    public class BookBL
    {
        BookDL bookDL = new BookDL();
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>();
            try
            {
                books = bookDL.GetBookList();
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
                book = bookDL.GetBookByID(id);
            }
            catch (Exception e)
            {

            }
            return book;
        }

        public bool UpdateAuthor(Book book)
        {
            bool isUpdated = false;
            try
            {

                isUpdated = bookDL.UpdateBook(book);
            }
            catch (Exception e)
            {

            }
            return isUpdated;
        }


        public bool DeleteBook(int id)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = bookDL.DeleteBook(id);
            }
            catch (Exception e)
            {

            }
            return isDeleted;
        }

        public bool AddBook(string bookTitle,string AuthorIDs)
        {
            bool IsAdded = false;
            try
            {
                IsAdded = bookDL.AddBook(bookTitle,AuthorIDs);
            }
            catch (Exception e)
            {

            }
            return IsAdded;
        }

    }
}