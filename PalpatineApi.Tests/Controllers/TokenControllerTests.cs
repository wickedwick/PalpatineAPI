using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using Moq;
using PalpatineApi.Controllers;

namespace PalpatineApi.Tests.Controllers
{
	[TestClass]
	public class TokenControllerTests
	{
		[TestMethod]
		public void Token_Get_Success()
		{
			TokenController systemUnderTest = new TokenController();
			var result = systemUnderTest.Get("user", "pass");

			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
		}
	}
}
