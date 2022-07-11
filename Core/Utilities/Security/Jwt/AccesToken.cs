using System;

namespace Core.Utilities.Security.Jwt
{
    public class AccesToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
