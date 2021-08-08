using DefineLabs_Library.BAL;
using DefineLabs_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefineLabs_Library.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            List<Author> authors = new List<Author>();
            
            try
            {
                AuthorBL authbl = new AuthorBL();
                authors= authbl.GetAuthorList();
            }
            catch(Exception e)
            {

            }
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    Author author = new Author();
                    author.firstName = collection["firstName"];
                    author.lastName = collection["lastName"];
                    author.dateOfBirth = Convert.ToDateTime(collection["dateOfBirth"]);
                    AuthorBL authorBL = new AuthorBL();
                    authorBL.AddAuthor(author);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            Author author = new Author();
            AuthorBL authBL = new AuthorBL();
            author = authBL.GetListByAuthorID(id);   
            return View(author);
        }

        public ActionResult SaveAuthor(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            try
            {
                bool isUpdated = false;
                Author author = new Author();
                AuthorBL authBL = new AuthorBL();
                isUpdated = authBL.UpdateAuthor(id, firstName, lastName, dateOfBirth);

            }
           
           catch(Exception e)
            {

            }
            return RedirectToAction("Index");
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            bool IsDeleted = false;
            Author author = new Author();
            AuthorBL authBL = new AuthorBL();
            IsDeleted = authBL.DeleteAuthor(id);
            return RedirectToAction("Index");
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
