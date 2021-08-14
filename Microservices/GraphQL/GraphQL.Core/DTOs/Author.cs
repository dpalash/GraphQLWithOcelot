using System;

namespace GraphQL.Core.DTOs
{
    [Serializable]
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
