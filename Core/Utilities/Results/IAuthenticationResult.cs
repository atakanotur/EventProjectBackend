using Core.Entities;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IAuthenticationResult
    {
        public int UserId { get; } 
        public string Email { get; }
        public AccessToken AccessToken { get; }
    }
}
