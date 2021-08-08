using DefineLabs_Library.DAL;
using DefineLabs_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefineLabs_Library.BAL
{
    public class AuthorBL
    {
        
        AuthorDL authdl = new AuthorDL();
        public List<Author> GetAuthorList()
        {
            List<Author> authors = new List<Author>();
            try
            {                            
                authors= authdl.GetAuthorList();                
            }
            catch (Exception e)
            {

            }
            return authors;
        }

        public Author GetListByAuthorID(int id)
        {
            Author author = new Author();

            try
            {
                author = authdl.GetListByAuthorID(id);               
            }
            catch (Exception e)
            {

            }
            return author;
        }


        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            try
            {
                authors = authdl.GetAuthors();
            }
            catch (Exception e)
            {

            }
            return authors;
        }

        public bool DeleteAuthor(int id)
        {
            bool isDeleted = false;
            try
            {               
                isDeleted = authdl.DeleteAuthor(id);
            }
            catch(Exception e)
            {

            }
            return isDeleted;
        }

        public bool AddAuthor(Author author)
        {
            bool IsAdded = false;
            try
            {
                IsAdded = authdl.AddAuthor(author);
            }
            catch (Exception e)
            {

            }
            return IsAdded;
        }

        public bool UpdateAuthor(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            bool isUpdated = false;
            try
            {

                isUpdated = authdl.UpdateAuthor(id,firstName,lastName,dateOfBirth);
            }
            catch (Exception e)
            {

            }
            return isUpdated;
        }

    }
}