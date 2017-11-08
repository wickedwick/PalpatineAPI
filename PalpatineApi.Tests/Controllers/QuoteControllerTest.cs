using System;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalpatineApi;
using PalpatineApi.Controllers;
using Moq;
using System.Web;

namespace PalpatineApi.Tests.Controllers
{
	[TestClass]
	public class QuoteControllerTest
	{
		[TestMethod]
		public void TestGet()
		{
			var systemUnderTest = new QuoteController();
			var result = systemUnderTest.Get();

			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
		}

		[TestMethod]
		public void TestAuthorizedGet()
		{
			var systemUnderTest = new QuoteController();
			var result = systemUnderTest.AuthorizedGet();

			Assert.IsNotNull(result);
		}
	}
}
