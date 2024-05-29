using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Responses
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; }

        public IEnumerable<string> Error { get; set; }
    }
}
