using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class AuthenticationResult : IAuthenticationResult
    {
        public int UserId { get;}
        public string Email { get;}
        public AccessToken AccessToken { get;}

        public AuthenticationResult(int userId, string email, AccessToken accessToken) 
        {
            UserId = userId;
            Email = email;
            AccessToken = accessToken;
        }
    }
}
