using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalpatineApi.Models;
using PalpatineApi.BusinessLogic;
using PalpatineApi.BusinessLogic.Base;
using Moq;
using System.Collections.Generic;
using NUnit;
using NUnit.Framework;

namespace PalpatineApi.Tests.BusinessLogic
{
	[TestFixture]
	public class AuthenticationBusinessLogicTests
	{
		[Test]
		public void GetToken_Success()
		{
			//var username = "twickham@stuff.test";
			//string result = AuthenticationBusinessLogic.GetToken(username);
			//Assert.IsNotNull(result);
		}

		[Test]
		public void GetToken_Fail()
		{
			//var username = "";
			//string result = AuthenticationBusinessLogic.GetToken(username);
			//Assert.IsNull(result);
		}

		[Test]
		public void GetPrincipal_Success()
		{
			//string token = AuthenticationBusinessLogic.GetToken("twickham@stuff.test");
			//var principal = AuthenticationBusinessLogic.GetPrincipal(token);
			//Assert.IsNotNull(principal);
		}
	}
}
