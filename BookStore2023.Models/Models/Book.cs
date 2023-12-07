using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore2023.Models.Models
{
    public record Book
    {
        public int Id { get; set; }

        public string Title { get; set; }   = string.Empty;
    }
}
