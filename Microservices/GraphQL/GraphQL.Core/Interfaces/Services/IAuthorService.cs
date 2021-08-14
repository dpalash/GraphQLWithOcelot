using System.Collections.Generic;
using GraphQL.Core.DTOs;

namespace GraphQL.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        Author Add(Author author);
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        List<BlogPost> GetPostsByAuthor(int id);
    }
}