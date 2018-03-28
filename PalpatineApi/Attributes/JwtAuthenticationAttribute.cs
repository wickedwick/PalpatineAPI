using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using PalpatineApi.BusinessLogic;
using System.Web.Http;
using System.Net;
using System.Security.Claims;

namespace PalpatineApi.Attributes
{
	public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
	{
		public string Realm { get; set; }
		public bool AllowMultiple
		{
			get
			{
				return true;
			}
		}

		public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			var request = context.Request;
			var authorization = request.Headers.Authorization;

			if (authorization == null || authorization.Scheme != "Bearer")
				return;
			
			if (String.IsNullOrEmpty(authorization.Parameter))
			{
				context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
				return;
			}

			var token = authorization.Parameter;
			IPrincipal principal = await AuthenticationBusinessLogic.AuthenticateJwtToken(token);

			if (principal == null)
				context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
			
			else
				context.Principal = principal;
		}

		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			Challenge(context);
			return Task.FromResult(0);
		}

		private void Challenge(HttpAuthenticationChallengeContext context)
		{
			string parameter = context.Request.Headers.Authorization.Parameter;

			if (!string.IsNullOrEmpty(Realm))
				parameter = "realm=\"" + Realm + "\"";

			context.ChallengeWith("Bearer", parameter);
		}
	}

	public class AuthenticationFailureResult : IHttpActionResult
	{
		public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
		{
			ReasonPhrase = reasonPhrase;
			Request = request;
		}

		public string ReasonPhrase { get; private set; }

		public HttpRequestMessage Request { get; private set; }

		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			return Task.FromResult(Execute());
		}

		private HttpResponseMessage Execute()
		{
			HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
			response.RequestMessage = Request;
			response.ReasonPhrase = ReasonPhrase;
			return response;
		}
	}
}