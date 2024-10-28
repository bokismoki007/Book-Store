using BookStore.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetDetailsForAuthor(Guid? id);
        void CreateNewAuthor(Author a);
        void UpdateExistingAuthor(Author a);
        void DeleteAuthor(Guid id);
    }
}
