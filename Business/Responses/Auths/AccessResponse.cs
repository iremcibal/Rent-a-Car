using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Auths
{
    public class AccessResponse
    {
        public AccessToken AccessToken { get; set; } 
    }
}
