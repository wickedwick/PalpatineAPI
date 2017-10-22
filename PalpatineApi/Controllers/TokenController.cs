using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
//using Thinktecture.IdentityModel.Tokens;

namespace PalpatineApi.Controllers
{
    public class TokenController : ApiController
    {
		public string Get(string username, string password)
		{
			if (ValidateUser(username, password))
			{
				var subject = new System.Security.Claims.ClaimsIdentity();
				subject.AddClaim(new System.Security.Claims.Claim("username", username));
				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
				return tokenHandler.WriteToken(new JwtSecurityToken("PalpatineApi", "All"));
			}
			return "";
		}

		private bool ValidateUser(string username, string password)
		{
			return true;
		}
    }
}
