using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Principal;

namespace PalpatineApi.BusinessLogic
{
	public class AuthenticationBusinessLogic : Base.IAuthenticationBusinessLogic
	{
		private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

		public string GetTokenInstance(string user)
		{
			return GetToken(user);
		}

		public static string GetToken(string username)
		{
			if (string.IsNullOrWhiteSpace(username))
				return null;

			var symmetricKey = Convert.FromBase64String(Secret);
			var tokenHandler = new JwtSecurityTokenHandler();

			var now = DateTime.UtcNow;
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, username)
					// add role claim here
				}),
				Expires = now.AddMinutes(20),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
			};

			var sToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(sToken);
			return token;
		}

		public async static Task<ClaimsPrincipal> GetPrincipal(string token)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var jwtToken = tokenHandler.ReadToken(token);

				if (jwtToken == null)
					return null;

				var symmetricKey = Convert.FromBase64String(Secret);

				var validationParameters = new TokenValidationParameters()
				{
					RequireExpirationTime = true,
					ValidateIssuer = false,
					ValidateAudience = false,
					IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
				};

				SecurityToken securityToken;
				var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

				return principal;
			}
			catch (Exception)
			{
				return null;
			}
		}

		private static bool ValidateToken(string token, out string username)
		{
			username = null;

			var simplePrinciple = GetPrincipal(token).Result;
			var identity = simplePrinciple.Identity as ClaimsIdentity;

			if (identity == null)
				return false;

			if (!identity.IsAuthenticated)
				return false;

			var usernameClaim = identity.FindFirst(ClaimTypes.Name);
			username = usernameClaim?.Value;

			if (string.IsNullOrEmpty(username))
				return false;

			// More validation to check whether username exists in system

			return true;
		}
		
		public async static Task<IPrincipal> AuthenticateJwtToken(string token)
		{
			string username;

			if (ValidateToken(token, out username))
			{
				ApplicationUser userFromDb = null;
				var role = "";
				// based on username to get more information from database in order to build local identity
				using (ApplicationDbContext ctx = new ApplicationDbContext())
				{
					userFromDb = ctx.Users.Where(u => u.UserName == username).FirstOrDefault();
					role = ctx.Roles.Where(r => r.Users == userFromDb).FirstOrDefault().Name;
				}

				if (userFromDb == null)
					return null;

				if (string.IsNullOrWhiteSpace(role))
					role = "Stormtrooper";

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, username),
					new Claim(ClaimTypes.Email, username),
					new Claim(ClaimTypes.Role, role)
				};

				var identity = new ClaimsIdentity(claims, "Jwt");
				IPrincipal user = new ClaimsPrincipal(identity);

				return user;
			}

			return null;
		}
	}
}