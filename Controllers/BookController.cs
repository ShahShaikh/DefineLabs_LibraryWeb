using DefineLabs_Library.BAL;
using DefineLabs_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefineLabs_Library.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookBL bookBL = new BookBL();
        public ActionResult Index()
        {
            List<Book> books = new List<Book>();

            try
            {
                
                books = bookBL.GetBookList();
            }
            catch (Exception e)
            {

            }
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            try
            {
                AuthorBL authorBL = new AuthorBL();
                var authorList = authorBL.GetAuthors();

                ViewBag.AuthorList = new MultiSelectList(authorList, "authorId", "firstName");
            }
           catch(Exception e)
            {

            }
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                   
                    Author author = new Author();
                    Book book = new Book();
                    book.bookTitle = collection["bookTitle"];
                    author.firstName = collection["AuthorID"];
                    author.AuthorIDs = collection["AuthorID"];
                    string[] IDS = author.AuthorIDs.Split(',');

                    for (int i = 0; i <IDS.Count(); i ++)
                    {
                        //book.authorID =Convert.ToInt32( collection["AuthorName"]);
                        bookBL.AddBook(book.bookTitle, IDS[i]);
                    }

                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = new Book();
            BookBL bookBL = new BookBL();
            book = bookBL.GetBookByID(id);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Book book = new Book();
                    book.bookID =Convert.ToInt32( collection["bookID"]);
                    book.bookTitle = collection["bookTitle"];
                    BookBL bookBL = new BookBL();
                    bookBL.UpdateAuthor(book);
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            bool IsDeleted = false;
            Book book = new Book();
            BookBL bookBL = new BookBL();
            IsDeleted = bookBL.DeleteBook(id);
            return RedirectToAction("Index");
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
