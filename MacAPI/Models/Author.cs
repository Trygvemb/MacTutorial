using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacAPI.Models
{
public class Author
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }
    public ICollection<Book>? Books { get; set; }
}
}