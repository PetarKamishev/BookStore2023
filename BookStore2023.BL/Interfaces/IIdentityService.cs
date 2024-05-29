using BookStore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Interfaces
{
    public interface IIdentityService 
    {
        Task<AuthenticationResult> RegisterAsync(string userName, string password, string email);
        Task<AuthenticationResult> LoginAsync(string userName, string password);

        Task LogOff();
    }
}
