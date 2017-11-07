﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PalpatineApi.Controllers
{
	[Authorize]
	[EnableCors(origins: "http://localhost:3000,https://localhost:3000,http://localhost:5000,https://localhost:5000", headers: "*", methods: "*")]
	[RoutePrefix("api/Quote")]
	public class QuoteController : ApiController
    {
		[AllowAnonymous]
		[HttpGet]
		[Route("random")]
		public string Get()
		{
			var quote = "The impediment to action advances action. What stands in the way becomes the way";
			return quote;
		}
    }
}
