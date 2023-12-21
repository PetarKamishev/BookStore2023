using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore2023.Models.Models
{
    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

    }
}
