using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalpatineApi.Models;
using PalpatineApi.BusinessLogic;
using PalpatineApi.BusinessLogic.Base;
using Moq;
using System.Collections.Generic;

namespace PalpatineApi.Tests.BusinessLogic
{
	[TestClass]
	public class AuthenticationBusinessLogicTests
	{
		[TestMethod]
		public void GetToken_Success()
		{
			var username = "twickham@stuff.test";
			string result = AuthenticationBusinessLogic.GetToken(username);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetToken_Fail()
		{
			var username = "";
			string result = AuthenticationBusinessLogic.GetToken(username);
			Assert.IsNull(result);
		}

		[TestMethod]
		public void GetPrincipal_Success()
		{
			string token = AuthenticationBusinessLogic.GetToken("twickham@stuff.test");
			var principal = AuthenticationBusinessLogic.GetPrincipal(token);
			Assert.IsNotNull(principal);
		}
	}
}
