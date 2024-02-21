using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacAPI.Models
{
public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public ICollection<Author>? Authors { get; set; }
}
}