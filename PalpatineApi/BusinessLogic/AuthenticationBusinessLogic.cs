using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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
				}),
				Expires = now.AddMinutes(20),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
			};

			var sToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(sToken);
			return token;
		}

		public static ClaimsPrincipal GetPrincipal(string token)
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
	}
}