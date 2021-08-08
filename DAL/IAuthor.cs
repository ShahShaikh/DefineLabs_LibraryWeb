using DefineLabs_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineLabs_Library.DAL
{
    interface IAuthor
    {
        List<Author> GetAuthorList();
        Author GetListByAuthorID(int id);
        bool AddAuthor(Author author);
        bool DeleteAuthor(int id);
        bool UpdateAuthor(int id, string firstName, string lastName, DateTime dateOfBirth);
    }
}
