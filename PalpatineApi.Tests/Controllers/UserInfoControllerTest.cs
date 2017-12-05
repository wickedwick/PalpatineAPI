using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalpatineApi.Controllers;
using PalpatineApi.Models;
using Moq;
using PalpatineApi.BusinessLogic;
using PalpatineApi.BusinessLogic.Base;
using System.Threading.Tasks;
using System.Security.Principal;

namespace PalpatineApi.Tests.Controllers
{
	[TestClass]
	public class UserInfoControllerTest
	{
		private Mock<IUserInfoBusinessLogic> userInfoBllMock;

		[TestMethod]
		public void TestGet()
		{
			UserViewModel testUser = new UserViewModel
			{
				UserId = "test",
				UserName = "testyMctest"
			};
			userInfoBllMock = new Mock<IUserInfoBusinessLogic>();
			userInfoBllMock.Setup(x => x.GetUserInfo(It.IsAny<string>())).Returns(Task.FromResult<UserViewModel>(testUser));
			var systemUnderTest = new UserInfoController(userInfoBllMock.Object);
			systemUnderTest.User = new GenericPrincipal(new GenericIdentity("Bob", "Passport"), new[] { "Emperor" });
			var result = systemUnderTest.Get("testId").Result;

			Assert.IsNotNull(result);
			Assert.AreEqual("testyMctest", result.UserName);
		}

		[TestMethod]
		[ExpectedException(typeof(AggregateException))]
		public void TestGet_Unauthorized()
		{
			UserViewModel testUser = new UserViewModel
			{
				UserId = "test",
				UserName = "testyMctest"
			};
			userInfoBllMock = new Mock<IUserInfoBusinessLogic>();
			userInfoBllMock.Setup(x => x.GetUserInfo(It.IsAny<string>())).Returns(Task.FromResult<UserViewModel>(testUser));
			var systemUnderTest = new UserInfoController(userInfoBllMock.Object);
			systemUnderTest.User = new GenericPrincipal(new GenericIdentity("Bob", "Passport"), new[] { "Stormtrooper" });
			var result = systemUnderTest.Get("testId").Result;

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestPut()
		{
			UserViewModel testUser = new UserViewModel
			{
				UserId = "test",
				UserName = "testyMctest"
			};
			userInfoBllMock = new Mock<IUserInfoBusinessLogic>();
			userInfoBllMock.Setup(x => x.GetUserInfo(It.IsAny<string>())).Returns(Task.FromResult<UserViewModel>(testUser));
			var systemUnderTest = new UserInfoController(userInfoBllMock.Object);
			systemUnderTest.User = new GenericPrincipal(new GenericIdentity("Bob", "Passport"), new[] { "Emperor" });
			var result = systemUnderTest.Put("test", testUser).Result;

			Assert.IsNotNull(result);
		}

		[TestMethod]
		[ExpectedException(typeof(AggregateException))]
		public void TestPut_Unauthorized()
		{
			UserViewModel testUser = new UserViewModel
			{
				UserId = "test",
				UserName = "testyMctest"
			};
			userInfoBllMock = new Mock<IUserInfoBusinessLogic>();
			userInfoBllMock.Setup(x => x.GetUserInfo(It.IsAny<string>())).Returns(Task.FromResult<UserViewModel>(testUser));
			var systemUnderTest = new UserInfoController(userInfoBllMock.Object);
			systemUnderTest.User = new GenericPrincipal(new GenericIdentity("Bob", "Passport"), new[] { "Stormtrooper" });
			var result = systemUnderTest.Put("test", testUser).Result;

			Assert.IsNotNull(result);
		}
	}
}
