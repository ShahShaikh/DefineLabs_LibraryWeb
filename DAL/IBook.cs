using DefineLabs_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineLabs_Library.DAL
{
    interface IBook
    {
        List<Book> GetBookList();

        bool AddBook(string bookTitle, string AuthorIDs);

        bool DeleteBook(int id);

        bool UpdateBook(Book book);
    }
}
